using System;
using System.Collections.Generic;
using System.Linq;

namespace Ex07B_Pr02_Odd_Filter
{
    class Ex07B_Pr02_Odd_Filter
    {
        // 100/100
        static void Main()
        {
            int[] arrNumbers = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .Where(x => x % 2 == 0)
                .ToArray();

            double average = arrNumbers.Average();

            for (int i = 0; i < arrNumbers.Length; i++)
            {
                if (arrNumbers[i] > average)
                {
                    arrNumbers[i]++;
                }
                else
                {
                    arrNumbers[i]--;
                }
            }

            Console.WriteLine(string.Join(" ", arrNumbers));
        }
    }
}
