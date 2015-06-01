using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchAlgorithmParser
{
    public abstract class Grammar<T, S> : Machine<T, S>
    {
        protected Dictionary<T, Dictionary<S, List<T>>> states;

        public Grammar() : base()
        {
            this.states = new Dictionary<T, Dictionary<S, List<T>>>();
        }
    }
}
