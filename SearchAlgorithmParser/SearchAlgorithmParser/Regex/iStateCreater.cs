using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchAlgorithmParser.Regex
{
    public interface iStateCreater<T>
    {
        T Next();
    }
}
