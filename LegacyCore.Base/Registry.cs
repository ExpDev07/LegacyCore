using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegacyCore.Base {

    public abstract class Registry<TR> : Collection<TR> {

        public T First<T>() where T : class => this.First(s => s is T) as T;

        public IEnumerable<T> Where<T>() where T : class => this.Where(s => s is T).Cast<T>();
    }
}
