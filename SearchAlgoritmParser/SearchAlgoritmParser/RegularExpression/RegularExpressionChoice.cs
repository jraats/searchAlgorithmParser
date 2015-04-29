using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchAlgoritmParser.RegularExpression
{
    public class RegularExpressionChoice : RegularExpressionFunctional
    {
        public RegularExpressionFunctional choiceOne { get; set; }
        public RegularExpressionFunctional choiceTwo { get; set; }

        public RegularExpressionChoice(RegularExpressionFunctional choiceOne, RegularExpressionFunctional choiceTwo)
        {
            this.choiceOne = choiceOne;
            this.choiceTwo = choiceTwo;
        }

        public override string ToString()
        {
            return String.Format("({0}|{1})", this.choiceOne, this.choiceTwo);
        }
    }
}
