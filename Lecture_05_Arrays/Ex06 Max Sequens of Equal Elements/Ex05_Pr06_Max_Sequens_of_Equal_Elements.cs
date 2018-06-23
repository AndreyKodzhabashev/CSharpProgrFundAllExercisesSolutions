using System;
using System.Linq;
using System.Text;

namespace Ex05_Pr06_Max_Sequens_of_Equal_Elements
{
    class Ex05_Pr06_Max_Sequens_of_Equal_Elements
    {
        // 100/100
        static void Main()
        {
            int[] arrNums = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            int startPoint = arrNums[0];
            int length = 1;

            int bestStart = 0;
            int bestLength = 1;
            for (int i = 1; i < arrNums.Length; i++)
            {
                if (startPoint != arrNums[i])
                {
                    startPoint = arrNums[i];
                    length = 1;
                    continue;
                }

                if (startPoint == arrNums[i])
                {
                    length++;

                    if (bestLength < length)
                    {
                        bestStart = arrNums[i];
                        bestLength = length;
                    }
                }
            }

            for (int i = 0; i < bestLength; i++)
            {

                Console.Write(bestStart + " ");
            }

        }
    }
}