using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchAlgorithmParser
{
    public class NDFA<T, S> : Grammar<T, S>
    {
        public HashSet<T> StartStates;

        public NDFA()
            : base()
        {
            this.StartStates = new HashSet<T>();
        }

        public override void SetStartState(T state)
        {
            this.StartStates.Add(state);
            base.SetStartState(state);
        }

        public void AddStartState(T state)
        {
            this.StartStates.Add(state);
        }

        public override bool Validate(S[] toBeVerified)
        {
            return false;
        }

        public override Language<S> GetLanguage(int length)
        {
            return new Language<S>();
        }

        public override bool IsMachineValid()
        {
            return true;
        }
        

        public override string ToString()
        {
            return "";
        }
    }
}
