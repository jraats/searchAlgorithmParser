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
        public static char Epsilon = '$';

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
            if (base.StartState != null && base.states.Count > 0 && base.Alphabet.Count > 0 && base.EndStates.Count > 0 && StartStates.Count > 0)
            {
                // check if symbols are part of alphabet
                foreach(T fromState in base.states.Keys)
                {
                    foreach(S symbol in base.states[fromState].Keys)
                    {
                        if (!base.Alphabet.Contains(symbol))
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

        public override void AddFinalState(T state)
        {
            base.AddFinalState(state);

            if (!this.states.ContainsKey(state))
            {
                this.states.Add(state, new Dictionary<S, List<T>>());
            }
        }

        public override string ToString()
        {
            StringBuilder ndfaString = new StringBuilder();
            ndfaString.Append("M = ({");

            foreach (T state in base.states.Keys)
            {
                if (!base.states[state].Equals(base.states.Last().Value))
                {
                    ndfaString.Append(state + ", ");
                }
                else
                {
                    ndfaString.Append(state + "}, {");
                }
            }

            foreach(S character in base.Alphabet)
            {
                if(!character.Equals(Alphabet.Last()))
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

            foreach (T endState in EndStates)
            {
                if (!endState.Equals(EndStates.Last()))
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
