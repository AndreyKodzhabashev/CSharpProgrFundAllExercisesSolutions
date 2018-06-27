using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace ExamPrepIII_Pr02_Command_Interpreter
{
    class ExamPrepIII_Pr02_Command_Interpreter
    {
        static void Main()
        {
            //65/100
            List<string> textForManipulations = Regex.Split(Console.ReadLine(), @"\s+").ToList();

            while (true)
            {
                string commandLine = Console.ReadLine();
                // break condition
                if (commandLine == "end")
                {
                    break;
                }

                //command split and check
                string[] arrCommands = commandLine.Split();

                string currentCommand = arrCommands[0];
                int index = 0;
                int count = 0;

                if (currentCommand == "reverse" || currentCommand == "sort")
                {
                    index = int.Parse(arrCommands[2]);
                    count = int.Parse(arrCommands[4]);
                }
                else
                {
                    count = int.Parse(arrCommands[1]);
                }


                if (index < 0 || index > textForManipulations.Count - 1 || count < 0)
                {
                    Console.WriteLine("Invalid input parameters.");
                    continue;
                }

                //manipulations
                switch (currentCommand)
                {
                    case "reverse":

                        List<string> start = textForManipulations.Take(index).ToList();
                        List<string> middle = textForManipulations.Skip(index).Take(count).Reverse().ToList();
                        List<string> end = textForManipulations.Skip(index + count).ToList();

                        List<string> temp = new List<string>();
                        start.AddRange(middle);
                        start.AddRange(end);

                        textForManipulations = start;

                        break;

                    case "sort":
                        List<string> start1 = textForManipulations.Take(index).ToList();
                        List<string> middle1 = textForManipulations.Skip(index).Take(count).ToList();

                        middle1.Sort();

                        List<string> end1 = textForManipulations.Skip(index + count).ToList();

                        List<string> temp1 = new List<string>();
                        start1.AddRange(middle1);
                        start1.AddRange(end1);

                        textForManipulations = start1;

                        break;

                    case "rollLeft":

                        //List<string> tempText = textForManipulations.Take(count).ToList();

                        //textForManipulations = textForManipulations.Skip(count).ToList();

                        //textForManipulations.AddRange(tempText);

                        for (int i = 0; i < count; i++)
                        {
                            string tempNum = textForManipulations[0];
                            for (int z = 0; z < textForManipulations.Count - 1; z++)
                            {
                                textForManipulations[z] = textForManipulations[z + 1];
                            }
                            textForManipulations[textForManipulations.Count - 1] = tempNum;
                        }


                        break;

                    case "rollRight":

                        //List<string> tempText1 = textForManipulations.Skip(textForManipulations.Count - count).ToList();

                        //textForManipulations = textForManipulations.Take(textForManipulations.Count - count).ToList();

                        //tempText1.AddRange(textForManipulations);

                        //textForManipulations = tempText1;
                        for (int i = 0; i < count; i++)
                        {
                            string tempNum = textForManipulations[textForManipulations.Count - 1];
                            for (int z = textForManipulations.Count - 1; z > 0; z--)
                            {
                                textForManipulations[z] = textForManipulations[z - 1];
                            }
                            textForManipulations[0] = tempNum;
                        }
                       

                        break;
                }
            }

            Console.WriteLine($"[{string.Join(", ", textForManipulations)}]");
        }
    }
}
