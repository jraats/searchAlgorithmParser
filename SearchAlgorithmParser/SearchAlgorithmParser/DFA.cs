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

        public DFA()
            : base()
        {
            this.states = new Dictionary<T, Dictionary<S, T>>();
        }

        public void AddState(T fromto, S symbol)
        {
            this.AddState(fromto, fromto, symbol);
        }

        public void AddState(T from, T to, S symbol)
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
            return true;
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
                streamWriter.Write(" " + state.ToString());
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
                    streamWriter.WriteLine(fromState.ToString() + " -> " + newState[symbol].ToString() + " [ label= \"" + symbol.ToString() + "\" ];");
                }
            }
            streamWriter.WriteLine("}");
            streamWriter.Close();
            fileStream.Close();
        }

        public void MakePngFile(String output)
        {
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
            StringBuilder builder = new StringBuilder();
            foreach (T fromState in this.states.Keys)
            {
                Dictionary<S, T> newState = this.states[fromState];
                foreach (S symbol in newState.Keys)
                {
                    builder.Append("(" + fromState + ", " + symbol + ")" + "-->" + newState[symbol] + ",\n");
                }
            }
            return builder.ToString();
        }
    }
}
