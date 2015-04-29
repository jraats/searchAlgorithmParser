using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchAlgoritmParser.RegularExpression
{
    public class RegularExpressionEmpty : RegularExpressionTerminal
    {
        public RegularExpressionEmpty()
        {
            this.terminal = '$';
        }
    }
}
