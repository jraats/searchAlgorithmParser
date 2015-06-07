using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchAlgorithmParser
{
    public class MultiStateViewConcat<T> : IMultiStateView<T>
    {
        public String Glue { get; set; }
        public String Empty { get; set; }
        public MultiStateViewConcat(String glue, String empty) {
            this.Glue = glue;
            this.Empty = empty;
        }

        public String GetString(MultiState<T> state)
        {
            if (state.Count == 0)
                return this.Empty;

            StringBuilder builder = new StringBuilder();
            bool isFirst = true;
            foreach (T subState in state)
            {
                if(!isFirst)
                    builder.Append(Glue);
                isFirst = false;
                builder.Append(subState);
            }
            return builder.ToString();
        }
    }
}
