using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchAlgorithmParser.Regex
{
    public abstract class RegularExpressionLoop<T> : RegularExpressionPart<T>
    {
        public const int Unlimited = int.MaxValue;
        public RegularExpressionFunctional<T> block { get; set; }

        public abstract int loopMin { get; }
        public abstract int loopMax { get; }

        public RegularExpressionLoop(RegularExpressionFunctional<T> block)
        {
            this.block = block;
        }

        public override void Convert(iStateCreater<T> creater, T beginState, ref T endState, NDFA<T, char> ndfa)
        {
            endState = creater.Next();

            if (loopMin == 0)
            {
                ndfa.AddTransition(beginState, endState, ndfa.Epsilon);
            }

            T beginLoopState = creater.Next();
            T endLoopState = default(T);

            this.block.Convert(creater, beginLoopState, ref endLoopState, ndfa);

            //Epsilon from start to start loop
            ndfa.AddTransition(beginState, beginLoopState, ndfa.Epsilon);
            //Epsilon from end loop to start loop
            ndfa.AddTransition(endLoopState, beginLoopState, ndfa.Epsilon);
            //Epsilon from end loop to end state
            ndfa.AddTransition(endLoopState, endState, ndfa.Epsilon);
        }
    }
}
