using System;
using System.Linq;

namespace Ex05_Pr10_Pairs_by_Difference
{
    // 100/100
    class Ex05_Pr10_Pairs_by_Differenceam
    {
        static void Main()
        {
            double[] arrNumbers = Console.ReadLine().Split(' ').Select(double.Parse).ToArray();
            double difference = double.Parse(Console.ReadLine());

            int counter = 0;

            for (int i = 0; i < arrNumbers.Length; i++)
            {
                double numForCheck = arrNumbers[i];

                for (int j = 0; j < arrNumbers.Length; j++)
                {
                    if (numForCheck == arrNumbers[j] + difference)
                    {
                        counter++;
                    }
                }
            }
            Console.WriteLine(counter);
        }
    }
}
