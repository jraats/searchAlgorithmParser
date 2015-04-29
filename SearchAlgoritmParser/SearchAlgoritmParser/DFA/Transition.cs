using System;

namespace SearchAlgoritmParser.DFA
{
    public class Transition<T, S>  where T : System.IComparable where S : System.IComparable
    {

        public T fromState { get; set; }
        public S symbol { get; set; }
        public T toState { get; set; }

        public Transition(T fromOrTo, S s) : this(fromOrTo, s, fromOrTo)
        {
        }


        public Transition(T from, S s, T to)
        {
            this.fromState = from;
            this.symbol = s;
            this.toState = to;
        }

        public override bool Equals(object obj)
        {
            if ( obj == null )
            {
                return false;
            }
            else if ( obj is Transition<T, S> )
            {
                return this.fromState.Equals (((Transition<T, S>)obj).fromState) && this.toState.Equals (((Transition<T, S>)obj).toState) && this.symbol.Equals(((Transition<T, S>)obj).symbol);
            }
            return false;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = fromState.GetHashCode();
                hash = 31 * hash + symbol.GetHashCode();
                hash = 31 * hash + toState.GetHashCode();
                return hash;
            }
        }
     
        public int CompareTo(object obj) 
        {
            if (!(obj is Transition<T, S>))
            {
                return -1;
            }

            Transition<T, S> t = (Transition<T, S>)obj;

            int fromCmp = this.fromState.CompareTo(t.fromState);
            int symbolCmp = this.symbol.CompareTo(t.symbol); 
            int toCmp = this.toState.CompareTo(t.toState);
        
            return (fromCmp != 0 ? fromCmp : (symbolCmp != 0 ? symbolCmp : toCmp));
        }

        public override String ToString()
        {
           return "(" + this.fromState + ", " + this.symbol + ")" + "-->" +  this.toState;
        }
    }
}
