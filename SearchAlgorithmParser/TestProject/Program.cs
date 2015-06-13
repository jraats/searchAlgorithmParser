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
            DFA<String, char> dfa = new DFA<String, char>(new char[] { 'a', 'b' });
            dfa.AddTransition("LR_0", "LR_1", 'a');
            dfa.AddTransition("LR_0", "LR_4", 'b');
            dfa.AddTransition("LR_1", "LR_8", 'a');
            dfa.AddTransition("LR_1", "LR_2", 'b');
            dfa.AddTransition("LR_2", "LR_5", 'a');
            dfa.AddTransition("LR_2", "LR_3", 'b');
            dfa.AddTransition("LR_3", "LR_3", 'a');
            dfa.AddTransition("LR_3", "LR_3", 'b');
            dfa.AddTransition("LR_4", "LR_5", 'a');
            dfa.AddTransition("LR_4", "LR_9", 'b');
            dfa.AddTransition("LR_5", "LR_6", 'a');
            dfa.AddTransition("LR_5", "LR_4", 'b');
            dfa.AddTransition("LR_6", "LR_9", 'a');
            dfa.AddTransition("LR_6", "LR_7", 'b');
            dfa.AddTransition("LR_7", "LR_10", 'a');
            dfa.AddTransition("LR_7", "LR_10", 'b');
            dfa.AddTransition("LR_8", "LR_8", 'a');
            dfa.AddTransition("LR_8", "LR_4", 'b');
            dfa.AddTransition("LR_9", "LR_9", 'a');
            dfa.AddTransition("LR_9", "LR_4", 'b');
            dfa.AddTransition("LR_10", "LR_10", 'a');
            dfa.AddTransition("LR_10", "LR_10", 'b');

            dfa.StartState = "LR_0";
            dfa.EndStates.Add("LR_3");
            dfa.EndStates.Add("LR_7");

            Console.WriteLine(dfa.ToString());
            Console.WriteLine("");

            NDFA<String, char> ndfa = dfa.reverse(dfa);

            Console.WriteLine(ndfa.ToString());
            Console.WriteLine("");
        }
    }
}
