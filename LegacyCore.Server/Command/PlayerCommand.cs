using LegacyCore.Server.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegacyCore.Server.Command {

    /// <summary>
    /// A command only players can use
    /// </summary>
    public abstract class PlayerCommand : BaseCommand {

        /// <summary>
        /// Constructs a player command
        /// </summary>
        /// <param name="info">Command's information</param>
        public PlayerCommand(CommandInfo info) : base(info) {

        }

        public override void Perform(CommandContext context) {
            // Is sender not a player?
            LegacyPlayer sender = context.GetPlayerSender();
            if (sender is null) {
                sender.SendMessage("Only players can use this command");
                return;
            }

            // Perform
            Perform(sender, context);
        }

        /// <summary>
        /// Performs command with player
        /// </summary>
        /// <param name="sender">Sender of command as player</param>
        /// <param name="context">Context of command</param>
        public abstract void Perform(LegacyPlayer sender, CommandContext context);
    }
}
