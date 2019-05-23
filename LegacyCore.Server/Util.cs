using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegacyCore.Server {

    /// <summary>
    /// Utility class
    /// </summary>
    public class Util {

        // We don't want to initialize our utility class
        // as it just contains static methods anyways :)
        private Util() { }

        /// <summary>
        /// Checks whether given string can be considered a command
        /// </summary>
        /// <param name="command">Command to check for</param>
        /// <returns>True if given string is command</returns>
        public static bool IsCommand(string command) {
            return command.StartsWith("/") && command.Length > 1;
        }

        /// <summary>
        /// Takes a dynamic list and converts it to a string-list
        /// </summary>
        /// <param name="list">List to convert</param>
        /// <returns>Stringified list</returns>
        public static List<string> StringifyList(List<dynamic> list) {
            List<string> newList = new List<string>();
            foreach (dynamic element in list) {
                newList.Add(Convert.ToString(element));
            }
            return newList;
        }

    }
}
