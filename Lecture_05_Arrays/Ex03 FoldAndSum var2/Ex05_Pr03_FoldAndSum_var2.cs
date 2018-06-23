using System;
using System.Linq;

namespace Ex05_Pr03_FoldAndSum_var2
{
    class Ex05_Pr03_FoldAndSum_var2
    {
        static void Main()
        {
            int[] arrNum = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            int[] arrFirstHalfArrNum = new int[arrNum.Length / 2];
            int[] arrSecondtHalfArrNum = new int[arrNum.Length / 2];

            // в долния цикъл вадим числата от началото до половината на входния масив
            int tempNum = 0;
            for (int i = 0; i < arrFirstHalfArrNum.Length; i++)
            {
                tempNum = arrNum[i];
                arrFirstHalfArrNum[i] = tempNum;
            }
            int[] revArrFirstHalf = ReverseArray(arrFirstHalfArrNum);

            //в долния масив вадим числата от средата до края на входния масив
            tempNum = 0;
            for (int i = 0; i < arrSecondtHalfArrNum.Length; i++)
            {
                tempNum = arrNum[arrNum.Length / 2 + i];
                arrSecondtHalfArrNum[i] = tempNum;
            }

            ReverseArray(arrFirstHalfArrNum);

            for (int i = 0; i < arrFirstHalfArrNum.Length; i++)
            {
                arrFirstHalfArrNum[i] += revArrFirstHalf[i];
                Console.Write(arrFirstHalfArrNum[i] + " ");
            }
            Console.WriteLine();
        }
        static int[] ReverseArray(int[] reversedArray)
        {
            int[] reversedArrayByValue = new int[reversedArray.Length];
            int temp = 0;
            for (int i = 0; i < reversedArray.Length; i++)
            {
                temp = reversedArray[i];
                reversedArrayByValue[i] = temp;
            }
            
            for (int i = 0; i < reversedArrayByValue.Length / 2; i++)
            {
                int temp1 = reversedArrayByValue[i];
                reversedArrayByValue[i] = reversedArrayByValue[reversedArrayByValue.Length - 1 - i];
                reversedArrayByValue[reversedArrayByValue.Length - 1 - i] = temp1;
            }
            return reversedArrayByValue;
        }
    }
}
