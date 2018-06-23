using System;
using System.Linq;

namespace Ex05_Pr08_MostFrequentNumber
{
    class Ex05_Pr08_MostFrequentNumber
    {
        // 100/100
        static void Main(string[] args)
        {
            int[] arrNumbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            int numberForCheck = 0;
            int count;

            int bestCount = 0;
            int bestNumber = -1;

            for (int i = 0; i < arrNumbers.Length; i++)
            {
                numberForCheck = arrNumbers[i];
                count = 0;
                if (numberForCheck == bestNumber)
                {
                    continue;
                }
                for (int j = 0; j < arrNumbers.Length; j++)
                {
                    if (numberForCheck == arrNumbers[j])
                    {
                        count++;
                        if (count > bestCount)
                        {
                            bestCount = count;
                            bestNumber = numberForCheck;
                        }
                    }
                }
            }
            Console.WriteLine(bestNumber);
        }
    }
}
