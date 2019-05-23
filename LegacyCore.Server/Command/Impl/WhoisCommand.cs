using LegacyCore.Server.Chat;
using LegacyCore.Server.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegacyCore.Server.Command.Impl {

    /// <summary>
    /// A command to check who someone are
    /// </summary>
    public class WhoisCommand : BaseCommand {

        public WhoisCommand() : base(new CommandInfo(0, 1, "/whois [network id]")) { }

        public override string Name => "whois";

        public override void Perform(CommandContext context) {
            // Shift player
            LegacyPlayer target = context.ShiftPlayer();

            // Notify sender of information
            ICommandSender sender = context.Sender;
            sender.SendMessage(ChatColor.LIGHT_RED + "Checking: " + ChatColor.LIGHT_GREEN + target.GetName() + ChatColor.LIGHT_RED + ", their identifiers are:");
            sender.SendMessage(ChatColor.LIGHT_RED + "- network: " + ChatColor.LIGHT_GREEN + Convert.ToString(target.NetworkId));
            sender.SendMessage(ChatColor.LIGHT_RED + "- steam: " + ChatColor.LIGHT_GREEN + target.Id);
            sender.SendMessage(ChatColor.LIGHT_RED + "and more information:");
            sender.SendMessage(ChatColor.LIGHT_RED + "- ping: " + ChatColor.LIGHT_GREEN + target.GetCitizenPlayer().Ping);
        }
    }
}
