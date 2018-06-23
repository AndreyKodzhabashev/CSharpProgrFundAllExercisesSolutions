using System;
using System.Linq;
using System.Collections.Generic;

namespace Ex02_Convert_Base2_to_BaseN
{
    class Ex02_Convert_Base2_to_BaseN

    {
        static void Main(string[] args)
        {
            string [] inputNums = Console.ReadLine()
                .Split(' ')
                .ToArray();

            int baseN = int.Parse(inputNums[0]);

            char[] secondNumAsChar = inputNums[1].ToCharArray();
            List<int> secondNum = new List<int>(secondNumAsChar.Length);

            foreach (var digit in secondNumAsChar)
            {
                secondNum.Add(int.Parse(digit.ToString()));
            }
            secondNum.Reverse();

            double result = 0;

            for (int i = 0; i < secondNum.Count; i++)
            {
                result += (secondNum[i] * Math.Pow(baseN, i));
            }
            Console.WriteLine(result);
        }
    }
}
