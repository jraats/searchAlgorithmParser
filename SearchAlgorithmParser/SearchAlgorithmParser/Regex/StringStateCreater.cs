using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchAlgorithmParser.Regex
{
    public class StringStateCreater : iStateCreater<String>
    {
        private String prefix;
        private int nextNr;
        public StringStateCreater(String prefix)
        {
            this.prefix = prefix;
            this.nextNr = 0;
        }

        public String Next()
        {
            return prefix + (++nextNr);
        }

        public void Reset()
        {
            this.nextNr = 0;
        }
    }
}
