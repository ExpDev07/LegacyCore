using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegacyCore.Server.Command {

    /// <summary>
    /// A simple executor for a command
    /// </summary>
    public interface ICommandExecutor {

        /// <summary>
        /// A command's name
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Called when command is executed
        /// </summary>
        /// <param name="context">Context of command</param>
        /// <returns>Success state of command</returns>
        bool Execute(CommandContext context);

    }
}
