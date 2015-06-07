using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchAlgorithmParser
{
    public class Converter<T, S>
    {
        public static NDFA<T, S> ConvertToNDFA(DFA<T, S> dfa)
        {
            NDFA<T, S> ndfa = new NDFA<T, S>();

            foreach (T fromState in dfa.GetStates()) {
                Dictionary<S, T> states = dfa.GetStates(fromState);
                foreach (S key in states.Keys)
                {
                    ndfa.AddTransition(fromState, states[key],  key);
                }
            }
            
            foreach (T endstate in dfa.EndStates)
            {
                ndfa.EndStates.Add(endstate);
            }
            ndfa.SetStartState(dfa.StartState);
            return ndfa;
        }

        public static DFA<MultiState<T>, S> ConvertToDFA(NDFA<T, S> ndfa, IMultiStateView<T> view)
        {
            DFA<MultiState<T>, S> dfa = new DFA<MultiState<T>, S>();
            HashSet<MultiState<T>> todo = new HashSet<MultiState<T>>();
            HashSet<MultiState<T>> done = new HashSet<MultiState<T>>();
            //Add the start states to the todo list
            MultiState<T> startState = new MultiState<T>(ndfa.StartStates, view);
            todo.Add(startState);

            //While there are items that needs to be progressed
            while (todo.Count > 0)
            {
                MultiState<T> from = todo.First<MultiState<T>>();

                Dictionary<S, MultiState<T>> states = new Dictionary<S,MultiState<T>>();

                foreach (T part in from)
                {
                    Dictionary<S, List<T>> partStates = ndfa.GetStates(part);
                    
                    foreach (S symbol in ndfa.Alphabet)
                    {
                        if (!states.ContainsKey(symbol))
                        {
                            states.Add(symbol, new MultiState<T>(view));
                        }

                        if (partStates.ContainsKey(symbol))
                        {
                            List<T> partToStates = partStates[symbol];
                            foreach(T partToState in partToStates) {
                                states[symbol].Add(partToState);
                            }
                        }

                    }
                }

                foreach(S symbol in ndfa.Alphabet)
                {
                    dfa.AddTransition(from, states[symbol], symbol);
                    if (!done.Contains(states[symbol]))
                    {
                        //If the to state is 'empty'
                        if (states[symbol].Count == 0)
                        {
                            //Add fail state
                            done.Add(states[symbol]);
                            foreach (S s in ndfa.Alphabet)
                            {
                                dfa.AddTransition(states[symbol], s);
                            }
                        }
                        else
                        {
                            if (!done.Contains(states[symbol]))
                            {
                                todo.Add(states[symbol]);
                            }
                        }
                    }
                    else
                    {
                        
                    }

                }

                todo.Remove(from);
                done.Add(from);
            }

            foreach (MultiState<T> state in dfa.GetStates())
            {
                foreach (T partState in state)
                {
                    if (ndfa.EndStates.Contains(partState))
                    {
                        dfa.EndStates.Add(state);
                    }
                }
            }
            dfa.SetStartState(startState);


            return dfa;
        }

        public static DFA<T, S> ConvertToDFA(Regram<T, S> regram)
        {
            DFA<T, S> dfa = new DFA<T, S>();

            return dfa;
        }
    }
}
