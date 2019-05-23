using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegacyCore.Server.Chat {

    /// <summary>
    /// A collection of colors that can be used in chat
    /// </summary>
    public class ChatColor {

        // Colors
        public const string LIGHT_RED = "^1";
        public const string LIGHT_GREEN = "^2";
        public const string YELLOW = "^3";
        public const string DARK_BLUE = "^4";
        public const string LIGHT_BLUE = "^5";
        public const string PURPLE = "^6";
        public const string WHITE = "^7";
        public const string DARK_RED = "^8";
        public const string PINK = "^9";

        // Other formatting
        public const string BOLD = "^*";
        public const string UNDERLINE = "^_";
        public const string STRIKETHROUGH = "^~";
        public const string UNDERLINE_STRIKETHROUGH = "^=";
        public const string UNDERLINE_STRIKETHROUGH_BOLD = "*^=";

        // Reset
        public const string RESET = "^r";

        /// <summary>
        /// Strips string of all colors
        /// </summary>
        /// <param name="colored">Colored string to strip</param>
        /// <returns>String stripped of colors</returns>
        public static string StripColors(string colored) {
            colored = colored.Replace(LIGHT_RED, "");
            colored = colored.Replace(LIGHT_GREEN, "");
            colored = colored.Replace(YELLOW, "");
            colored = colored.Replace(DARK_BLUE, "");
            colored = colored.Replace(LIGHT_BLUE, "");
            colored = colored.Replace(PURPLE, "");
            colored = colored.Replace(WHITE, "");
            colored = colored.Replace(DARK_RED, "");
            colored = colored.Replace(PINK, "");
            colored = colored.Replace(BOLD, "");
            colored = colored.Replace(UNDERLINE, "");
            colored = colored.Replace(STRIKETHROUGH, "");
            colored = colored.Replace(UNDERLINE_STRIKETHROUGH, "");
            colored = colored.Replace(UNDERLINE_STRIKETHROUGH_BOLD, "");
            colored = colored.Replace(RESET, "");
            return colored;
        }

    }
}
