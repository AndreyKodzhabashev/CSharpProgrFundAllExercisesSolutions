using System;
using System.Linq;

namespace Ex05_Pr07_Max_Sequens_of_Increasing_Elements
{
    class Ex05_Pr07_Max_Sequens_of_Increasing_Elements
    {
        static void Main()
        {
            // 71/100
            int[] arrNums = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            int startPoint = arrNums[0];
            int length = 1;

            int bestLength = 0;
            int currentNum = arrNums[0];

            for (int i = 1; i < arrNums.Length; i++)
            {
                if (arrNums[i] != startPoint + 1)
                {
                    startPoint = arrNums[i];
                    length = 1;
                    continue;
                }

                if (arrNums[i] == startPoint + 1)
                {
                    length++;
                    startPoint++;

                    if (bestLength < length)
                    {
                        bestLength = length;
                        currentNum = startPoint;
                    }                    
                }
            }

            for (int i = currentNum - bestLength + 1; i <= currentNum; i++)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
        }
    }
}