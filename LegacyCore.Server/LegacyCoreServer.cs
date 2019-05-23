using CitizenFX.Core;
using CitizenFX.Core.Native;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using LegacyCore.Server.Entity;
using LegacyCore.Server.Command;
using LegacyCore.Server.Chat;
using LegacyCore.Server.Command.Impl;
using LegacyCore.Server.Storage;
using LegacyCore.Server.Services;
using LegacyCore.Base.Services;

/// <summary>
/// Base namespace
/// </summary>
namespace LegacyCore.Server {

    /// <summary>
    /// Main class for the server-side of core
    /// </summary>
    public class LegacyCoreServer : BaseScript {

        /// <summary>
        /// Single instance of main class
        /// </summary>
        public static LegacyCoreServer Instance { get; private set; }

        /// <summary>
        /// Database context
        /// </summary>
        public static DB Db { get; private set; }

        /// <summary>
        /// A list of all online players
        /// </summary>
        public PlayerList OnlinePlayers => base.Players;

        /// <summary>
        /// A dictionary of all event handlers
        /// </summary>
        public new EventHandlerDictionary EventHandlers => base.EventHandlers;

        /// <summary>
        /// Registry for server's services
        /// </summary>
        public readonly ServiceRegistry Services = new ServiceRegistry();

        /// <summary>
        /// Script load
        /// </summary>
        public LegacyCoreServer() {
            // Setting singleton instance and subscribing to ticking
            Instance = this;
            Tick += OnTick;

            // Setup database and create it
            Db = new DB();
            Db.Database.CreateIfNotExists();

            // Load players
            LegacyPlayers.Instance.Load();

            // Register services
            Services.Add(new CommandService());
            Services.Add(new ConnectService());
            Services.Initialize();
        }

        /// <summary>
        /// Called when server ticks
        /// </summary>
        /// <returns>Task responsible for ticking</returns>
        private async Task OnTick() {
            // Guarantee async
            await Delay(100);
        }

        /// <summary>
        /// Broadcasts a message to all online players
        /// </summary>
        /// <param name="color">Color of prefix</param>
        /// <param name="prefix">Prefix of message</param>
        /// <param name="message">Message to broadcast</param>
        public void BroadcastMessage(int[] color, string prefix, string message) {
            // -1 triggers event for all connected clients
            TriggerClientEvent("chatMessage", prefix, color, new string[] { message });
        }

        /// <summary>
        /// Gets a player from a citizen
        /// </summary>
        /// <param name="player">Citizen of player</param>
        /// <returns>Player or null if not found</returns>
        public LegacyPlayer GetPlayer(Player player) {
            return LegacyPlayers.Instance.GetByPlayer(player);
        }

        /// <summary>
        /// Gets a player by their steamId
        /// </summary>
        /// <param name="id">Id of player</param>
        /// <returns>Player or null if not found</returns>
        public LegacyPlayer GetPlayerBySteamId(string steamId) {
            return LegacyPlayers.Instance.GetBySteamId(steamId);
        }

        /// <summary>
        /// Gets a player by their network id
        /// </summary>
        /// <param name="netId">Network id</param>
        /// <returns>Player or null if not found</returns>
        public LegacyPlayer GetPlayerByNetworkId(int netId) {
            return LegacyPlayers.Instance.GetByNetworkId(netId);
        }

        /// <summary>
        /// Gets a player by their name
        /// </summary>
        /// <param name="name">Name of player</param>
        /// <returns>Player or null if not found</returns>
        public LegacyPlayer GetPlayerByName(string name) {
            return LegacyPlayers.Instance.GetByName(name);
        }

        /// <summary>
        /// Gets a collection of online players
        /// </summary>
        /// <returns></returns>
        public ICollection<LegacyPlayer> GetOnlinePlayers() {
            return LegacyPlayers.Instance.GetOnlinePlayers();
        }

        /// <summary>
        /// Gets the console sender
        /// </summary>
        /// <returns>The console sender</returns>
        public ConsoleSender GetConsoleSender() {
            return new ConsoleSender();
        }

        /// <summary>
        /// Logs a message
        /// </summary>
        /// <param name="message">Message to log</param>
        public static void Log(string message) => Debug.Write($"{DateTime.Now:s} {message}{Environment.NewLine}");

    }
}
