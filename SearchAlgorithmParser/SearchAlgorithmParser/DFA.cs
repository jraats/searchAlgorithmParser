using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchAlgorithmParser
{
    public class DFA<T, S> : Machine<T, S>
    {
        private Dictionary<T, Dictionary<S, T>> states;
        private T Trap;
        private string Delta = "'delta.png'";
        private enum OperationType { AND, OR };

        public DFA(S[] alphabet)
            : base(alphabet)
        {
            this.states = new Dictionary<T, Dictionary<S, T>>();
        }

        public DFA(S[] alphabet, T trap)
            : base(alphabet)
        {
            this.states = new Dictionary<T, Dictionary<S, T>>();
            this.Trap = trap;
        }

        public override void AddTransition(T from, T to, S symbol)
        {
            if (!this.states.ContainsKey(from))
            {
                this.states.Add(from, new Dictionary<S, T>());
            }

            this.states[from].Add(symbol, to);
            
        }

        public override bool Validate(S[] toBeVerified)
        {
            T state = this.StartState;
            if (state == null)
            {
                throw new NoBeginStateException();
            }

            for (int i = 0; i < toBeVerified.Length; i++)
            {
                if (!this.states.ContainsKey(state))
                {
                    //Not possible?
                    return false;
                }

                Dictionary<S,T> toStates = this.states[state];
                if (!toStates.ContainsKey(toBeVerified[i]))
                {
                    //Not possible?
                    return false;
                }
                state = toStates[toBeVerified[i]];
            }

            return this.EndStates.Contains(state);
        }

        public override Language<S> GetLanguage(int length)
        {
            Language<S> lang = new Language<S>();
            T state = this.StartState;
            if (state == null)
            {
                throw new NoBeginStateException();
            }

            this.GetLanguage(length, new List<S>(), state, lang);

            return lang;
        }

        private void GetLanguage(int length, List<S> symbols, T state, Language<S> lang)
        {
            if (this.EndStates.Contains(state))
            {
                lang.AddWord(symbols.ToArray());
            }

            if (length == 0)
                return;
            
            if (!this.states.ContainsKey(state))
            {
                //Start state not found?
                return;
            }

            Dictionary<S, T> toStates = this.states[state];
            foreach (S key in toStates.Keys)
            {
                T newState = toStates[key];
                List<S> newSymbols = new List<S>(symbols);
                newSymbols.Add(key);
                this.GetLanguage(length - 1, newSymbols, newState, lang);
            }
        }

        public override bool IsMachineValid()
        {
            if (this.StartState != null && this.states.Count > 0 && this.Alphabet.Length > 0 && this.EndStates.Count > 0 && this.Trap != null)
            {
                // check if symbols are part of alphabet
                foreach (T fromState in this.states.Keys)
                {
                    foreach (S symbol in this.states[fromState].Keys)
                    {
                        if (!this.Alphabet.Contains(symbol)) return false;
                    }
                }
                return true;
            }
            else return false;
        }

        public override HashSet<T> GetStates()
        {
            return new HashSet<T>(this.states.Keys);
        }

        public Dictionary<S, T> GetStates(T state)
        {
            if (!this.states.ContainsKey(state))
                return null;

            return this.states[state];
        }

        public void MinimaliseDFA()
        {
            ToDFA(Reverse(ToDFA(Reverse(this))));
        }

        public void Or(DFA<T, S> dfa)
        {
            // CHECK FOR MACHINE COMPATIBILITY (LIKE APLHABET) ?
            MergeOperation(dfa, OperationType.OR);
        }

        public void And(DFA<T, S> dfa)
        {
            // CHECK FOR MACHINE COMPATIBILITY (LIKE APLHABET) ?
            MergeOperation(dfa, OperationType.AND);
        }

        private void MergeOperation(DFA<T, S> dfa, OperationType type)
        {
            HashSet<T> oldEndstates = new HashSet<T>(this.EndStates);
            Dictionary<T, Dictionary<S, T>> oldStates = new Dictionary<T, Dictionary<S, T>>(this.states);
            Dictionary<List<T>, Dictionary<S, List<T>>> newCombinedTransitions = new Dictionary<List<T>, Dictionary<S, List<T>>>();

            this.states = new Dictionary<T, Dictionary<S, T>>();
            this.EndStates.Clear();
            this.StartState = concatStates(new List<T>(new T[] { this.StartState, dfa.StartState }));

            foreach (T transitionFromState in oldStates.Keys)
            {
                foreach (T secondaryTransitionFromState in dfa.states.Keys)
                {
                    List<T> newFromStateSet = new List<T>();

                    newFromStateSet.Add(transitionFromState);
                    newFromStateSet.Add(secondaryTransitionFromState);
                    
                    switch(type)
                    {
                        case OperationType.AND:
                            if (oldEndstates.Contains(transitionFromState) && dfa.EndStates.Contains(secondaryTransitionFromState))
                            {
                                this.EndStates.Add(concatStates(new List<T>(new T[] { transitionFromState, secondaryTransitionFromState })));
                            }
                            break;
                        case OperationType.OR:
                            if (oldEndstates.Contains(transitionFromState) || dfa.EndStates.Contains(secondaryTransitionFromState))
                            {
                                this.EndStates.Add(concatStates(new List<T>(new T[] { transitionFromState, secondaryTransitionFromState })));
                            }
                            break;
                        default:
                            break;
                    }

                    if (!newCombinedTransitions.ContainsKey(newFromStateSet)) newCombinedTransitions.Add(newFromStateSet, new Dictionary<S, List<T>>());

                    foreach (S transitionSymbol in oldStates[transitionFromState].Keys)
                    {
                        List<T> newToStateSet = new List<T>();

                        newToStateSet.Add(oldStates[transitionFromState][transitionSymbol]);
                        newToStateSet.Add(dfa.states[secondaryTransitionFromState][transitionSymbol]);

                        if (!newCombinedTransitions[newFromStateSet].ContainsKey(transitionSymbol)) newCombinedTransitions[newFromStateSet].Add(transitionSymbol, new List<T>(newToStateSet));
                    }
                }
            }

            foreach (List<T> transitionFromState in newCombinedTransitions.Keys)
            {
                foreach (S transitionSymbol in newCombinedTransitions[transitionFromState].Keys)
                {
                    this.AddTransition(concatStates(transitionFromState), concatStates(newCombinedTransitions[transitionFromState][transitionSymbol]), transitionSymbol);
                }
            }
        }

        public void Not()
        {
            Dictionary<T, Dictionary<S, T>> oldStates = new Dictionary<T, Dictionary<S, T>>(this.states);
            HashSet<T> oldEndStates = new HashSet<T>(this.EndStates); 
            this.states.Clear();
            this.EndStates.Clear();

            foreach (T transitionFromState in oldStates.Keys)
            {
                if (!oldEndStates.Contains(transitionFromState) || transitionFromState.Equals(this.StartState)) this.EndStates.Add(transitionFromState);

                foreach (S transitionSymbol in oldStates[transitionFromState].Keys)
                {
                    this.AddTransition(transitionFromState, oldStates[transitionFromState][transitionSymbol], transitionSymbol);
                }
            }
        }

        private T concatStates(ICollection<T> states)
        {
            dynamic newState = null;
            foreach(T state in states)
            {
                newState += state;
            }
            return newState;
        }

        private DFA<T, S> ToDFA(NDFA<T, S> ndfa)
        {
            this.Alphabet = ndfa.Alphabet;
            this.states = new Dictionary<T, Dictionary<S, T>>();
            this.EndStates.Clear();

            Stack<SortedSet<T>> combinedStates = new Stack<SortedSet<T>>();
            Stack<SortedSet<T>> unprocessedStates = new Stack<SortedSet<T>>();

            // setting new combined start state and push it to unprocessed stack
            unprocessedStates.Push(new SortedSet<T>(ndfa.StartStates));
            this.StartState = concatStates(new SortedSet<T>(ndfa.StartStates));

            // combining and processing new states
            while (unprocessedStates.Count > 0)
            {
                Dictionary<S, SortedSet<T>> newStates = new Dictionary<S, SortedSet<T>>();
                SortedSet<T> unProcessedStateSet = unprocessedStates.Pop();

                foreach (T unprocessedState in unProcessedStateSet)
                {
                    foreach (S symbol in ndfa.GetStates(unprocessedState).Keys)
                    {
                        foreach (T toState in ndfa.GetStates(unprocessedState)[symbol])
                        {
                            if (!newStates.ContainsKey(symbol))
                            {
                                newStates.Add(symbol, new SortedSet<T>());
                            }
                            newStates[symbol].Add(toState);
                        }
                    }
                }

                combinedStates.Push(unProcessedStateSet);

                foreach (S symbol in newStates.Keys)
                {
                    AddTransition(concatStates(unProcessedStateSet), concatStates(newStates[symbol]), symbol);

                    bool isSetAlreadyProcessed = false;

                    // set new combined end state
                    foreach(T ndfaEndState in ndfa.EndStates)
                    {
                        if(newStates[symbol].Contains(ndfaEndState)) this.EndStates.Add(concatStates(newStates[symbol]));
                    }
                    // check if newfound combined state was previously found and processed
                    foreach (SortedSet<T> combinedState in combinedStates)
                    {
                        if (combinedState.SetEquals(newStates[symbol]))
                        {
                            isSetAlreadyProcessed = true;
                            break;
                        }
                    }
                    if (!isSetAlreadyProcessed)
                    {
                        foreach (SortedSet<T> unProcessedState in unprocessedStates)
                        {
                            if (unProcessedState.SetEquals(newStates[symbol]))
                            {
                                isSetAlreadyProcessed = true;
                                break;
                            }
                        }
                        // add newfound combined state to unprocessed stack
                        if (!isSetAlreadyProcessed) unprocessedStates.Push(newStates[symbol]);
                    }
                }
            }
             
            // adding trap for missing transitions
            bool isTrapPlaced = false;
            foreach (T transition in states.Keys)
            {
                foreach(S symbol in this.Alphabet)
                {
                    if(!states[transition].ContainsKey(symbol))
                    {
                        AddTransition(transition, Trap, symbol);
                        isTrapPlaced = true;
                    }
                }
            }
            if (isTrapPlaced)
            {
                foreach (S symbol in this.Alphabet)
                {
                    AddTransition(Trap, Trap, symbol);
                }
            }
            return this;
        }

        private NDFA<T, S> Reverse(DFA<T,S> dfa)
        {
            NDFA<T, S> ndfa = new NDFA<T, S>(dfa.Alphabet, default(S));

            foreach (T transitionFromState in dfa.states.Keys)
            {
                foreach (S transitionSymbol in dfa.states[transitionFromState].Keys)
                {
                    if (transitionFromState.Equals(dfa.StartState)) ndfa.AddEndState(transitionFromState);

                    if (dfa.EndStates.Contains(transitionFromState))
                    {
                        ndfa.StartState = transitionFromState;
                    }
                    ndfa.AddTransition(dfa.states[transitionFromState][transitionSymbol], transitionFromState, transitionSymbol);
                }
            }
            return ndfa;
        }

        public void MakeDotFile(String output)
        {
            FileStream fileStream =
                new FileStream(output, FileMode.Create, FileAccess.Write);
            StreamWriter streamWriter = new StreamWriter(fileStream);
            streamWriter.WriteLine(@"digraph finite_state_machine {");
            streamWriter.WriteLine("rankdir=LR;");
            streamWriter.WriteLine("size=\"8,5\"");
            streamWriter.WriteLine("node [shape = doublecircle];");
            foreach (T state in this.EndStates)
            {
                streamWriter.Write(" \"" + state.ToString() + "\"");
            }
            if (this.EndStates.Count > 0)
                streamWriter.Write(';');

            streamWriter.WriteLine();
            streamWriter.WriteLine("node [shape = circle];");
            foreach (T fromState in this.states.Keys)
            {
                Dictionary<S, T> newState = this.states[fromState];
                foreach (S symbol in newState.Keys)
                {
                    streamWriter.WriteLine("\"" + fromState.ToString() + "\" -> \"" + newState[symbol].ToString() + "\" [ label= \"" + symbol.ToString() + "\" ];");
                }
            }
            streamWriter.WriteLine("}");
            streamWriter.Close();
            fileStream.Close();
        }

        public void MakePngFile(String output)
        {
            Delta = output;
            MakeDotFile("temp.dot");
            Process process = new Process();
            process.StartInfo =
            new ProcessStartInfo(@".\libdata\dot.exe",
                "-Tpng .\\temp.dot -o \"" + output + "\"");
            process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            process.Start();
            process.WaitForExit();
            RemoveDotFile("temp.dot");

        }

        private void RemoveDotFile(String file)
        {
            File.Delete(file);
        }

        public override string ToString()
        {
            StringBuilder dfaString = new StringBuilder();
            dfaString.Append("M = ({");

            foreach (T state in this.states.Keys)
            {
                if (!this.states[state].Equals(this.states.Last().Value))
                {
                    dfaString.Append(state + ", ");
                }
                else
                {
                    dfaString.Append(state);
                }
            }

            dfaString.Append("}, {");

            foreach (S character in this.Alphabet)
            {
                if (!character.Equals(this.Alphabet.Last()))
                {
                    dfaString.Append(character + ", ");
                }
                else
                {
                    dfaString.Append(character);
                }
            }

            dfaString.Append("}, " + Delta + ", "+this.StartState+", {");

            foreach (T endState in this.EndStates)
            {
                if (!endState.Equals(this.EndStates.Last()))
                {
                    dfaString.Append(endState + ", ");
                }
                else
                {
                    dfaString.Append(endState);
                }
            }

            dfaString.Append("})");

            return dfaString.ToString();
        }
    }
}
