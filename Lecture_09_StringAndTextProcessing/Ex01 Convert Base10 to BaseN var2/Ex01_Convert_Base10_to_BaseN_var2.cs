using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace Ex01_Convert_Base10_to_BaseN_var2
{
    class Ex01_Convert_Base10_to_BaseN_var2
    {
        // 100/100
        static void Main()
        {
            //StringBuilder sb = new StringBuilder();
            Stack<BigInteger> result = new Stack<BigInteger>();

            string[] input = Console.ReadLine()
                .Split()
                .ToArray();

            int @base = int.Parse(input[0]);
            BigInteger number = BigInteger.Parse(input[1]);


            BigInteger rem = 0;
            while (number > 0)
            {
                rem = number % @base;
                //sb.Append(rem);
                result.Push(rem);
                number /= @base;

            }
            //Console.WriteLine(string.Join("", sb.ToString().Reverse()));

            foreach (var num in result)
            {
                Console.Write(num);
            }
            Console.WriteLine();
        }
    }
}
