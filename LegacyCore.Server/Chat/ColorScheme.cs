using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegacyCore.Server.Chat {

    /// <summary>
    /// A collection of some RGB color schemes
    /// </summary>
    public class ColorScheme {

        // Colors
        public static readonly int[] BLACK = { 0, 0, 0 };
        public static readonly int[] WHITE = { 255, 255, 255 };
        public static readonly int[] RED = { 255, 0, 0 };
        public static readonly int[] YELLOW = { 255, 255, 0 };
        public static readonly int[] ORANGE = { 255, 127, 80 };
        public static readonly int[] GOLD = { 255, 215, 0 };
        public static readonly int[] DARK_BLUE = { 0, 0, 139 };
        public static readonly int[] LIGHT_BLUE = { 0, 191, 255 };
        public static readonly int[] GREEN = { 0, 255, 0 };


        // Other
        public static readonly int[] ERROR = { 255, 0, 0 };
        public static readonly int[] SUCCESS = { 0, 255, 0 };

    }
}
