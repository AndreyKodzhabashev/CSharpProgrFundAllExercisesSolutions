using System;
using System.Linq;
using System.Collections.Generic;

namespace Ex06_Pr03_Search_for_a_Number
{
    class Ex06_Pr03_Search_for_a_Number
    {
        // 100/100
        static void Main()
        {
            List<int> listNumbers = Console.ReadLine()
                 .Split(' ')
                 .Select(int.Parse)
                 .ToList();

            int[] arrConditions = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            int numbersToTakeFromList = arrConditions[0];
            int numbersToBeDeleted = arrConditions[1];
            int numberToBeFound = arrConditions[2];

            List<int> takenNums = new List<int>();

            for (int i = 0; i < numbersToTakeFromList; i++)
            {
                int currentNum = listNumbers[i];
                takenNums.Add(currentNum);
            }

            takenNums.RemoveRange(0, numbersToBeDeleted);

            if (takenNums.Contains(numberToBeFound))
            {
                Console.WriteLine("YES!");
            }
            else
            {
                Console.WriteLine("NO!");
            }
        }
    }
}
