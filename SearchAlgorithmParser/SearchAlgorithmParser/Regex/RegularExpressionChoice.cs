using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchAlgorithmParser.Regex
{
    public class RegularExpressionChoice<T> : RegularExpressionFunctional<T>
    {
        public RegularExpressionFunctional<T> choiceOne { get; set; }
        public RegularExpressionFunctional<T> choiceTwo { get; set; }

        public RegularExpressionChoice(RegularExpressionFunctional<T> choiceOne, RegularExpressionFunctional<T> choiceTwo)
        {
            this.choiceOne = choiceOne;
            this.choiceTwo = choiceTwo;
        }

        public override void Convert(iStateCreater<T> creater, T beginState, ref T endState, NDFA<T, char> ndfa)
        {
            T choiceOneBeginState = creater.Next();
            T choiceTwoBeginState = creater.Next();
            T choiceOneEndState = default(T);
            T choiceTwoEndState = default(T);

            //Create empty epsilon from begin to begin of the choices
            ndfa.AddTransition(beginState, choiceOneBeginState, ndfa.Epsilon);
            ndfa.AddTransition(beginState, choiceTwoBeginState, ndfa.Epsilon);

            choiceOne.Convert(creater, choiceOneBeginState, ref choiceOneEndState, ndfa);
            choiceTwo.Convert(creater, choiceTwoBeginState, ref choiceTwoEndState, ndfa);

            //Create empty epsilon from end of the coices to end state
            endState = creater.Next();
            ndfa.AddTransition(choiceOneEndState, endState, ndfa.Epsilon);
            ndfa.AddTransition(choiceTwoEndState, endState, ndfa.Epsilon);
        }

        public override string ToString()
        {
            return String.Format("({0}|{1})", this.choiceOne, this.choiceTwo);
        }
    }
}
