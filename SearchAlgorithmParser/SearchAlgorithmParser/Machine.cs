using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchAlgorithmParser
{
    public abstract class Machine<T,S>
    {
        public HashSet<T> EndStates { private set; get; }
        public T StartState {private set; get; }

        public HashSet<S> Alphabet;

        public Machine() {
            this.EndStates = new HashSet<T>();
            this.Alphabet = new HashSet<S>();
        }

        public abstract bool Validate(S[] toBeVerified);
        public abstract Language<S> GetLanguage(int length);
        public abstract bool IsMachineValid();

        public virtual void SetStartState(T state)
        {
            this.StartState = state;
        }

        public void AddFinalState(T state)
        {
            EndStates.Add(state);
        }

        public void ConvertTo() {
            //How do we converts?
        }
    }
}
