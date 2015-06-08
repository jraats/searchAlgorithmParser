using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchAlgorithmParser.Regex
{
    public class RegularExpressionTerminal<T> : RegularExpressionFunctional<T>
    {
        public char terminal { get; set; }

        public RegularExpressionTerminal()
        {
        }

        public RegularExpressionTerminal(char terminal)
        {
            this.terminal = terminal;
        }

        public override void Convert(iStateCreater<T> creater, T beginState, ref T endState, NDFA<T, char> grammar)
        {
            endState = creater.Next();
            grammar.AddTransition(beginState, endState, terminal);
        }

        public override string ToString()
        {
            return terminal.ToString();
        }
    }
}
