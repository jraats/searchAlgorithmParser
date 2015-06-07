using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchAlgorithmParser
{
    public class Regram<T, S> : Grammar<T, S>
    {

        public Regram()
            : base()
        {
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
                this.states[from][symbol] = new List<T>();
            }

            this.states[from][symbol].Add(to);

        }

        public override bool Validate(S[] toBeVerified)
        {
            DFA<T, S> dfa = Converter<T, S>.ConvertToDFA(this);
            return dfa.Validate(toBeVerified);
        }

        public override Language<S> GetLanguage(int length)
        {
            DFA<T, S> dfa = Converter<T, S>.ConvertToDFA(this);
            return dfa.GetLanguage(length);
        }

        public override bool IsMachineValid()
        {
            return true;
        }
        

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            foreach (T fromState in this.states.Keys)
            {
                //This is a endstate
                if (this.EndStates.Contains(fromState))
                {
                    //If the from state contains no transitions
                    if (this.states[fromState].Keys.Count == 0)
                    {
                        //Ignore
                        continue;
                    }
                }

                builder.Append(fromState + " -> ");
                Dictionary<S, List<T>> newState = this.states[fromState];
                bool isFirst = true;
                foreach (S symbol in newState.Keys)
                {
                    foreach (T toState in newState[symbol])
                    {
                        if (!isFirst)
                            builder.Append(" | ");

                        isFirst = false;

                        //Don't add the endstate if it is the endstate
                        if (this.EndStates.Contains(toState))
                        {
                            builder.Append(symbol);

                            //If the to state contains any other transitions
                            if (this.states.ContainsKey(toState) &&  this.states[toState].Keys.Count > 0)
                            {
                                //Add that one to the states
                                builder.Append(" | " + symbol + toState);
                            }
                        }
                        else
                        {
                            builder.Append(symbol + "" + toState);
                        }
                    }
                }
                builder.Append("\n");
            }
            return builder.ToString();
        }
    }
}
