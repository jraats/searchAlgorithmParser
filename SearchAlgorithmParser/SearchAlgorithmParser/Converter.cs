using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SearchAlgorithmParser.Regex;

namespace SearchAlgorithmParser
{
    public class Converter<T, S>
    {
        //DFA --> NDFA
        public static NDFA<T, S> ConvertToNDFA(DFA<T, S> dfa, S epsilon)
        {
            NDFA<T, S> ndfa = new NDFA<T, S>(dfa.Alphabet, epsilon);

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
            ndfa.StartState = dfa.StartState;
            return ndfa;
        }

        //Regram --> NDFA
        public static NDFA<T, S> ConvertToNDFA(Regram<T, S> ndfa)
        {
            return null;
        }

        //Regex --> NDFA
        public static NDFA<T, char> ConvertToNDFA(Regex<T> regex, char epsilon)
        {
            regex.StateCreater.Reset();
            T endStr = default(T);
            T startState = regex.StateCreater.Next();

            NDFA<T, char> ndfa = new NDFA<T, char>(regex.Alphabet, epsilon);
            regex.Root.Convert(regex.StateCreater, startState, ref endStr, ndfa);
            ndfa.StartState = startState;
            ndfa.EndStates.Add(endStr);
            return ndfa;
        }

        //DFA --> Regram
        public static Regram<T, S> ConvertToRegram(DFA<T, S> dfa)
        {
            return null;
        }

        //NDFA --> Regram
        public static Regram<T, S> ConvertToRegram(NDFA<T, S> ndfa)
        {
            return null;
        }

        //NDFA --> DFA
        public static DFA<MultiState<T>, S> ConvertToDFA(NDFA<T, S> ndfa, IMultiStateView<T> view)
        {
            return Converter<T, S>.GrammarConvertToDFA(ndfa, new MultiState<T>(ndfa.StartStates, view), view, ndfa.Epsilon);
        }


        //Regram --> DFA
        public static DFA<MultiState<T>, S> ConvertToDFA(Regram<T, S> regram, IMultiStateView<T> view)
        {
            return Converter<T, S>.GrammarConvertToDFA(regram, new MultiState<T>(new T[] { regram.StartState }, view), view, default(S));
        }

        private static DFA<MultiState<T>, S> GrammarConvertToDFA(Grammar<T, S> grammar, MultiState<T> startState, IMultiStateView<T> view, S epsilon)
        {
            DFA<MultiState<T>, S> dfa = new DFA<MultiState<T>, S>(grammar.Alphabet);
            HashSet<MultiState<T>> todo = new HashSet<MultiState<T>>();
            HashSet<MultiState<T>> done = new HashSet<MultiState<T>>();

            MultiState<T> newStartState = new MultiState<T>(view);
            foreach (T subStartState in startState)
            {
                newStartState.Add(subStartState);

                HashSet<T> otherStates = getAllEpsilonStatesFromState(grammar, subStartState, epsilon);
                foreach (T otherState in otherStates)
                {
                    newStartState.Add(otherState);
                }
            }

            startState = newStartState;

            todo.Add(startState);

            //While there are items that needs to be progressed
            while (todo.Count > 0)
            {
                MultiState<T> from = todo.First<MultiState<T>>();

                Dictionary<S, MultiState<T>> states = new Dictionary<S, MultiState<T>>();

                foreach (T part in from)
                {
                    Dictionary<S, List<T>> partStates = grammar.GetStates(part);

                    foreach (S symbol in grammar.Alphabet)
                    {
                        if (!states.ContainsKey(symbol))
                        {
                            states.Add(symbol, new MultiState<T>(view));
                        }

                        if (partStates.ContainsKey(symbol))
                        {
                            List<T> partToStates = partStates[symbol];
                            foreach (T partToState in partToStates)
                            {
                                states[symbol].Add(partToState);
                                foreach (T epsilonState in getAllEpsilonStatesFromState(grammar, partToState, epsilon))
                                {
                                    states[symbol].Add(epsilonState);
                                }
                            }
                        }

                    }
                }

                foreach (S symbol in grammar.Alphabet)
                {
                    dfa.AddTransition(from, states[symbol], symbol);
                    if (!done.Contains(states[symbol]))
                    {
                        //If the to state is 'empty'
                        if (states[symbol].Count == 0)
                        {
                            //Add fail state
                            done.Add(states[symbol]);
                            foreach (S s in grammar.Alphabet)
                            {
                                dfa.AddTransition(states[symbol], s);
                            }
                        }
                        else
                        {
                            todo.Add(states[symbol]);
                        }
                    }
                }

                todo.Remove(from);
                done.Add(from);
            }

            foreach (MultiState<T> state in dfa.GetStates())
            {
                foreach (T partState in state)
                {
                    if (grammar.EndStates.Contains(partState))
                    {
                        dfa.EndStates.Add(state);
                    }
                }
            }
            dfa.StartState = startState;
            return dfa;
        }

        private static HashSet<T> getAllEpsilonStatesFromState(Grammar<T, S> grammar, T from, S epsilon)
        {
            Dictionary<S, List<T>> states = grammar.GetStates(from);
            HashSet<T> newStates = new HashSet<T>();

            if (states.ContainsKey(epsilon))
            {
                foreach (T otherState in states[epsilon])
                {
                    newStates.Add(otherState);
                    foreach(T subState in getAllEpsilonStatesFromState(grammar, otherState, epsilon)) {
                        newStates.Add(subState);
                    }
                }
            }

            return newStates;
        }
    }
}
