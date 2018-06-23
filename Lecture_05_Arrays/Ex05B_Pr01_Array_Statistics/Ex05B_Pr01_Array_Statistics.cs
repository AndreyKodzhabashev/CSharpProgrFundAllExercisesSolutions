using System;
using System.Linq;

namespace Ex05B_Pr01_Array_Statistics
{
    class Ex05B_Pr01_Array_Statistics
    {
        // 100/100
        static void Main()
        {
            int[] arrNum = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int min = arrNum.Min();
            Console.WriteLine("Min = " + min);

            int max = arrNum.Max();
            Console.WriteLine("Max = " + max);

            int sum = arrNum.Sum();
            Console.WriteLine("Sum = " + sum);

            double average = arrNum.Average();
            Console.WriteLine("Average = " + average);

        }
    }
}