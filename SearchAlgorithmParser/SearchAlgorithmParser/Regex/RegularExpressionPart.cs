using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchAlgorithmParser.Regex
{
    public abstract class RegularExpressionPart<T>
    {
        public RegularExpressionPart()
        {

        }

        public abstract void Convert(iStateCreater<T> creater, T beginState, ref T endState, NDFA<T, char> grammar);

        public abstract override string ToString();
    }
}
