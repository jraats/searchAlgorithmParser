using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchAlgorithmParser
{
    public class Regram<T, S> : Grammar<T, S>
    {

        public Regram(S[] alphabet)
            : base(alphabet)
        {
        }

        public void AddState(T state)
        {
            if (!this.states.ContainsKey(state))
            {
                this.states.Add(state, new Dictionary<S, HashSet<T>>());
            }
        }

        public override void AddTransition(T from, T to, S symbol)
        {
            if (!this.states.ContainsKey(from))
            {
                this.states.Add(from, new Dictionary<S, HashSet<T>>());
            }

            if (!this.states[from].ContainsKey(symbol))
            {
                this.states[from][symbol] = new HashSet<T>();
            }

            this.states[from][symbol].Add(to);

        }

        public override void Or()
        {
            throw new NotImplementedException();
        }

        public override void And()
        {
            throw new NotImplementedException();
        }

        public override void Not()
        {
            throw new NotImplementedException();
        }

        public override bool Validate(S[] toBeVerified)
        {
            DFA<MultiState<T>, S> dfa = Converter<T, S>.ConvertToDFA(this, new MultiStateViewConcat<T>("", "_"));
            return dfa.Validate(toBeVerified);
        }

        public override Language<S> GetLanguage(int length)
        {
            DFA<MultiState<T>, S> dfa = Converter<T, S>.ConvertToDFA(this, new MultiStateViewConcat<T>("", "_"));
            return dfa.GetLanguage(length);
        }

        public override bool IsMachineValid()
        {
            return true;
        }
        

        public override string ToString()
        {
            StringBuilder regramString = new StringBuilder();
            regramString.Append("G = ({");

            foreach (T state in this.states.Keys)
            {
                if (!this.states[state].Equals(this.states.Last().Value))
                {
                    regramString.Append(state + ", ");
                }
                else
                {
                    regramString.Append(state + "}, {");
                }
            }

            foreach (S character in this.Alphabet)
            {
                if (!character.Equals(this.Alphabet.Last()))
                {
                    regramString.Append(character + ", ");
                }
                else
                {
                    regramString.Append(character + "}, {\n");
                }
            }

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

                regramString.Append(fromState + " -> ");
                Dictionary<S, HashSet<T>> newState = this.states[fromState];
                bool isFirst = true;

                if (this.StartState.Equals(fromState) && this.EndStates.Contains(this.StartState))
                {
                    isFirst = false;
                    regramString.Append('e');
                }

                foreach (S symbol in newState.Keys)
                {
                    foreach (T toState in newState[symbol])
                    {
                        if (!isFirst)
                            regramString.Append(" | ");

                        isFirst = false;

                        //Don't add the endstate if it is the endstate
                        if (this.EndStates.Contains(toState))
                        {
                            regramString.Append(symbol);

                            //If the to state contains any other transitions
                            if (this.states.ContainsKey(toState) && this.states[toState].Keys.Count > 0)
                            {
                                //Add that one to the states
                                regramString.Append(" | " + symbol + toState);
                            }
                        }
                        else
                        {
                            regramString.Append(symbol + "" + toState);
                        }
                    }
                }
                if (!this.states[fromState].Equals(this.states.Last().Value))
                {
                    regramString.Append(",\n");
                }
                else
                {
                    regramString.Append("\n");
                }
            }

            regramString.Append("}, "+this.StartState + " )");

            return regramString.ToString();
        }
    }
}
