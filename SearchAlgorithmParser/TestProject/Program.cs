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
            DFA<String, char> dfa = new DFA<String, char>(new char[] { 'a', 'b' }, "LR_X");
            dfa.AddTransition("LR_0", "LR_1", 'a');
            dfa.AddTransition("LR_0", "LR_2", 'b');
            dfa.AddTransition("LR_1", "LR_0", 'a');
            dfa.AddTransition("LR_1", "LR_1", 'b');
            dfa.AddTransition("LR_2", "LR_0", 'a');
            dfa.AddTransition("LR_2", "LR_2", 'b');

            dfa.StartState = "LR_0";
            dfa.EndStates.Add("LR_1");
            dfa.EndStates.Add("LR_2");

            dfa.MakePngFile("dfa.png");
            Console.WriteLine(dfa.ToString());
            Console.WriteLine("");;

            dfa.MinimaliseDFA();
            dfa.MakePngFile("dfaM.png");
            Console.WriteLine(dfa.ToString());
        }
    }
}
