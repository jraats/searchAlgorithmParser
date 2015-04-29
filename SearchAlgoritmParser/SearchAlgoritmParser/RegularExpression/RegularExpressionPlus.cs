using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchAlgoritmParser.RegularExpression
{
    public class RegularExpressionPlus : RegularExpressionLoop
    {
        public override int loopMin
        {
            get
            {
                return 1;
            }
        }
        public override int loopMax
        {
            get
            {
                return RegularExpressionLoop.Unlimited;
            }
        }

        public RegularExpressionPlus(RegularExpressionFunctional block)
            : base(block)
        {

        }

        public override string ToString()
        {
            return String.Format("({0})+", this.block);
        }
    }
}
