using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegacyCore.Server {

    /// <summary>
    /// Represents an object that may be assigned permissions
    /// </summary>
    public interface IPermissible {

        /// <summary>
        /// Entity's permission level
        /// </summary>
        int PermissionLevel { get; set;  }

        /// <summary>
        /// Checks whether entity is permised 
        /// </summary>
        /// <param name="level">Entity's permission level</param>
        /// <returns>True if entity is permised</returns>
        bool IsPermised(int level);

    }
}
