using LegacyCore.Server.Storage;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegacyCore.Server {

    /// <summary>
    /// An overview of banned people
    /// </summary>
    public class BanList : List<BanEntry> {

        /// <summary>
        /// Checks if id is banned
        /// </summary>
        /// <param name="id">Id to check for</param>
        /// <returns>True if is banned</returns>
        public bool IsBanned(string id) {
            return base.Find(entry => entry.Id == id) != null;
        }

        /// <summary>
        /// Adds a ban with from id
        /// </summary>
        /// <param name="id">Id to ban</param>
        public void AddBan(string id) {
            base.Add(new BanEntry(id));
        }

    }

    /// <summary>
    /// Represents an entry in the BanList
    /// </summary>
    public class BanEntry {

        public string Id { get; }

        public BanEntry(string id) {
            this.Id = id;
        }

    }

}
