using LegacyCore.Server.Chat;
using LegacyCore.Server.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegacyCore.Server.Command.Impl {

    /// <summary>
    /// A command to sync data to the database
    /// </summary>
    public class SaveAllCommand : BaseCommand {

        public SaveAllCommand() : base(new CommandInfo(0, "/saveall")) { }

        public override string Name => "saveall";

        public override void Perform(CommandContext context) {
            ICommandSender sender = context.Sender;
            sender.SendMessage(ChatColor.LIGHT_GREEN + "Saving data async...");

            // Throws error because of #GetCitizenPlayer() being called and no network id being available

            Task task = LegacyPlayers.Instance.ForceSaveAsync();
            task.ContinueWith(t => sender.SendMessage(ChatColor.LIGHT_GREEN + "Done saving."));
        }
    }
}
