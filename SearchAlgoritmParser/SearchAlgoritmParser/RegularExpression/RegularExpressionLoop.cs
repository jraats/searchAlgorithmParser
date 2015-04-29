using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchAlgoritmParser.RegularExpression
{
    public abstract class RegularExpressionLoop : RegularExpressionPart
    {
        public RegularExpressionFunctional block { get; set; }

        public abstract int loopMin { get; }
        public abstract int loopMax { get; }

        public RegularExpressionLoop(RegularExpressionFunctional block)
        {
            this.block = block;
        }
    }
}
