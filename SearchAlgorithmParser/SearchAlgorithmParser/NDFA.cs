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

        public void AddTransition(T fromto, S symbol)
        {
            this.AddTransition(fromto, fromto, symbol);
        }

        public void AddTransition(T from, T to, S symbol)
        {
            if (!this.states.ContainsKey(from))
            {
                this.states.Add(from, new Dictionary<S, List<T>>());
            }

            if (!this.states[from].ContainsKey(symbol))
            {
                this.states[from].Add(symbol, new List<T>());
            }

            this.states[from][symbol].Add(to);

        }

        public override bool Validate(S[] toBeVerified)
        {
            DFA<MultiState<T>, S> dfa = Converter<T, S>.ConvertToDFA(this, new MultiStateViewConcat<T>("", "_"));
            return dfa.Validate(toBeVerified);
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
