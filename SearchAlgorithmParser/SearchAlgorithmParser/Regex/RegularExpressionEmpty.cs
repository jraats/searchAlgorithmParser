using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchAlgorithmParser.Regex
{
    public class RegularExpressionEmpty<T> : RegularExpressionTerminal<T>
    {
        public RegularExpressionEmpty()
        {
            this.terminal = '$';
        }
    }
}
