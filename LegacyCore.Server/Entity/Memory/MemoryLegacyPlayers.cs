using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CitizenFX.Core;

namespace LegacyCore.Server.Entity.Memory {

    /// <summary>
    /// A memory implementation of LegacyPlayers
    /// </summary>
    public abstract class MemoryLegacyPlayers : LegacyPlayers {

        // A dictionary (unique id -> player) of all loaded players
        protected IDictionary<string, LegacyPlayer> Players = new Dictionary<string, LegacyPlayer>();

        /// <inheritdoc />
        public override void Clean() {
           
        }

        /// <inheritdoc />
        public override ICollection<LegacyPlayer> GetAllPlayers() {
            return Players.Values;
        }

        /// <inheritdoc />
        public override ICollection<LegacyPlayer> GetOnlinePlayers() {
            // Pre-define a collection we will add to
            ICollection<LegacyPlayer> col = new List<LegacyPlayer>();

            // Loop through all online players and get em!
            foreach (Player online in LegacyCoreServer.Instance.OnlinePlayers) {
                col.Add(this.GetByPlayer(online));
            }
            return col;
        }

        /// <inheritdoc />
        public override LegacyPlayer GetById(string id) {
            // Try and get the player from the dictionary
            if (Players.TryGetValue(id, out LegacyPlayer player)) {
                return player;
            }
            return this.GeneratePlayer(id);
        }

        /// <inheritdoc />
        public override LegacyPlayer GetBySteamId(string id) {
            return this.GetById(id);
        }

        /// <inheritdoc />
        public override LegacyPlayer GetByNetworkId(int id) {
            Player player = new PlayerList()[id];
            return this.GetByPlayer(new PlayerList()[id]);
        }

        /// <inheritdoc />
        public override LegacyPlayer GetByName(string name) {
            return this.GetByPlayer(LegacyCoreServer.Instance.OnlinePlayers[name]);
        }

        /// <inheritdoc />
        public override LegacyPlayer GetByPlayer(Player player) {
            return this.GetBySteamId(player.Identifiers[IdentifierType.STEAM]);
        }

        /// <summary>
        /// Generates a LegacyPlayer
        /// </summary>
        /// <param name="id">Player's unique id</param>
        /// <returns>Generated player</returns>
        public abstract LegacyPlayer GeneratePlayer(string id);
    }
}
