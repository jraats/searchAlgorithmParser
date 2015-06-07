using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SearchAlgorithmParser;


namespace Test_applicatie
{
    class Program
    {
        static void Main(string[] args)
        {
            /*DFA<String, char> d = new DFA<String, char>();
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

            d.SetStartState("LR_0");
            d.AddFinalState("LR_3");
            d.AddFinalState("LR_7");

            Console.WriteLine(d.ToString());

            d.MakePngFile("test.png");

            Console.WriteLine(d.Validate("abbabba".ToArray()));
            Console.WriteLine(d.Validate("bbabaab".ToArray()));
            Console.WriteLine(d.Validate("aaaaabba".ToArray()));

            Language<char> lang = d.GetLanguage(5);
            foreach (char[] word in lang.Words)
            {
                Console.WriteLine(word);
            }*/

            /*Regram<String, char> gram = new Regram<string, char>();
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

            gram.SetStartState("LR_0");
            gram.AddFinalState("LR_3");
            gram.AddFinalState("LR_7");

            Console.WriteLine(gram.ToString());

            Console.WriteLine(gram.Validate("abbabba".ToArray()));
            Console.WriteLine(gram.Validate("bbabaab".ToArray()));
            Console.WriteLine(gram.Validate("aaaaabba".ToArray()));

            Language<char> lang = gram.GetLanguage(5);
            foreach (char[] word in lang.Words)
            {
                Console.WriteLine(word);
            }*/

            NDFA<String, char> ndfa = new NDFA<string, char>();
            ndfa.Alphabet = new HashSet<char>();
            ndfa.Alphabet.Add('a');
            ndfa.Alphabet.Add('b');
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

            ndfa.AddFinalState("7");
            ndfa.AddFinalState("9");
            ndfa.SetStartState("1");

            Console.WriteLine(ndfa.Validate("bbba".ToArray()));
            Console.WriteLine(ndfa.Validate("aabb".ToArray()));


            DFA<MultiState<String>, char> dfa = SearchAlgorithmParser.Converter<String, char>.ConvertToDFA(ndfa, new MultiStateViewConcat<String>(" ", "LEEG"));
            dfa.MakePngFile("test.png");
        }
    }
}
