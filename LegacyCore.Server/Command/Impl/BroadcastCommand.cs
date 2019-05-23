using LegacyCore.Server.Chat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegacyCore.Server.Command.Impl {

    /// <summary>
    /// A command that makes you broadcast a message
    /// </summary>
    public class BroadcastCommand : BaseCommand {

        public BroadcastCommand() : base(new CommandInfo(0, "/broadcast <message>")) {}

        public override string Name => "broadcast";

        public override void Perform(CommandContext context) {
            // Bring together all arguments using StringBuilder
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < context.GetRawArgs().Count; i++) {
                sb.Append(context.Shift()).Append(" ");
            }

            // Broadcast message
            LegacyCoreServer.Instance.BroadcastMessage(ColorScheme.GOLD, "[Broadcast]", sb.ToString().Trim());
        }
    }
}
