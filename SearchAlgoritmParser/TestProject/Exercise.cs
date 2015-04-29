using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SearchAlgoritmParser.DFA;

namespace Test_applicatie
{
    public class Exercise
    {
        public static DFA<String, char> Exercise1()
        {
            char[] symbols = new char[] { 'a', 'b' };
            DFA<String, char> dfa = new DFA<string, char>(symbols);
            dfa.AddTransition(new Transition<string, char>("LR_0", 'a', "LR_1"));
            dfa.AddTransition(new Transition<string, char>("LR_0", 'b', "LR_4"));
            dfa.AddTransition(new Transition<string, char>("LR_1", 'a', "LR_8"));
            dfa.AddTransition(new Transition<string, char>("LR_1", 'b', "LR_2"));
            dfa.AddTransition(new Transition<string, char>("LR_2", 'a', "LR_5"));
            dfa.AddTransition(new Transition<string, char>("LR_2", 'b', "LR_3"));
            dfa.AddTransition(new Transition<string, char>("LR_3", 'a', "LR_3"));
            dfa.AddTransition(new Transition<string, char>("LR_3", 'b', "LR_3"));
            dfa.AddTransition(new Transition<string, char>("LR_4", 'a', "LR_5"));
            dfa.AddTransition(new Transition<string, char>("LR_4", 'b', "LR_9"));
            dfa.AddTransition(new Transition<string, char>("LR_5", 'a', "LR_6"));
            dfa.AddTransition(new Transition<string, char>("LR_5", 'b', "LR_4"));
            dfa.AddTransition(new Transition<string, char>("LR_6", 'a', "LR_9"));
            dfa.AddTransition(new Transition<string, char>("LR_6", 'b', "LR_7"));
            dfa.AddTransition(new Transition<string, char>("LR_7", 'a', "LR_10"));
            dfa.AddTransition(new Transition<string, char>("LR_7", 'b', "LR_10"));
            dfa.AddTransition(new Transition<string, char>("LR_8", 'a', "LR_8"));
            dfa.AddTransition(new Transition<string, char>("LR_8", 'b', "LR_4"));
            dfa.AddTransition(new Transition<string, char>("LR_9", 'a', "LR_9"));
            dfa.AddTransition(new Transition<string, char>("LR_9", 'b', "LR_4"));
            dfa.AddTransition(new Transition<string, char>("LR_10", 'a', "LR_10"));
            dfa.AddTransition(new Transition<string, char>("LR_10", 'b', "LR_10"));

            dfa.AddStartState("LR_0");
            dfa.AddFinalState("LR_3");
            dfa.AddFinalState("LR_7");

            return dfa;
        }

        public static DFA<String, char> Exercise2()
        {
            char[] symbols = new char[] { 'a', 'b' };
            DFA<String, char> dfa = new DFA<string, char>(symbols);
            dfa.AddTransition(new Transition<string, char>("LR_0", 'a', "LR_2"));
            dfa.AddTransition(new Transition<string, char>("LR_0", 'b', "LR_1"));
            dfa.AddTransition(new Transition<string, char>("LR_1", 'a', "LR_3"));
            dfa.AddTransition(new Transition<string, char>("LR_1", 'b', "LR_0"));
            dfa.AddTransition(new Transition<string, char>("LR_2", 'a', "LR_0"));
            dfa.AddTransition(new Transition<string, char>("LR_2", 'b', "LR_3"));
            dfa.AddTransition(new Transition<string, char>("LR_3", 'a', "LR_1"));
            dfa.AddTransition(new Transition<string, char>("LR_3", 'b', "LR_2"));
            
            dfa.AddStartState("LR_0");
            dfa.AddFinalState("LR_0");
            dfa.AddFinalState("LR_2");
            dfa.AddFinalState("LR_3");

            return dfa;
        }

        public static DFA<String, char> Exercise3()
        {
            char[] symbols = new char[] { 'a', 'b' };
            DFA<String, char> dfa = new DFA<string, char>(symbols);
            dfa.AddTransition(new Transition<string, char>("LR_0", 'a', "LR_2"));
            dfa.AddTransition(new Transition<string, char>("LR_0", 'b', "LR_1"));
            dfa.AddTransition(new Transition<string, char>("LR_1", 'a', "LR_1"));
            dfa.AddTransition(new Transition<string, char>("LR_1", 'b', "LR_0"));
            dfa.AddTransition(new Transition<string, char>("LR_2", 'a', "LR_3"));
            dfa.AddTransition(new Transition<string, char>("LR_2", 'b', "LR_1"));
            dfa.AddTransition(new Transition<string, char>("LR_3", 'a', "LR_3"));
            dfa.AddTransition(new Transition<string, char>("LR_3", 'b', "LR_4"));
            dfa.AddTransition(new Transition<string, char>("LR_4", 'a', "LR_2"));
            dfa.AddTransition(new Transition<string, char>("LR_4", 'b', "LR_0"));

            dfa.AddStartState("LR_0");
            dfa.AddFinalState("LR_4");

            return dfa;
        }

        public static DFA<String, char> Exercise4()
        {
            char[] symbols = new char[] { 'a', 'b' };
            DFA<String, char> dfa = new DFA<string, char>(symbols);
            dfa.AddTransition(new Transition<string, char>("LR_0", 'a', "LR_1"));
            dfa.AddTransition(new Transition<string, char>("LR_0", 'b', "LR_7"));
            dfa.AddTransition(new Transition<string, char>("LR_1", 'a', "LR_7"));
            dfa.AddTransition(new Transition<string, char>("LR_1", 'b', "LR_2"));
            dfa.AddTransition(new Transition<string, char>("LR_2", 'a', "LR_7"));
            dfa.AddTransition(new Transition<string, char>("LR_2", 'b', "LR_3"));
            dfa.AddTransition(new Transition<string, char>("LR_3", 'a', "LR_4"));
            dfa.AddTransition(new Transition<string, char>("LR_3", 'b', "LR_3"));
            dfa.AddTransition(new Transition<string, char>("LR_4", 'a', "LR_5"));
            dfa.AddTransition(new Transition<string, char>("LR_4", 'b', "LR_3"));
            dfa.AddTransition(new Transition<string, char>("LR_5", 'a', "LR_8"));
            dfa.AddTransition(new Transition<string, char>("LR_5", 'b', "LR_6"));
            dfa.AddTransition(new Transition<string, char>("LR_6", 'a', "LR_6"));
            dfa.AddTransition(new Transition<string, char>("LR_6", 'b', "LR_6"));
            dfa.AddTransition(new Transition<string, char>("LR_7", 'a', "LR_7"));
            dfa.AddTransition(new Transition<string, char>("LR_7", 'b', "LR_7"));
            dfa.AddTransition(new Transition<string, char>("LR_8", 'a', "LR_8"));
            dfa.AddTransition(new Transition<string, char>("LR_8", 'b', "LR_3"));

            dfa.AddStartState("LR_0");
            dfa.AddFinalState("LR_6");

            return dfa;
        }
    }
}
