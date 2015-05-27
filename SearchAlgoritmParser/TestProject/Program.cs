using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SearchAlgoritmParser;
using SearchAlgoritmParser.DFA;
using SearchAlgoritmParser.RegularExpression;


namespace Test_applicatie
{
    class Program
    {
        static void Main(string[] args)
        {
            /*DFA<String, char>[] exercises = new DFA<string, char>[] { Exercise.Exercise1(), Exercise.Exercise2(), Exercise.Exercise3(), Exercise.Exercise4() };

            char s = ' ';
            int exerciseId = -1;
            do
            {
                Console.WriteLine("Kies een oefening. 1 t/m " + exercises.Length);
                s = Convert.ToChar(Console.ReadLine());
                if (s >= '1' && s <= ('0' + exercises.Length))
                {
                    exerciseId = s - '0';
                }
            }
            while (exerciseId == -1);

            Console.WriteLine("Gekozen voor: " + exerciseId);
            Console.WriteLine("Exercise " + (exerciseId));

            Console.WriteLine("De diagrammen worden gemaakt.");
            exercises[exerciseId - 1].MakeDotFile("Exercise" + (exerciseId) + ".dot");
            exercises[exerciseId - 1].MakePngFile("Exercise" + (exerciseId) + ".png");


            String validate = String.Empty;
            do
            {
                Console.WriteLine("Vul een zin in om te valideren. Of leeg voor stoppen.");
                validate = Console.ReadLine();
                if (exercises[exerciseId - 1].validate(validate.ToCharArray()))
                {
                    Console.WriteLine("Deze is juist!");
                }
                else
                {
                    Console.WriteLine("Deze is onjuist");
                }
            } while (!validate.Equals(String.Empty));

            Console.WriteLine("Deze voldoen ook:");
            Language<char> language = exercises[exerciseId - 1].getLanguageByLength(5);
            foreach (char[] word in language.words)
            {
                string fullWord = new string(word);
                Console.WriteLine(fullWord);
            }*/

             RegularExpressionPart p1 = new RegularExpressionStar(new RegularExpressionConcat(new RegularExpressionTerminal('a'), new RegularExpressionTerminal('b')));
             RegularExpressionPart p2 = new RegularExpressionPlus(new RegularExpressionChoice(new RegularExpressionTerminal('b'), new RegularExpressionTerminal('a')));

             RegularExpressionPart p = new RegularExpressionConcat(p1, p2);

            Console.WriteLine(p);
            Console.ReadLine();
        }
    }
}
