using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SearchAlgorithmParser;
using SearchAlgorithmParser.Regex;


namespace Test_applicatie
{
    class Program
    {
        static void Main(string[] args)
        {
         /*   DFA<String, char> d = new DFA<String, char>(new char[] { 'a', 'b' });
            d.AddTransition("LR_0", "LR_1", 'a');
            d.AddTransition("LR_0", "LR_4", 'b');
            d.AddTransition("LR_1", "LR_8", 'a');
            d.AddTransition("LR_1", "LR_2", 'b');
            d.AddTransition("LR_2", "LR_5", 'a');
            d.AddTransition("LR_2", "LR_3", 'b');
            d.AddTransition("LR_3", "LR_3", 'a');
            d.AddTransition("LR_3", "LR_3", 'b');
            d.AddTransition("LR_4", "LR_5", 'a');
            d.AddTransition("LR_4", "LR_9", 'b');
            d.AddTransition("LR_5", "LR_6", 'a');
            d.AddTransition("LR_5", "LR_4", 'b');
            d.AddTransition("LR_6", "LR_9", 'a');
            d.AddTransition("LR_6", "LR_7", 'b');
            d.AddTransition("LR_7", "LR_10", 'a');
            d.AddTransition("LR_7", "LR_10", 'b');
            d.AddTransition("LR_8", "LR_8", 'a');
            d.AddTransition("LR_8", "LR_4", 'b');
            d.AddTransition("LR_9", "LR_9", 'a');
            d.AddTransition("LR_9", "LR_4", 'b');
            d.AddTransition("LR_10", "LR_10", 'a');
            d.AddTransition("LR_10", "LR_10", 'b');

            d.StartState = "LR_0";
            d.EndStates.Add("LR_3");
            d.EndStates.Add("LR_7");

            Console.WriteLine(d.ToString());
            Console.WriteLine("");

            d.MinimaliseDFA();*/

            /*d.MakePngFile("test.png");

            Console.WriteLine(d.Validate("abbabba".ToArray()));
            Console.WriteLine(d.Validate("bbabaab".ToArray()));
            Console.WriteLine(d.Validate("aaaaabba".ToArray()));

            Language<char> lang = d.GetLanguage(5);
            foreach (char[] word in lang.Words)
            {
                Console.WriteLine(word);
            }*/

            /*Console.WriteLine(gram.Validate("abbabba".ToArray()));
            Console.WriteLine(gram.Validate("bbabaab".ToArray()));
            Console.WriteLine(gram.Validate("aaaaabba".ToArray()));

            Language<char> lang = gram.GetLanguage(5);
            foreach (char[] word in lang.Words)
            {
                Console.WriteLine(word);
            }*/


            /*NDFA<String, char> ndfa = new NDFA<string, char>(new char[] { 'a', 'b' }, '$');
            ndfa.StartState = "LR_0";
            ndfa.AddStartState("LR_2");
            ndfa.AddTransition("LR_0", "LR_1", 'a');
            ndfa.AddTransition("LR_0", "LR_2", 'b');
            ndfa.AddTransition("LR_1", "LR_4", 'a');
            ndfa.AddTransition("LR_1", "LR_2", ndfa.Epsilon);
            ndfa.AddTransition("LR_2", "LR_1", 'b');
            ndfa.AddTransition("LR_2", "LR_3", 'a');
            ndfa.AddTransition("LR_3", "LR_4", 'b');
            ndfa.AddTransition("LR_4", "LR_5", 'a');
            ndfa.AddEndState("LR_3");
            ndfa.AddEndState("LR_5");
            Console.WriteLine(ndfa.ToString());
            Console.WriteLine("");*/

          /*  RegularExpressionPart<String> p1 = new RegularExpressionStar<String>(new RegularExpressionConcat<String>(new RegularExpressionTerminal<String>('a'), new RegularExpressionTerminal<String>('b')));
            RegularExpressionPart<String> p2 = new RegularExpressionPlus<String>(new RegularExpressionChoice<String>(new RegularExpressionTerminal<String>('b'), new RegularExpressionTerminal<String>('a')));

            RegularExpressionPart<String> p = new RegularExpressionConcat<String>(p1, p2);

            Regex<String> reg = new Regex<string>(new char[] { 'a', 'b' }, p, new StringStateCreater(""));

            Console.WriteLine(reg);

            /*String endStr = null;
            String startState = "LR_S";
            NDFA<String, char> ndfa = new NDFA<string, char>(new char[]{ 'a', 'b'}, 'e');
            p.Convert(new StringStateCreater("LR_"), startState, ref endStr, ndfa);
            ndfa.StartState = startState;*/
            //Language<char> lang = reg.GetLanguage(5);
            /*foreach (char[] word in lang.Words)
            {
                Console.WriteLine(word);
            }*/

            /*Console.WriteLine(reg.Validate("".ToArray()));
            Console.WriteLine(reg.Validate("a".ToArray()));
            Console.WriteLine(reg.Validate("b".ToArray()));*/

            /*NDFA<String, char> ndfa = new NDFA<string, char>(new char[]{ 'a', 'b'}, 'e');
            ndfa.AddTransition("LR_0", "LR_1", 'a');
            ndfa.AddTransition("LR_0", "LR_2", 'b');
            ndfa.AddTransition("LR_0", "LR_3", 'b');
            ndfa.AddTransition("LR_1", "LR_1", 'a');
            ndfa.AddTransition("LR_1", "LR_5", 'a');
            ndfa.AddTransition("LR_1", "LR_3", 'e');
            ndfa.AddTransition("LR_2", "LR_4", 'a');
            ndfa.AddTransition("LR_2", "LR_3", 'b');
            ndfa.AddTransition("LR_2", "LR_1", 'b');
            ndfa.AddTransition("LR_3", "LR_7", 'a');
            ndfa.AddTransition("LR_3", "LR_6", 'b');
            ndfa.AddTransition("LR_4", "LR_6", 'a');
            ndfa.AddTransition("LR_4", "LR_1", 'b');
            ndfa.AddTransition("LR_5", "LR_2", 'a');
            ndfa.AddTransition("LR_5", "LR_6", 'a');
            ndfa.AddTransition("LR_5", "LR_4", 'b');
            ndfa.AddTransition("LR_6", "LR_7", 'a');
            ndfa.AddTransition("LR_6", "LR_7", 'b');
            ndfa.AddTransition("LR_7", "LR_7", 'a');
            ndfa.AddTransition("LR_7", "LR_7", 'b');
            ndfa.EndStates.Add("LR_6");
            //ndfa.EndStates.Add("LR_0");
            ndfa.StartState = "LR_0";

            ndfa.MakePngFile("dfa.png");

            Regram<MultiState<String>, char> regram = SearchAlgorithmParser.Converter<String, char>.ConvertToRegram(ndfa, new MultiStateViewConcat<String>(" ", "empty"));
            Console.WriteLine(regram);*/

            Regram<String, char> regram = new Regram<string, char>(new char[] { 'a', 'b' });
            regram.AddTransition("LR_0", "LR_1", 'a');
            regram.AddTransition("LR_0", "LR_2", 'a');
            regram.AddTransition("LR_1", "LR_3", 'b');
            regram.AddTransition("LR_2", "LR_2", 'a');
            regram.AddTransition("LR_2", "LR_4", 'b');
            regram.AddTransition("LR_3", "LR_0", 'b');
            regram.AddTransition("LR_4", "LR_5", 'a');
            regram.AddTransition("LR_4", "LR_6", 'a');
            regram.AddTransition("LR_5", "LR_6", 'b');

            regram.EndStates.Add("LR_6");
            regram.StartState = "LR_0";

            Console.WriteLine(regram);

            NDFA<String, char> ndfa = SearchAlgorithmParser.Converter<String, char>.ConvertToNDFA(regram, 'e');
            ndfa.MakePngFile("bla.png");

            //Console.ReadLine();
        }
    }
}
