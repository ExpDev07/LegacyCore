using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegacyCore.Server.Command {

    /// <summary>
    /// A source which can perform commands
    /// </summary>
    public interface ICommandSender : IPermissible {

        /// <summary>
        /// Gets the network identifier
        /// </summary>
        /// <returns>The network identifier</returns>
        int NetworkId { get; }

        /// <summary>
        /// Gets the name
        /// </summary>
        /// <returns>The name</returns>
        string Name { get; }

        /// <summary>
        /// Sends a message
        /// </summary>
        /// <param name="color">Color of prefix</param>
        /// <param name="prefix">Prefix of message</param>
        /// <param name="message">Message to send</param>
        void SendMessage(int[] color, string prefix, string message);

        /// <summary>
        /// Sends a message with white color (255, 255, 255)
        /// </summary>
        /// <param name="message">Message to send</param>
        void SendMessage(string message);

    }
}
