using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchAlgorithmParser
{
    public abstract class Machine<T, S>
    {
        public HashSet<T> EndStates { private set; get; }
        public virtual T StartState { set; get; }
        public S[] Alphabet { set; get; }

        public Machine(S[] alphabet)
        {
            this.EndStates = new HashSet<T>();
            this.Alphabet = alphabet;
        }

        public abstract bool Validate(S[] toBeVerified);
        public abstract Language<S> GetLanguage(int length);
        public abstract bool IsMachineValid();
        public abstract HashSet<T> GetStates();
        public abstract void Or();
        public abstract void And();
        public abstract void Not();

        public abstract void AddTransition(T from, T to, S symbol);
        public void AddTransition(T fromto, S symbol)
        {
            this.AddTransition(fromto, fromto, symbol);
        }
    }
}
