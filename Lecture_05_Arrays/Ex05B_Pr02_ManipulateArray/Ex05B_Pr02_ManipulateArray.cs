using System;
using System.Linq;

namespace Ex05B_Pr02_ManipulateArray
{
    class Ex05B_Pr02_ManipulateArray
    {
        // 100/100
        static void Main()
        {
            string[] text = Console.ReadLine()
                .Split(' ')
                .ToArray();

            int commandCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < commandCount; i++)
            {
                string[] arrCommand = Console.ReadLine()
                    .Split(' ')
                    .ToArray();


                string currentCommand = arrCommand[0];

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
                        string textForRepl = arrCommand[2];

                        text[indexForReplace] = textForRepl;
                        break;

                }
            }

            Console.WriteLine(string.Join(", ", text));

        }
    }
}