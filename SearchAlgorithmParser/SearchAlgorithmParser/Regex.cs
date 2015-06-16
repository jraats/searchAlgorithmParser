using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SearchAlgorithmParser.Regex;

namespace SearchAlgorithmParser
{
    public class Regex<T> : Machine<T, char>
    {
        public RegularExpressionPart<T> Root { get; set; }
        public iStateCreater<T> StateCreater { get; set; }

        public Regex(char[] alphabet, RegularExpressionPart<T> root, iStateCreater<T> stateCreater)
            : base(alphabet)
        {
            this.Root = root;
            this.StateCreater = stateCreater;
        }

        public Regex(char[] alphabet, string regex, iStateCreater<T> stateCreater)
            : base(alphabet)
        {
            this.Root = this.readString(regex);
            if (this.Root == null)
                throw new ArgumentException("Regex is not valid", "regex");
            this.StateCreater = stateCreater;
        }

        public override void AddState(T state)
        {
            throw new NotImplementedException();
        }

        public override HashSet<T> GetStates()
        {
            throw new NotImplementedException();
        }

        public override void AddTransition(T from, T to, char symbol)
        {
            throw new NotImplementedException();
        }

        public override bool Validate(char[] toBeVerified)
        {
            NDFA<T, char> ndfa = SearchAlgorithmParser.Converter<T, char>.ConvertToNDFA(this, 'e');
            return ndfa.Validate(toBeVerified);
        }

        public override Language<char> GetLanguage(int length)
        {
            NDFA<T, char> ndfa = SearchAlgorithmParser.Converter<T, char>.ConvertToNDFA(this, 'e');
            return ndfa.GetLanguage(length);
        }

        public override bool IsMachineValid()
        {
            return true;
        }

        private RegularExpressionPart<T> readString(String str)
        {
            return this.readString(str, 0, str.Length);
        }

        private RegularExpressionPart<T> readString(String str, int from, int to)
        {
            //RegularExpressionPart<char> part = null;
            Stack<RegularExpressionPart<T>> stack = new Stack<RegularExpressionPart<T>>();

            for (int iIndex = from; iIndex < to; iIndex++)
            {
                char oOperator = str[iIndex];
                switch (oOperator)
                {
                    case '(':
                        //Concat last two parts
                        if (stack.Count > 1)
                        {
                            RegularExpressionPart<T> pPart = stack.Pop();
                            RegularExpressionPart<T> pPart2 = stack.Pop();
                            stack.Push(new RegularExpressionConcat<T>(pPart2, pPart));
                        }

                        int subFrom = iIndex + 1;
                        int subEnd = iIndex + 2;
                        int recursiveNr = 1;
                        while (subEnd < to)
                        {
                            //Part in a part?
                            if (str[subEnd] == '(')
                            {
                                recursiveNr++;
                            }
                            //End subpart
                            else if (str[subEnd] == ')')
                            {
                                recursiveNr--;
                            }
                            if (recursiveNr == 0)
                                break;

                            subEnd++;
                        }
                        RegularExpressionPart<T> subpart = this.readString(str, subFrom, subEnd);
                        if (subpart == null)
                            return null;
                        stack.Push(subpart);
                        iIndex = subEnd;
                        break;
                    case ')':
                        break;
                    case '*':
                        RegularExpressionPart<T> lastPartStar = stack.Pop();
                        if (lastPartStar == null)
                            return null;
                        RegularExpressionFunctional<T> functionalStar = lastPartStar as RegularExpressionFunctional<T>;
                        stack.Push(new RegularExpressionStar<T>(functionalStar));
                        break;
                    case '+':
                        RegularExpressionPart<T> lastPartPlus = stack.Pop();
                        if (lastPartPlus == null)
                            return null;
                        RegularExpressionFunctional<T> functionalPlus = lastPartPlus as RegularExpressionFunctional<T>;
                        stack.Push(new RegularExpressionPlus<T>(functionalPlus));
                        break;
                    case '|':
                        //Concat last two parts
                        if (stack.Count > 1)
                        {
                            RegularExpressionPart<T> pPart = stack.Pop();
                            RegularExpressionPart<T> pPart2 = stack.Pop();
                            stack.Push(new RegularExpressionConcat<T>(pPart2, pPart));
                        }
                        if (stack.Count == 0)
                            return null;

                        int subFromOR = iIndex + 1;
                        int subEndOR = iIndex + 2;
                        int recursiveNrOR = 1;
                        while (subEndOR < to)
                        {
                            //Part in a part?
                            if (str[subEndOR] == '(')
                            {
                                recursiveNrOR++;
                            }
                            //End subpart
                            else if (str[subEndOR] == ')')
                            {
                                recursiveNrOR--;
                            }
                            //Extra or
                            else if (recursiveNrOR == 1 && str[subEndOR] == '|')
                            {
                                RegularExpressionPart<T> subpartORExtra = this.readString(str, subFromOR, subEndOR);
                                if (subpartORExtra == null)
                                    return null;
                                RegularExpressionFunctional<T> subpartOrExtraFunctional = subpartORExtra as RegularExpressionFunctional<T>;
                                RegularExpressionFunctional<T> previousPart = stack.Pop() as RegularExpressionFunctional<T>;
                                if (subpartOrExtraFunctional == null || previousPart == null)
                                    return null;


                                stack.Push(new RegularExpressionChoice<T>(previousPart, subpartOrExtraFunctional));
                                subFromOR = subEndOR + 1;
                            }

                            if (recursiveNrOR == 0)
                                break;

                            subEndOR++;
                        }
                        RegularExpressionPart<T> subpartOR = this.readString(str, subFromOR, subEndOR);
                        if (subpartOR == null)
                            return null;
                        RegularExpressionFunctional<T> subpartOrFunctional = subpartOR as RegularExpressionFunctional<T>;
                        RegularExpressionFunctional<T> previousPartOR = stack.Pop() as RegularExpressionFunctional<T>;
                        if (subpartOrFunctional == null || previousPartOR == null)
                            return null;


                        stack.Push(new RegularExpressionChoice<T>(previousPartOR, subpartOrFunctional));
                        iIndex = subEndOR;
                        break;

                    //Its a terminal
                    default:
                        //Concat last two parts
                        if (stack.Count > 1)
                        {
                            RegularExpressionPart<T> pPart = stack.Pop();
                            RegularExpressionPart<T> pPart2 = stack.Pop();
                            stack.Push(new RegularExpressionConcat<T>(pPart2, pPart));
                        }

                        stack.Push(new RegularExpressionTerminal<T>(oOperator));
                        break;
                }
            }

            //Concat everything
            while (stack.Count > 1)
            {
                //Concat last two parts
                RegularExpressionPart<T> pPart = stack.Pop();
                RegularExpressionPart<T> pPart2 = stack.Pop();
                stack.Push(new RegularExpressionConcat<T>(pPart2, pPart));
            }
            if (stack.Count == 0)
                return null;

            return stack.Pop();
        }
        

        public override string ToString()
        {
            return this.Root.ToString();
        }
    }
}
