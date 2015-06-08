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
            DFA<String, char> d = new DFA<String, char>(new char[] { 'a', 'b' });
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

            /*d.MakePngFile("test.png");

            Console.WriteLine(d.Validate("abbabba".ToArray()));
            Console.WriteLine(d.Validate("bbabaab".ToArray()));
            Console.WriteLine(d.Validate("aaaaabba".ToArray()));

            Language<char> lang = d.GetLanguage(5);
            foreach (char[] word in lang.Words)
            {
                Console.WriteLine(word);
            }*/

            Regram<String, char> gram = new Regram<string, char>(new char[] { 'a', 'b' });
            gram.AddTransition("LR_0", "LR_1", 'a');
            gram.AddTransition("LR_0", "LR_4", 'b');
            gram.AddTransition("LR_1", "LR_8", 'a');
            gram.AddTransition("LR_1", "LR_2", 'b');
            gram.AddTransition("LR_2", "LR_5", 'a');
            gram.AddTransition("LR_2", "LR_3", 'b');
            gram.AddTransition("LR_3", "LR_3", 'a');
            gram.AddTransition("LR_3", "LR_3", 'b');
            gram.AddTransition("LR_4", "LR_5", 'a');
            gram.AddTransition("LR_4", "LR_9", 'b');
            gram.AddTransition("LR_5", "LR_6", 'a');
            gram.AddTransition("LR_5", "LR_4", 'b');
            gram.AddTransition("LR_6", "LR_9", 'a');
            gram.AddTransition("LR_6", "LR_7", 'b');
            gram.AddTransition("LR_7", "LR_10", 'a');
            gram.AddTransition("LR_7", "LR_10", 'b');
            gram.AddTransition("LR_8", "LR_8", 'a');
            gram.AddTransition("LR_8", "LR_4", 'b');
            gram.AddTransition("LR_9", "LR_9", 'a');
            gram.AddTransition("LR_9", "LR_4", 'b');
            gram.AddTransition("LR_10", "LR_10", 'a');
            gram.AddTransition("LR_10", "LR_10", 'b');

            gram.StartState = "LR_0";
            gram.EndStates.Add("LR_3");
            gram.EndStates.Add("LR_7");

            Console.WriteLine(gram.ToString());
            Console.WriteLine("");

            /*Console.WriteLine(gram.Validate("abbabba".ToArray()));
            Console.WriteLine(gram.Validate("bbabaab".ToArray()));
            Console.WriteLine(gram.Validate("aaaaabba".ToArray()));

            Language<char> lang = gram.GetLanguage(5);
            foreach (char[] word in lang.Words)
            {
                Console.WriteLine(word);
            }*/

            /*NDFA<String, char> ndfa = new NDFA<string, char>(new char[]{ 'a', 'b' });
            ndfa.AddTransition("1", "3", 'a');
            ndfa.AddTransition("1", "2", 'b');
            ndfa.AddTransition("2", "3", 'b');
            ndfa.AddTransition("2", "5", 'b');
            ndfa.AddTransition("3", "4", 'a');
            ndfa.AddTransition("3", "4", 'b');
            ndfa.AddTransition("4", "6", 'a');
            ndfa.AddTransition("4", "2", 'b');
            ndfa.AddTransition("5", "7", 'a');
            ndfa.AddTransition("5", "8", 'a');
            ndfa.AddTransition("5", "10", 'b');
            ndfa.AddTransition("6", "9", 'b');
            ndfa.AddTransition("8", "9", 'b');
            ndfa.AddTransition("10", "8", 'a');
            ndfa.AddTransition("10", "9", 'a');
            ndfa.AddTransition("10", "9", 'b');

            ndfa.EndStates.Add("7");
            ndfa.EndStates.Add("9");
            ndfa.StartState = "1";

            Console.WriteLine(ndfa.Validate("bbba".ToArray()));
            Console.WriteLine(ndfa.Validate("aabb".ToArray()));


            DFA<MultiState<String>, char> dfa = SearchAlgorithmParser.Converter<String, char>.ConvertToDFA(ndfa, new MultiStateViewConcat<String>(" ", "LEEG"));
            dfa.MakePngFile("test.png");*/

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

            RegularExpressionPart<String> p1 = new RegularExpressionStar<String>(new RegularExpressionConcat<String>(new RegularExpressionTerminal<String>('a'), new RegularExpressionTerminal<String>('b')));
            RegularExpressionPart<String> p2 = new RegularExpressionPlus<String>(new RegularExpressionChoice<String>(new RegularExpressionTerminal<String>('b'), new RegularExpressionTerminal<String>('a')));

            RegularExpressionPart<String> p = new RegularExpressionConcat<String>(p1, p2);

            Regex<String> reg = new Regex<string>(new char[] { 'a', 'b' }, p, new StringStateCreater(""));

            Console.WriteLine(reg);

            /*String endStr = null;
            String startState = "LR_S";
            NDFA<String, char> ndfa = new NDFA<string, char>(new char[]{ 'a', 'b'}, 'e');
            p.Convert(new StringStateCreater("LR_"), startState, ref endStr, ndfa);
            ndfa.StartState = startState;*/
            Language<char> lang = reg.GetLanguage(5);
            foreach (char[] word in lang.Words)
            {
                Console.WriteLine(word);
            }

           // NDFA<String, char> ndfa = SearchAlgorithmParser.Converter<String, char>.ConvertToNDFA(reg, 'e');

            //DFA<MultiState<String>, char> dfa = SearchAlgorithmParser.Converter<String, char>.ConvertToDFA(ndfa, new MultiStateViewConcat<String>(" ", "empty"));
            //dfa.MakePngFile("regex.png");
            //ndfa.MakePngFile("test.png");
            


            Console.ReadLine();
        }
    }
}
