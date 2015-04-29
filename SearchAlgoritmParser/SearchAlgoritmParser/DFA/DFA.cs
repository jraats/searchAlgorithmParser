using System;
using System.Collections.Generic;
using System.IO;
using System.Diagnostics;

namespace SearchAlgoritmParser.DFA
{
    public class DFA<T, S> : IDFA<T, S>
        where T : System.IComparable
        where S : System.IComparable
    {
        protected HashSet<Transition<T,S>> _transitions;
        protected HashSet<T> _states;
        protected HashSet<T> _startStates;
        protected HashSet<T> _finalStates;
        protected HashSet<S> _symbols;
        protected T _currentState;

        // Or use a Map structure
        public HashSet<Transition<T,S>> transitions {
            get
            {
                return this._transitions;
            }
        }

        public HashSet<T> states {
            get
            {
                return this._states;
            }
        }

        public HashSet<T> startStates {
            get
            {
                return this._startStates;
            }
        }

        public HashSet<T> finalStates {
            get
            {
                return this._finalStates;
            }
        }

        public HashSet<S> symbols {
            get
            {
                return this._symbols;
            }
        }

        public T currentState
        {
            get
            {
                return this._currentState;
            }
        }

        public DFA() : this(new HashSet<S>())
        {
        }
    
        public DFA(S[] s) : this(new HashSet<S>(s))
        {   
        }

        public DFA(HashSet<S> symbols)
        {
            this._transitions = new HashSet<Transition<T,S>>();
            this._states = new HashSet<T>();
            this._startStates = new HashSet<T>();
            this._finalStates = new HashSet<T>();
            this._symbols = symbols;
            this._currentState = default(T);
        }
    
        public virtual void AddTransition(Transition<T,S> t)
        {
            _transitions.Add(t);
            _states.Add(t.fromState);
            _states.Add(t.toState);        
        }
    
        public void AddStartState(T t)
        {
            // if already in states no problem because a Set will remove duplicates.
            _states.Add(t);
            _startStates.Add(t);

            if (this.currentState == null)
                this._currentState = t;
        }

        public void SetStartState(T t)
        {
            if (this.startStates.Contains(t))
            {
                this._currentState = t;
            }
        }

        public void AddFinalState(T t)
        {
            // if already in states no problem because a Set will remove duplicates.
            _states.Add(t);
            _finalStates.Add(t);        
        }

        public void printTransitions()
        {

            foreach (Transition<T,S> t in transitions)
            {
                Console.WriteLine(t);
            }
        }

        public Language<S> getLanguageByLength(int length)
        {
            Language<S> lang = new Language<S>();
            T state = this.currentState;
            if (state == null)
            {
                throw new NoStateDFAException();
            }

            if(length > 0) {
                HashSet<Transition<T,S>>.Enumerator e = this.getStates(state).GetEnumerator();
                while (e.MoveNext())
                {
                    Transition<T, S> transition = e.Current;
                    
                    List<S> symbols = new List<S>();
                    symbols.Add(transition.symbol);
                    this.getLanguageByLength(length - 1, symbols, transition.toState, lang);
                }
            }

            return lang;
        }

        private void getLanguageByLength(int left, List<S> symbols, T lastState, Language<S> lang)
        {
            if (this.finalStates.Contains(lastState))
            {
                lang.AddWord(symbols.ToArray());
            }

            if (left <= 0)
                return;

            HashSet<Transition<T, S>>.Enumerator e = this.getStates(lastState).GetEnumerator();
            while (e.MoveNext())
            {
                Transition<T, S> transition = e.Current;
                List<S> newSymbols = new List<S>(symbols);
                newSymbols.Add(transition.symbol);
                this.getLanguageByLength(left - 1, newSymbols, transition.toState, lang);
            }
        }


        public bool validate(S[] input)
        {
            T state = this.currentState;
            if (state == null)
            {
                throw new NoStateDFAException();
            }

            for (int i = 0; i < input.Length; i++)
            {
                HashSet<T> options = this.getToStates(state, input[i]);
                if (options.Count > 1)
                {
                    //Don't know how to handle multiple options
                    throw new Exception();
                }

                //No transitions available. Input invalid
                if (options.Count == 0)
                    return false;

                HashSet<T>.Enumerator e = options.GetEnumerator();
                e.MoveNext();
                state = e.Current;
            }

            return this.finalStates.Contains(state);
        }
    
        public HashSet<T> getToStates(T from, S symbol)
        {
           HashSet<T> reachable = new HashSet<T>();
           foreach (Transition<T,S> transaction in transitions)
           {
               if (transaction.fromState.Equals(from) && transaction.symbol.Equals(symbol))
               {
                   reachable.Add(transaction.toState);
               }
           }

           return reachable;
        
        }

        public HashSet<Transition<T,S>> getStates(T from)
        {
            HashSet<Transition<T,S>> reachable = new HashSet<Transition<T,S>>();
            foreach (Transition<T, S> transaction in transitions)
            {
                if (transaction.fromState.Equals(from))
                {
                    reachable.Add(transaction);
                }
            }

            return reachable;

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
            foreach(T state in this.finalStates) {
                streamWriter.Write(" " + state.ToString());
            }
            if(this.finalStates.Count > 0)
                streamWriter.Write(';');

            streamWriter.WriteLine();
            streamWriter.WriteLine("node [shape = circle];");
            foreach(Transition<T,S> transition in this.transitions) {
                streamWriter.WriteLine(transition.fromState.ToString() + " -> " + transition.toState.ToString() + " [ label= \"" + transition.symbol.ToString() + "\" ];");
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
    }
}
