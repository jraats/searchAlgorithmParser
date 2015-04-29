using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchAlgoritmParser.DFA
{
    interface IDFA<T, S>
        where T : System.IComparable
        where S : System.IComparable
    {
        void AddTransition(Transition<T,S> t);
        void AddStartState(T t);
        void AddFinalState(T t);
        bool validate(S[] input);
    }
}
