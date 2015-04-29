using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchAlgoritmParser.RegularExpression
{
    public class RegularExpressionTerminal : RegularExpressionFunctional
    {
        public char terminal { get; set; }

        public RegularExpressionTerminal()
        {
        }

        public RegularExpressionTerminal(char terminal)
        {
            this.terminal = terminal;
        }

        public override string ToString()
        {
            return terminal.ToString();
        }
    }
}
