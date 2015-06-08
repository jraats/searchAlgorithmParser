using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchAlgorithmParser.Regex
{
    public class RegularExpressionStar<T> : RegularExpressionLoop<T>
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
                return RegularExpressionLoop<T>.Unlimited;
            }
        }

        public RegularExpressionStar(RegularExpressionFunctional<T> block)
            : base(block)
        {

        }

        public override string ToString()
        {
            return String.Format("({0})*", this.block);
        }
    }
}
