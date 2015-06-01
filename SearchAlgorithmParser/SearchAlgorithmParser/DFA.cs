using System;
using System.Collections.Generic;
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

        }

        public override bool Validate(S[] toBeVerified)
        {
            return false;
        }

        public override Language<S> GetLanguage(int length)
        {
            return new Language<S>();
        }

        public override bool IsMachineValid()
        {
            return true;
        }

        public override string ToString()
        {
            return "";
        }
    }
}
