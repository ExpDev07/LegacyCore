using CitizenFX.Core;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegacyCore.Server.Entity.Memory.MySql {

    /// <summary>
    /// A MySQL memory implementation of LegacyPlayers
    /// </summary>
    public class MySqlLegacyPlayers : MemoryLegacyPlayers {

        /// <summary>
        /// Force saves players to a MySQL database sync
        /// </summary>
        public override void ForceSave() {
            this.ForceSaveAsync().RunSynchronously();
        }

        /// <summary>
        /// Force saves players to a MySQL database async
        /// </summary>
        /// <returns>Task responsible</returns>
        public override async Task ForceSaveAsync() { 
            // Get database and start a transaction
            Database database = LegacyCoreServer.Db.Database;
            DbContextTransaction transaction = database.BeginTransaction();
            try {

                // Add users and save changes
                LegacyCoreServer.Db.Players.AddRange(base.Players.Values);
                await LegacyCoreServer.Db.SaveChangesAsync();

                transaction.Commit();
            } catch (Exception) {
                // Oops, something went wrong, rollback to previous version
                transaction.Rollback();
            }
        }

        /// <summary>
        /// Loads players from a MySQL database
        /// </summary>
        public override void Load() {
            // Grab users with same steamid
            List<LegacyPlayer> players = LegacyCoreServer.Db.Players.ToList();

            // Clear players and start adding them
            base.Players.Clear();
            foreach (LegacyPlayer player in players) {
                base.Players.Add(player.Id, player);
            }
        }

        /// <inheritdoc />
        public override LegacyPlayer GeneratePlayer(string id) {
            LegacyPlayer player = new LegacyPlayer(id);
            base.Players.Add(id, player);
            return player;
        }

        /// <summary>
        /// Gets or creates a player from steamid
        /// </summary>
        /// <param name="steamId">SteamId of player</param>
        /// <returns>A new or retrieved player</returns>
        public static async Task<LegacyPlayer> GetOrCreate(string steamId) {
            // Pre-define a user
            LegacyPlayer user = null;

            // Get database and start a transaction
            Database database = LegacyCoreServer.Db.Database;
            DbContextTransaction transaction = database.BeginTransaction();

            // Start the dangerous stuff
            try {
                // Grab users with same steamid
                List<LegacyPlayer> users = LegacyCoreServer.Db.Players.Where(u => u.SteamId == steamId).ToList();

                // If no user is found, create them
                if (!users.Any()) {
                    // Create user
                    user = new LegacyPlayer(steamId);

                    // Add user and save changes
                    LegacyCoreServer.Db.Players.Add(user);
                    await LegacyCoreServer.Db.SaveChangesAsync();
                } else {
                    // User found, use them instead
                    user = users.First();
                }

                // Commit to transaction
                transaction.Commit();
            } catch (Exception ex) {
                // Oops, something went wrong, rollback to previous version
                transaction.Rollback();
                Debug.Write(ex.Message);
            }

            // Finally, return out user
            return user;
        }
    }
}
