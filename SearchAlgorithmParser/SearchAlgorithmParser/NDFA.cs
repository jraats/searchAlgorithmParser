using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchAlgorithmParser
{
    public class NDFA<T, S> : Grammar<T, S>
    {
        private string Delta = "'delta.png'";

        public HashSet<T> StartStates;
        public static S Epsilon = default(S);

        public NDFA(S[] alphabet)
            : base(alphabet)
        {
            this.StartStates = new HashSet<T>();
        }

        public override T StartState
        {
            get
            {
                return base.StartState;
            }
            set
            {
                this.StartStates.Add(value);
                base.StartState = value;
            }
        }

        public void AddStartState(T state)
        {
            this.StartStates.Add(state);
        }

        public void AddTransition(T from, T to, S symbol)
        {
            if (!this.states.ContainsKey(from))
            {
                this.states.Add(from, new Dictionary<S, List<T>>());
            }
            if(!this.states[from].ContainsKey(symbol))
            {
                this.states[from].Add(symbol, new List<T>());
            }
            if (!this.states[from][symbol].Contains(to))
            {
                this.states[from][symbol].Add(to);
            }
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
            if (this.StartState != null && this.states.Count > 0 && this.Alphabet.Length > 0 && this.EndStates.Count > 0 && StartStates.Count > 0)
            {
                // check if symbols are part of alphabet
                foreach(T fromState in this.states.Keys)
                {
                    foreach(S symbol in this.states[fromState].Keys)
                    {
                        if (!this.Alphabet.Contains(symbol))
                        {
                            Console.WriteLine("NDFA not valid: Symbol not found in alphabet.");
                            return false;
                        }
                    }
                }
                Console.WriteLine("NDFA validated.");
                Console.WriteLine(this.ToString());
                return true;
            }
            else
            {
                Console.WriteLine("NDFA not valid: missing criticals.");
                return false;
            }
        }

        public void AddEndState(T state)
        {
            this.EndStates.Add(state);

            if (!this.states.ContainsKey(state))
            {
                this.states.Add(state, new Dictionary<S, List<T>>());
            }
        }

        public override string ToString()
        {
            StringBuilder ndfaString = new StringBuilder();
            ndfaString.Append("M = ({");

            foreach (T state in this.states.Keys)
            {
                if (!this.states[state].Equals(this.states.Last().Value))
                {
                    ndfaString.Append(state + ", ");
                }
                else
                {
                    ndfaString.Append(state + "}, {");
                }
            }

            foreach(S character in this.Alphabet)
            {
                if(!character.Equals(this.Alphabet.Last()))
                {
                    ndfaString.Append(character + ", ");
                }
                else
                {
                    ndfaString.Append(character + "}, ");
                }
            }

            ndfaString.Append(Delta + ", {");

            foreach (T startState in StartStates)
            {
                if (!startState.Equals(StartStates.Last()))
                {
                    ndfaString.Append(startState + ", ");
                }
                else
                {
                    ndfaString.Append(startState + "}, {");
                }
            }

            foreach (T endState in this.EndStates)
            {
                if (!endState.Equals(this.EndStates.Last()))
                {
                    ndfaString.Append(endState + ", ");
                }
                else
                {
                    ndfaString.Append(endState + "})");
                }
            }

            return ndfaString.ToString();
        }
    }
}
