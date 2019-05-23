using CitizenFX.Core;
using LegacyCore.Server.Entity.Memory.MySql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegacyCore.Server.Entity {

    /// <summary>
    /// Represents all players
    /// </summary>
    public abstract class LegacyPlayers {

        public static LegacyPlayers Instance { get; } = GetPlayersImpl();

        /// <summary>
        /// Gets the implementation to use for the players
        /// </summary>
        /// <returns>Implementation of players</returns>
        private static LegacyPlayers GetPlayersImpl() {
            return new MySqlLegacyPlayers();
        }

        /// <summary>
        /// Cleans the loaded players
        /// </summary>
        public abstract void Clean();

        /// <summary>
        /// Gets a collection of all loaded players in memory
        /// </summary>
        /// <returns>Collection of loaded players</returns>
        public abstract ICollection<LegacyPlayer> GetAllPlayers();

        /// <summary>
        /// Gets a collection of all online players
        /// </summary>
        /// <returns>Collection of online players</returns>
        public abstract ICollection<LegacyPlayer> GetOnlinePlayers();

        /// <summary>
        /// Gets a player from their uniquely generated key by LegacyCore
        /// </summary>
        /// <param name="id">Unique key</param>
        /// <returns></returns>
        public abstract LegacyPlayer GetById(string id);

        /// <summary>
        /// Gets a player from a steam id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public abstract LegacyPlayer GetBySteamId(string id);

        /// <summary>
        /// Gets a player from their network id
        /// </summary>
        /// <param name="id">Network id</param>
        /// <returns></returns>
        public abstract LegacyPlayer GetByNetworkId(int id);

        /// <summary>
        /// Gets a player from their name
        /// </summary>
        /// <param name="name">Name to use</param>
        /// <returns></returns>
        public abstract LegacyPlayer GetByName(string name);

        /// <summary>
        /// Gets a player from a CitizenX's Player
        /// </summary>
        /// <param name="player">CitizenX player</param>
        /// <returns></returns>
        public abstract LegacyPlayer GetByPlayer(Player player);

        /// <summary>
        /// Loads players into memory
        /// </summary>
        public abstract void Load();

        /// <summary>
        /// Force saves players
        /// </summary>
        public abstract void ForceSave();

        /// <summary>
        /// Force saves players async
        /// </summary>
        public abstract Task ForceSaveAsync();

    }
}
