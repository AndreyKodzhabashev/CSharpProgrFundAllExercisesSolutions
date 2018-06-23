using System;
using System.Linq;

namespace Ex05_Pr11_Equal_Sums
{
    class Ex05_Pr11_Equal_Sums
    {
        // 100/100
        static void Main()
        {
            int[] arrNum = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            int numberForCheck = 0;
            int sumOfElementsToLeft = 0;
            int sumOfTheElementsToRight = 0;

            for (int i = 0; i < arrNum.Length; i++)
            {
                numberForCheck = arrNum[i];
                sumOfElementsToLeft = 0;
                sumOfTheElementsToRight = 0;

                for (int j = 0; j < i; j++)
                    
                {
                    sumOfElementsToLeft += arrNum[j];
                }

                for (int k = i + 1; k < arrNum.Length; k++)
                {
                    sumOfTheElementsToRight += arrNum[k];
                }

                if (sumOfElementsToLeft == sumOfTheElementsToRight)
                {
                    Console.WriteLine(i);
                    return;
                }                               
            }
            
            if (sumOfElementsToLeft == 0 && sumOfTheElementsToRight == 0)
            {
                Console.WriteLine("0");
                return;
            }
            Console.WriteLine("no");
        }
    }
}
