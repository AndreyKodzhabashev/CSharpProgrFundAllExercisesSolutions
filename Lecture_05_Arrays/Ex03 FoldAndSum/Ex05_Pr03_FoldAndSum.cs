using System;
using System.Linq;

namespace Ex05_Pr03_FoldAndSum
{
    class Ex05_Pr03_FoldAndSum
    {
        // 100/100
        static void Main()
        {
            int[] arrNum = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            int[] arrFoldedNum = new int[arrNum.Length];

            for (int i = 0; i < arrFoldedNum.Length / 2 / 2; i++)
            {
                arrFoldedNum[arrFoldedNum.Length / 2 - 1 - i] = arrNum[i];
            }


            for (int i = 0; i < arrFoldedNum.Length / 2 / 2; i++)
            {
                arrFoldedNum[arrFoldedNum.Length / 2 + i] = arrNum[arrNum.Length - 1 - i];
            }

            for (int i = 0; i < arrFoldedNum.Length / 2; i++)
            {
                arrNum[arrNum.Length / 2 / 2 + i] += arrFoldedNum[arrNum.Length / 2 / 2 + i];
                Console.Write(arrNum[arrNum.Length / 2 / 2 + i] + " ");
            }
        }
    }
}
