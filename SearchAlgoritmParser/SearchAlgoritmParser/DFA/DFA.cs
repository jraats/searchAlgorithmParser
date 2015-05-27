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
        protected Dictionary<T, HashSet<Transition<T,S>>> _transitions;
        protected HashSet<T> _states;
        protected T _startState;
        protected HashSet<T> _finalStates;
        protected HashSet<S> _symbols;
        protected T _currentState;

        // Or use a Map structure
        public Dictionary<T, HashSet<Transition<T,S>>> transitions {
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

        public T startState {
            get
            {
                return this._startState;
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
            this._transitions = new Dictionary<T, HashSet<Transition<T, S>>>();
            this._states = new HashSet<T>();
            this._finalStates = new HashSet<T>();
            this._symbols = symbols;
            this._currentState = default(T);
        }
    
        public virtual void AddTransition(Transition<T,S> t)
        {
            if(!_transitions.ContainsKey(t.fromState)) {
                _transitions.Add(t.fromState, new HashSet<Transition<T, S>>());
            }
            _transitions[t.fromState].Add(t);
            _states.Add(t.fromState);
            _states.Add(t.toState);        
        }
    
        public void AddStartState(T t)
        {
            // if already in states no problem because a Set will remove duplicates.
            _states.Add(t);
            _startState = t;

            if (this.currentState == null)
                this._currentState = t;
        }

        public void SetStartState(T t)
        {

        }

        public void AddFinalState(T t)
        {
            // if already in states no problem because a Set will remove duplicates.
            _states.Add(t);
            _finalStates.Add(t);        
        }

        public void printTransitions()
        {

            foreach (HashSet<Transition<T,S>> t in transitions.Values)
            {
                foreach(Transition<T,S> p in t)
                    Console.WriteLine(p);
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
                state = this.getToState(state, input[i]);
            }

            return this.finalStates.Contains(state);
        }
    
        public T getToState(T from, S symbol)
        {
            if (!transitions.ContainsKey(from))
                return default(T);

            foreach(Transition<T,S> s in transitions[from])
            {
                if(s.symbol.Equals(symbol))
                       return s.toState;
            }
            return default(T);
        }

        public HashSet<Transition<T,S>> getStates(T from)
        {
            if (!transitions.ContainsKey(from))
                return null;

            return transitions[from];
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
            foreach(HashSet<Transition<T,S>> transition in this.transitions.Values) {
                foreach(Transition<T,S> t in transition)
                    streamWriter.WriteLine(t.fromState.ToString() + " -> " + t.toState.ToString() + " [ label= \"" + t.symbol.ToString() + "\" ];");
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
