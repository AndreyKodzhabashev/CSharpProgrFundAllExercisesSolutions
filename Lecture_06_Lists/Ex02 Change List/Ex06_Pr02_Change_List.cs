using System;
using System.Linq;
using System.Collections.Generic;

namespace Ex06_Pr02_Change_List
{
    class Ex06_Pr02_Change_List
    {
        // 100/100
        static void Main()
        {
            //TODO - read the input
            List<int> listNumbers = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToList();
            //DONE
            while (true)
            {
                //TODO - reading the command
                List<string> listCommand = Console.ReadLine()
                .Split(' ')
                .ToList();

                string command = listCommand[0];

                if (command.Equals("Delete"))
                {
                    int numberToDelete = int.Parse(listCommand[1]);

                    listNumbers.RemoveAll(x => x == numberToDelete);

                }
                else if (command.Equals("Insert"))
                {
                    int numberToInsert = int.Parse(listCommand[1]);
                    int positionForInsert = int.Parse(listCommand[2]);

                    listNumbers.Insert(positionForInsert, numberToInsert);
                }
                else if (command.Equals("Odd") || command.Equals("Even"))
                {
                    List<int> numsForPrint = new List<int>();

                    if (command.Equals("Odd"))
                    {

                        foreach (var num in listNumbers)
                        {
                            if (num % 2 == 0 == false)
                            {
                                numsForPrint.Add(num);
                            }
                        }
                    }
                    else
                    {

                        foreach (var num in listNumbers)
                        {
                            if (num % 2 == 0)
                            {
                                numsForPrint.Add(num);
                            }
                        }
                    }
                    Console.WriteLine(string.Join(" ", numsForPrint));
                    return;
                }
            }
        }
    }
}
