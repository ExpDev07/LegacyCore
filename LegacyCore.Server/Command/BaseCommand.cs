using LegacyCore.Server.Chat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegacyCore.Server.Command {

    /// <summary>
    /// A base command executor
    /// </summary>
    public abstract class BaseCommand : ICommandExecutor {

        // Command's info
        protected CommandInfo info;

        /// <summary>
        /// Constructs a base command with info
        /// </summary>
        /// <param name="info">Info about command</param>
        public BaseCommand(CommandInfo info) {
            this.info = info;
        }

        /// <summary>
        /// Command's name
        /// </summary>
        public abstract string Name { get; }

        /// <summary>
        /// Performs command
        /// </summary>
        public abstract void Perform(CommandContext context);

        /// <summary>
        /// Executes command with context
        /// </summary>
        /// <param name="context">Context of command</param>
        /// <returns>Success state</returns>
        public bool Execute(CommandContext context) {
            // Sender of command
            ICommandSender sender = context.Sender;
            if (!sender.IsPermised(info.PermissionLevel)) {
                sender.SendMessage(ColorScheme.ERROR, "Error", "You do not have permission to do that"); 
                return true;
            }

            // Make sure required arguments are provided
            if (context.HasArgs(info.RequiredArgs)) {
                this.SendUsageMessage(sender);
            } else {
                // Now perform
                Perform(context);
            }
            return true;
        }

        /// <summary>
        /// Sends a usage message to sender
        /// </summary>
        /// <param name="sender">Sender of command</param>
        protected virtual void SendUsageMessage(ICommandSender sender) {
            sender.SendMessage(ColorScheme.ERROR, "Error", "Wrong usage! " + info.Usage);
        }

    }

    /// <summary>
    /// Holds info for a #BaseCommand
    /// </summary>
    public class CommandInfo {

        /// <summary>
        /// The permission level needed for command
        /// </summary>
        public int PermissionLevel { get; set; }

        /// <summary>
        /// Required amount of arguments needed
        /// </summary>
        public int RequiredArgs { get; set; }

        /// <summary>
        /// Command's usage
        /// </summary>
        public string Usage { get; set; }

        /// <summary>
        /// Constructs a CommandInfo with required arguments
        /// </summary>
        /// <param name="permissionLevel">Permission level for command</param>
        /// <param name="requiredArgs">Required amount of arguments needed for command</param>
        /// <param name="usage">Usage for command</param>
        public CommandInfo(int permissionLevel, int requiredArgs, string usage) {
            this.PermissionLevel = permissionLevel;
            this.RequiredArgs = requiredArgs;
            this.Usage = usage;
        }

        /// <summary>
        /// Constructs a CommandInfo with 0 required arguments
        /// </summary>
        /// <param name="permissionLevel">Permission level for command</param>
        /// <param name="usage">Usage for command</param>
        public CommandInfo(int permissionLevel, string usage) : this(permissionLevel, 0, usage) { }
    }
}
