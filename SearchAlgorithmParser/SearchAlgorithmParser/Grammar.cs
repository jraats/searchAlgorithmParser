using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchAlgorithmParser
{
    public abstract class Grammar<T, S> : Machine<T, S>
    {
        protected Dictionary<T, Dictionary<S, HashSet<T>>> states;

        public Grammar(S[] alphabet)
            : base(alphabet)
        {
            this.states = new Dictionary<T, Dictionary<S, HashSet<T>>>();
        }

        public override HashSet<T> GetStates()
        {
            return new HashSet<T>(states.Keys);
        }

        public Dictionary<S, HashSet<T>> GetStates(T state)
        {
            if (!this.states.ContainsKey(state))
                return new Dictionary<S,HashSet<T>>();

            return this.states[state];
        }
    }
}
