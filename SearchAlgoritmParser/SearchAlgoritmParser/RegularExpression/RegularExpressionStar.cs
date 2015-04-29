using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchAlgoritmParser.RegularExpression
{
    public class RegularExpressionStar : RegularExpressionLoop
    {
        public override int loopMin
        {
            get
            {
                return 0;
            }
        }
        public override int loopMax
        {
            get
            {
                return RegularExpressionLoop.Unlimited;
            }
        }

        public RegularExpressionStar(RegularExpressionFunctional block)
            : base(block)
        {

        }

        public override string ToString()
        {
            return String.Format("({0})*", this.block);
        }
    }
}
