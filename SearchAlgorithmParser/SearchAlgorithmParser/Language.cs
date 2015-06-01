using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchAlgorithmParser
{
    public class Language<S>
    {
        public HashSet<S[]> Words { private set; get; }

        public Language()
        {
            this.Words = new HashSet<S[]>();
        }

        public void AddWord(S[] word)
        {
            this.Words.Add(word);
        }
    }
}
