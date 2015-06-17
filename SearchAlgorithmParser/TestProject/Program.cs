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
            new Program().hcVoorbeeld();
            new Program().minimalize();
            new Program().not();
            new Program().and();
            new Program().or();

            new Program().language();
        }

        public void language()
        {
            Regex<String> regex = new Regex<string>(new char[] { 'a', 'b' }, "a+(ab|ba)*bab", new StringStateCreater("LR_"));

            Console.WriteLine(regex.ToString());
            Console.WriteLine("");

            Language<char> lang = regex.GetLanguage(10);
            foreach (char[] word in lang.Words)
            {
                Console.WriteLine(word);
            }
        }

        public void minimalize()
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

            // Minimalise
            dfa.MinimaliseDFA();
            dfa.MakePngFile("dfaM.png");
            Console.WriteLine(dfa.ToString());
            Console.WriteLine("");
        }

        public void hcVoorbeeld()
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
            Console.WriteLine("");

            Regex<String> regex = new Regex<string>(new char[] { 'a', 'b' }, "a+(ab|ba)*bab", new StringStateCreater("LR_"));

            Console.WriteLine(regex.ToString());
            Console.WriteLine("");
        }

        public void and()
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
            Console.WriteLine("");

            // DFA 2
            DFA<String, char> dfa2 = new DFA<String, char>(dfa.Alphabet, "LR_X");
            dfa2.AddTransition("LR_0", "LR_1", 'a');
            dfa2.AddTransition("LR_0", "LR_X", 'b');
            dfa2.AddTransition("LR_1", "LR_X", 'a');
            dfa2.AddTransition("LR_1", "LR_2", 'b');
            dfa2.AddTransition("LR_2", "LR_3", 'a');
            dfa2.AddTransition("LR_2", "LR_X", 'b');
            dfa2.AddTransition("LR_3", "LR_3", 'a');
            dfa2.AddTransition("LR_3", "LR_3", 'b');
            dfa2.AddTransition("LR_X", "LR_X", 'a');
            dfa2.AddTransition("LR_X", "LR_X", 'b');

            dfa2.StartState = "LR_0";
            dfa2.EndStates.Add("LR_3");

            dfa2.MakePngFile("dfa2.png");
            Console.WriteLine(dfa2.ToString());
            Console.WriteLine("");

            // AND
            dfa.And(dfa2);
            dfa.MakePngFile("dfaAnddfa2.png");
            Console.WriteLine(dfa.ToString());
            Console.WriteLine("");
        }

        public void or()
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
            Console.WriteLine("");

            // DFA 2
            DFA<String, char> dfa2 = new DFA<String, char>(dfa.Alphabet, "LR_X");
            dfa2.AddTransition("LR_0", "LR_1", 'a');
            dfa2.AddTransition("LR_0", "LR_X", 'b');
            dfa2.AddTransition("LR_1", "LR_X", 'a');
            dfa2.AddTransition("LR_1", "LR_2", 'b');
            dfa2.AddTransition("LR_2", "LR_3", 'a');
            dfa2.AddTransition("LR_2", "LR_X", 'b');
            dfa2.AddTransition("LR_3", "LR_3", 'a');
            dfa2.AddTransition("LR_3", "LR_3", 'b');
            dfa2.AddTransition("LR_X", "LR_X", 'a');
            dfa2.AddTransition("LR_X", "LR_X", 'b');

            dfa2.StartState = "LR_0";
            dfa2.EndStates.Add("LR_3");

            dfa2.MakePngFile("dfa2.png");
            Console.WriteLine(dfa2.ToString());
            Console.WriteLine("");

            //// OR
            dfa.Or(dfa2);
            dfa.MakePngFile("dfaOrdfa2.png");
            Console.WriteLine(dfa.ToString());
            Console.WriteLine("");
        }

        public void not()
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
            dfa.MakePngFile("dfaN.png");
            Console.WriteLine(dfa.ToString());
            Console.WriteLine("");
        }

    }
}
