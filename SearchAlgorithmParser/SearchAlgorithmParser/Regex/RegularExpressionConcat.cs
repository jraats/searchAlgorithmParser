using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchAlgorithmParser.Regex
{
    public class RegularExpressionConcat<T> : RegularExpressionFunctional<T>
    {
        public RegularExpressionPart<T> left { get; set; }
        public RegularExpressionPart<T> right { get; set; }

        public RegularExpressionConcat(RegularExpressionPart<T> left, RegularExpressionPart<T> right)
        {
            this.left = left;
            this.right = right;
        }

        public override void Convert(iStateCreater<T> creater, T beginState, ref T endState, NDFA<T, char> grammar)
        {
            T leftEndState = default(T);
            left.Convert(creater, beginState, ref leftEndState, grammar);
            right.Convert(creater, leftEndState, ref endState, grammar);
        }

        public override string ToString()
        {
            return String.Format("{0}{1}", this.left, this.right);
        }
    }
}
