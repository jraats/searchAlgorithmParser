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
            // DFA 1
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
            Console.WriteLine("");

            //dfa.Not();
            //dfa.MakePngFile("dfaN.png");
            //Console.WriteLine(dfa.ToString());
            //Console.WriteLine("");
            //Console.WriteLine(dfa.IsMachineValid());
            //Console.WriteLine("");

            // DFA 2
            DFA<String, char> dfa2 = new DFA<String, char>(new char[] { 'a', 'b'}, "LR_X");
            dfa2.AddTransition("LR_0", "LR_1", 'a');
            dfa2.AddTransition("LR_0", "LR_2", 'b');
            dfa2.AddTransition("LR_1", "LR_0", 'a');
            dfa2.AddTransition("LR_1", "LR_1", 'b');
            dfa2.AddTransition("LR_2", "LR_0", 'a');
            dfa2.AddTransition("LR_2", "LR_2", 'b');

            dfa2.StartState = "LR_0";
            dfa2.EndStates.Add("LR_1");
            dfa2.EndStates.Add("LR_2");

            dfa2.Not();

            dfa2.MakePngFile("dfa2.png");
            Console.WriteLine(dfa2.ToString());
            Console.WriteLine("");

            // AND
            //dfa.And(dfa2);
            //dfa.MakePngFile("dfaAnddfa2.png");
            //Console.WriteLine(dfa.ToString());
            //Console.WriteLine("");

            // Minimalise
            //dfa.MinimaliseDFA();
            //dfa.MakePngFile("dfaAnddfa2M.png");
            //Console.WriteLine(dfa.ToString());

            //// OR
            dfa.Or(dfa2);
            dfa.MakePngFile("dfaOrdfa2.png");
            Console.WriteLine(dfa.ToString());
            Console.WriteLine("");

            //// Minimalise
            //dfa.MinimaliseDFA();
            //dfa.MakePngFile("dfaOrdfa2M.png");
            //Console.WriteLine(dfa.ToString());
        }
    }
}
