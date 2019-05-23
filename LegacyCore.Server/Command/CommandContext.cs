using LegacyCore.Server.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegacyCore.Server.Command {

    /// <summary>
    /// A context for command
    /// </summary>
    public class CommandContext {

        private List<string> args;
        private int currentArg = 0;

        /// <summary>
        /// Tthe command executor
        /// </summary>
        public ICommandExecutor Executor { get; }

        /// <summary>
        /// Command's sender
        /// </summary>
        public ICommandSender Sender { get; }

        /// <summary>
        /// Creates a new command context object
        /// </summary>
        /// <param name="command">The command which was executed</param>
        /// <param name="args">The arguments passed to the command</param>
        public CommandContext(ICommandExecutor executor, ICommandSender sender, List<string> args) {
            this.Executor = executor;
            this.Sender = sender;
            this.args = args;
        }

        /// <summary>
        /// Gets the command sender as a player
        /// </summary>
        /// <returns>The command sender as player. Null if not player</returns>
        public LegacyPlayer GetPlayerSender() {
            ICommandSender sender = this.Sender;
            if (!typeof(LegacyPlayer).IsInstanceOfType(sender)) {
                return null;
            }
            return (LegacyPlayer)sender;
        }

        /// <summary>
        /// Checks if arguments passed surpases/equals amount
        /// </summary>
        /// <param name="amount">Amount to match</param>
        /// <returns>True if arguments passed matches amount</returns>
        public bool HasArgs(int amount) {
            return args.Count() >= amount;
        }

        /// <summary>
        /// Checks if at least one argument was passed
        /// </summary>
        /// <returns>True if 1 argument was passed</returns>
        public bool HasArgs() {
            return this.HasArgs(1);
        }

        /// <summary>
        /// Gets the raw arguments (unmodified from shifting)
        /// </summary>
        /// <returns>Raw arguments</returns>
        public List<string> GetRawArgs() {
            return args;
        }

        /// <summary>
        /// Arguments passed, removes any shifted arguments
        /// </summary>
        /// <returns></returns>
        private List<string> GetArgs() {
            return args.GetRange(currentArg, args.Count());
        }


        /// <summary>
        /// Gets the first (unshifted) argument from the arguments list
        /// </summary>
        /// <returns>First (unshifted) argument</returns>
        public string First() {
            return currentArg >= args.Count() ? null : args[currentArg];
        }

        /// <summary>
        /// Pops an argument off the start of the argument list and returns it
        /// </summary>
        /// <returns></returns>
        public string Shift() {
            if (currentArg == args.Count()) {
                return null;
            }

            return args[currentArg++];
        }

        /// <summary>
        /// Shifts an int
        /// </summary>
        /// <returns>Shifted int</returns>
        public int ShiftInt() {
            return int.Parse(this.Shift());
        }

        /// <summary>
        /// Shifts a long
        /// </summary>
        /// <returns>Shifted long</returns>
        public long ShiftLong() {
            return long.Parse(this.Shift());
        }

        /// <summary>
        /// Shifts a double
        /// </summary>
        /// <returns>Shifted double</returns>
        public double ShiftDouble() {
            return double.Parse(this.Shift());
        }

        /// <summary>
        /// Attempts to shift a player
        /// </summary>
        /// <returns>Shifted player</returns>
        public LegacyPlayer ShiftPlayer() {
            // TODO: Shift player
            return null;
        }

    }
}
