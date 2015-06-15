using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SearchAlgorithmParser.Regex;

namespace SearchAlgorithmParser
{
    public class Regex<T> : Machine<T, char>
    {
        public RegularExpressionPart<T> Root { get; set; }
        public iStateCreater<T> StateCreater { get; set; }

        public Regex(char[] alphabet, RegularExpressionPart<T> root, iStateCreater<T> stateCreater)
            : base(alphabet)
        {
            this.Root = root;
            this.StateCreater = stateCreater;
        }

        public override HashSet<T> GetStates()
        {
            throw new NotImplementedException();
        }

        public override void AddTransition(T from, T to, char symbol)
        {
            throw new NotImplementedException();
        }

        public override void Or()
        {
            throw new NotImplementedException();
        }

        public override void And()
        {
            throw new NotImplementedException();
        }

        public override void Not()
        {
            throw new NotImplementedException();
        }

        public override bool Validate(char[] toBeVerified)
        {
            NDFA<T, char> ndfa = SearchAlgorithmParser.Converter<T, char>.ConvertToNDFA(this, 'e');
            return ndfa.Validate(toBeVerified);
        }

        public override Language<char> GetLanguage(int length)
        {
            NDFA<T, char> ndfa = SearchAlgorithmParser.Converter<T, char>.ConvertToNDFA(this, 'e');
            return ndfa.GetLanguage(length);
        }

        public override bool IsMachineValid()
        {
            return true;
        }
        

        public override string ToString()
        {
            return this.Root.ToString();
        }
    }
}
