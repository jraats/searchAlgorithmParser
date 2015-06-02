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
            d.AddState("LR_0", "LR_1", 'a');
            d.AddState("LR_0", "LR_4", 'b');
            d.AddState("LR_1", "LR_8", 'a');
            d.AddState("LR_1", "LR_2", 'b');
            d.AddState("LR_2", "LR_5", 'a');
            d.AddState("LR_2", "LR_3", 'b');
            d.AddState("LR_3", "LR_3", 'a');
            d.AddState("LR_3", "LR_3", 'b');
            d.AddState("LR_4", "LR_5", 'a');
            d.AddState("LR_4", "LR_9", 'b');
            d.AddState("LR_5", "LR_6", 'a');
            d.AddState("LR_5", "LR_4", 'b');
            d.AddState("LR_6", "LR_9", 'a');
            d.AddState("LR_6", "LR_7", 'b');
            d.AddState("LR_7", "LR_10", 'a');
            d.AddState("LR_7", "LR_10", 'b');
            d.AddState("LR_8", "LR_8", 'a');
            d.AddState("LR_8", "LR_4", 'b');
            d.AddState("LR_9", "LR_9", 'a');
            d.AddState("LR_9", "LR_4", 'b');
            d.AddState("LR_10", "LR_10", 'a');
            d.AddState("LR_10", "LR_10", 'b');

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
        }
    }
}
