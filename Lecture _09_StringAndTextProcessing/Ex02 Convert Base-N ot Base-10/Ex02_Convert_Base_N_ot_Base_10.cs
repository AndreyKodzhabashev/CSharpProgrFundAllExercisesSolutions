using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace Ex02_Convert_Base_N_ot_Base_10
{
    class Ex02_Convert_Base_N_ot_Base_10
    {
        // 100/100
        static void Main()
        {
            string[] inputNums = Console.ReadLine()
                    .Split(' ')
                    .ToArray();

            int baseN = int.Parse(inputNums[0]);

            char[] secondNumAsChar = inputNums[1].ToCharArray();
            List<BigInteger> secondNum = new List<BigInteger>(secondNumAsChar.Length);

            foreach (var digit in secondNumAsChar)
            {
                secondNum.Add(int.Parse(digit.ToString()));
            }
            secondNum.Reverse();

            BigInteger result = 0;

            for (int i = 0; i < secondNum.Count; i++)
            {
                result += (secondNum[i] * BigInteger.Pow(baseN, i));
            }

            Console.WriteLine(result);
        }
    }
}