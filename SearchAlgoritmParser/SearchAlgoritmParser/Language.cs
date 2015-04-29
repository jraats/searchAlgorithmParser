using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchAlgoritmParser
{
    public class Language<S>
        where S : System.IComparable
    {
        public HashSet<S[]> words { private set; get; }

        public Language()
        {
            this.words = new HashSet<S[]>();
        }

        public void AddWord(S[] word)
        {
            this.words.Add(word);
        }
    }
}
