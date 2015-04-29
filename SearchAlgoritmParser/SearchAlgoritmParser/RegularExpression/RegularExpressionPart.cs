using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchAlgoritmParser.RegularExpression
{
    public abstract class RegularExpressionPart
    {
        public const int Unlimited = int.MaxValue;
        public RegularExpressionPart()
        {

        }

        public abstract override string ToString();
    }
}
