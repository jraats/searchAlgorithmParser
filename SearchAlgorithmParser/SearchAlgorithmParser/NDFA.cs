using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchAlgorithmParser
{
    public class NDFA<T, S> : Grammar<T, S>
    {
        private string Delta = "'delta.png'";

        public HashSet<T> StartStates;
        public S Epsilon { set; get; }

        public NDFA(S[] alphabet, S epsilon)
            : base(alphabet)
        {
            this.StartStates = new HashSet<T>();
            this.Epsilon = epsilon;
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

        public override void AddTransition(T from, T to, S symbol)
        {
            if (!this.states.ContainsKey(from))
            {
                this.states.Add(from, new Dictionary<S, HashSet<T>>());
            }
            if(!this.states[from].ContainsKey(symbol))
            {
                this.states[from].Add(symbol, new HashSet<T>());
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
            DFA<MultiState<T>, S> dfa = Converter<T, S>.ConvertToDFA(this, new MultiStateViewConcat<T>("", "_"));
            return dfa.GetLanguage(length);
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
                        if (!this.Alphabet.Contains(symbol) && !symbol.Equals(this.Epsilon))
                        {
                            Console.WriteLine("NDFA not valid: Symbol not found in alphabet.");
                            return false;
                        }
                    }
                }
                Console.WriteLine("NDFA validated.");
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
                this.states.Add(state, new Dictionary<S, HashSet<T>>());
            }
        }

        public override void Or()
        {

        }

        public override void And()
        {

        }

        public override void Not()
        {
            Dictionary<T, Dictionary<S, HashSet<T>>> oldStates = new Dictionary<T, Dictionary<S, HashSet<T>>>(this.states);
            HashSet<T> oldEndStates = new HashSet<T>(this.EndStates);
            this.states.Clear();
            this.EndStates.Clear();

            foreach (T transitionFromState in oldStates.Keys)
            {
                if (!oldEndStates.Contains(transitionFromState) || transitionFromState.Equals(this.StartState))
                {
                    this.EndStates.Add(transitionFromState);
                }
                foreach (S transitionSymbol in oldStates[transitionFromState].Keys)
                {
                    foreach (T transitionToState in oldStates[transitionFromState][transitionSymbol])
                    {
                        this.AddTransition(transitionFromState, transitionToState, transitionSymbol);
                    }
                }
            }
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
                Dictionary<S, HashSet<T>> newState = this.states[fromState];
                foreach (S symbol in newState.Keys)
                {
                    foreach(T otherState in newState[symbol])
                        streamWriter.WriteLine("\"" + fromState.ToString() + "\" -> \"" + otherState.ToString() + "\" [ label= \"" + symbol.ToString() + "\" ];");
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
