using System;
using System.Linq;

namespace Ex05B_Pr03_SafeManipulation
{
    class Ex05B_Pr03_SafeManipulation
    {
        // 100/100
        static void Main()
        {
            string[] text = Console.ReadLine()
                .Split(' ')
                .ToArray();

            while(true)
            {
                string[] arrCommand = Console.ReadLine()
                    .Split(' ')
                    .ToArray();


                string currentCommand = arrCommand[0];

                if (currentCommand.Equals("END"))
                {
                    break;
                }

                switch (currentCommand)
                {
                    case "Reverse":

                        text = text.Reverse().ToArray();
                        break;

                    case "Distinct":

                        text = text.Distinct().ToArray();
                        break;

                    case "Replace":

                        int indexForReplace = int.Parse(arrCommand[1]);

                        if (indexForReplace < 0 || indexForReplace > text.Length - 1)
                        {
                            Console.WriteLine("Invalid input!");
                            continue;
                        }
                        string textForRepl = arrCommand[2];

                        text[indexForReplace] = textForRepl;
                        break;

                    default:
                        Console.WriteLine("Invalid input!");
                        break;

                }
            }

            Console.WriteLine(string.Join(", ", text));

        }
    }
}