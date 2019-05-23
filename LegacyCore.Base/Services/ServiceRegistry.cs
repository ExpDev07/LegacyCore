using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegacyCore.Base.Services {

    /// <summary>
    /// A registry for services
    /// </summary>
    public class ServiceRegistry : List<IService> {

        /// <summary>
        /// Initializes all services
        /// </summary>
        public void Initialize() {
            foreach (IService service in this) service.Initialize();
        }

        public T First<T>() where T : class { return this.First(s => s is T) as T; }

        public IEnumerable<T> Where<T>() where T : class { return this.Where(s => s is T).Cast<T>(); }
    }
}
