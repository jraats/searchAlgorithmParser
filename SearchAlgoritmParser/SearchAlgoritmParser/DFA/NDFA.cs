using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchAlgoritmParser.DFA
{
    public class NDFA<T, S> : DFA<T, S>
        where T : System.IComparable
        where S : System.IComparable
    {
        public NDFA() : this(new HashSet<S>())
        {
        }
    
        public NDFA(S[] s) : this(new HashSet<S>(s))
        {   
        }

        public NDFA(HashSet<S> symbols)
            : base(symbols)
        {
        }

        public override void AddTransition(Transition<T,S> t)
        {
            if(this.getToStates(t.fromState, t.symbol).Count != 0) {
                throw new TransitionAlreadyInUseNDFAException();
            }

            base.AddTransition(t);
        }
    }
}
