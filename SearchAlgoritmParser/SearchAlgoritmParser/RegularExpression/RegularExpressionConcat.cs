using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchAlgoritmParser.RegularExpression
{
    public class RegularExpressionConcat : RegularExpressionFunctional
    {
        public RegularExpressionPart left { get; set; }
        public RegularExpressionPart right { get; set; }

        public RegularExpressionConcat(RegularExpressionPart left, RegularExpressionPart right)
        {
            this.left = left;
            this.right = right;
        }

        public override string ToString()
        {
            return String.Format("{0}{1}", this.left, this.right);
        }
    }
}
