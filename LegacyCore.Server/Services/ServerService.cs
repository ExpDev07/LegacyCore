using LegacyCore.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegacyCore.Server.Services {

    public abstract class ServerService : IService {

        /// <summary>
        /// Initializes this service
        /// </summary>
        public abstract void Initialize();

        /// <summary>
        /// On character creation
        /// </summary>
        /// <param name="character">Character created</param>
        /// <returns>Task</returns>
        public virtual async Task<Object> OnCharacterCreate(Object character) => character;
    }
}
