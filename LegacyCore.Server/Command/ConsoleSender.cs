using CitizenFX.Core;
using LegacyCore.Server.Chat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegacyCore.Server.Command {

    /// <summary>
    /// The console
    /// </summary>
    public class ConsoleSender : ICommandSender {

        /// <summary>
        /// Prefix of messages send to console
        /// </summary>
        public static readonly string PREFIX = "LegacyCore";

        /// <summary>
        /// Gets the network id of console, always the same
        /// </summary>
        /// <returns>Always 0</returns>
        public int NetworkId => 0;

        /// <summary>
        /// Gets the name of console, always the same
        /// </summary>
        /// <returns>"Console"</returns>
        public string Name => "CONSOLE";

        /// <summary>
        /// Console's permission level
        /// </summary>
        /// <returns>int.MaxValue</returns>
        public int PermissionLevel { get; set; }

        /// <summary>
        /// Checks if console have permission, will always be the same
        /// </summary>
        /// <param name="permission"></param>
        /// <returns>Always true</returns>
        public bool IsPermised(int level) {
            // Console have all permissions
            return true;
        }

        /// <summary>
        /// Sends a message to console with prefix
        /// </summary>
        /// <param name="color">Redundant (not used)</param>
        /// <param name="prefix">Prefix of message</param>
        /// <param name="message">Message to send</param>
        public void SendMessage(int[] color, string prefix, string message) {
            // Just spits out in console and ignores color
            LegacyCoreServer.Log("[" + prefix + "] " + ChatColor.StripColors(message));
        }

        /// <summary>
        /// Sends a message to console
        /// </summary>
        /// <param name="message">Message to send</param>
        public void SendMessage(string message) {
            this.SendMessage(ColorScheme.WHITE, PREFIX, message);
        }
    }
}
