using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchAlgorithmParser
{
    public interface IMultiStateView<T>
    {
        String GetString(MultiState<T> state);
    }
}
