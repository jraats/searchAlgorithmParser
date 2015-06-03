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
            DFA<String, char> d = new DFA<String, char>();
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
            }

            NDFA<String, char> ndfa = new NDFA<string, char>();
            HashSet<char> alphabet = new HashSet<char>();
            alphabet.Add('b');
            alphabet.Add('a');
            ndfa.SetAlphabet(alphabet);
            ndfa.SetStartState("LR_0");
            ndfa.SetStartState("LR_2");
            ndfa.AddTransition("LR_0", 'a', "LR_1");
            ndfa.AddTransition("LR_0", 'b', "LR_2");
            ndfa.AddTransition("LR_1", 'a', "LR_4");
            ndfa.AddTransition("LR_1", 'a', "LR_2");
            ndfa.AddTransition("LR_2", 'b', "LR_1");
            ndfa.AddTransition("LR_2", 'a', "LR_3");
            ndfa.AddTransition("LR_3", 'b', "LR_4");
            ndfa.AddTransition("LR_4", 'a', "LR_5");
            ndfa.AddFinalState("LR_3");
            ndfa.AddFinalState("LR_5");
            ndfa.IsMachineValid();
        }
    }
}
