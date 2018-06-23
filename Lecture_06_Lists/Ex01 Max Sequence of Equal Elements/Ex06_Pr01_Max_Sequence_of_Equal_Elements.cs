using System;
using System.Linq;
using System.Collections.Generic;

namespace Ex06_Pr01_Max_Sequence_of_Equal_Elements
{
    class Ex06_Pr01_Max_Sequence_of_Equal_Elements
    {
        static void Main()
        {
            // 85/100

            List<int> listNumbers = Console.ReadLine()
                 .Split(' ')
                 .Select(int.Parse)
                 .ToList();

            int checkedNumber = listNumbers[0];
            int counter = 1;

            int bestNumber = 0;
            int bestCounter = 0;

            for (int i = 1; i < listNumbers.Count; i++)
            {
                int currentNumber = listNumbers[i];

                if (checkedNumber == currentNumber)
                {
                    counter++;
                    if (counter > bestCounter)
                    {
                        bestCounter = counter;
                        bestNumber = currentNumber;
                    }
                }
                else
                {
                    checkedNumber = currentNumber;
                    counter = 1;
                }
            }
            for (int i = 0; i < bestCounter; i++)
            {
                Console.Write(bestNumber + " ");
            }
        }
    }
}
