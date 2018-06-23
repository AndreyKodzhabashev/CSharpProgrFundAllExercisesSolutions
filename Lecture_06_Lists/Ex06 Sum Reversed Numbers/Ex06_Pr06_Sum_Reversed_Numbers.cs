using System;
using System.Linq;
using System.Collections.Generic;
using System.Numerics;

namespace Ex06_Pr06_Sum_Reversed_Numbers
{
    class Ex06_Pr06_Sum_Reversed_Numbers
    {
        // 100/100
        static void Main()
        {
            string[] listNumbersAsText = Console.ReadLine()
                .Split();

            double result = 0;

            foreach (var num in listNumbersAsText)
            {
                string curentNum = string.Join("", num.Reverse());

                result += double.Parse(curentNum);
            }

            Console.WriteLine(result);
        }
    }
}