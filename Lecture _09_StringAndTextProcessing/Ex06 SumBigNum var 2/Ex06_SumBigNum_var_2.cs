using System;
using System.Linq;
using System.Collections.Generic;


namespace Ex06_SumBigNum_var_2
{
    // 80/100
    class Ex06_SumBigNum_var_2
    {
        static void Main()
        {
            string firstNumAsText = Console.ReadLine();
            string secondNumAsText = Console.ReadLine();

            int diff = Math.Abs(firstNumAsText.Length - secondNumAsText.Length);

            int identifierBiggerNum = string.Compare(firstNumAsText.Length.ToString(), secondNumAsText.Length.ToString());

            if (identifierBiggerNum == 1)
            {
                secondNumAsText = secondNumAsText.Insert(0, new string('0', diff));

            }
            else if (identifierBiggerNum == -1)
            {
                firstNumAsText = firstNumAsText.Insert(0, new string('0', diff));
            }

            string result = SumMassiveDigits(firstNumAsText, secondNumAsText);

            Console.WriteLine(result);

        }
        static string SumMassiveDigits(string first, string second)
        {

            Stack<string> stackResult = new Stack<string>();
            int valueForTransfer = 0;
            int digitForPush = 0;
            for (int i = first.Length - 1; i >= 0; i--)
            {
                int firstNum = int.Parse(first[i].ToString());
                int secondNum = int.Parse(second[i].ToString());

                int result = firstNum + secondNum + valueForTransfer; 

                valueForTransfer = 0;
                digitForPush = result % 10;
                if (i == 0)
                {
                    digitForPush = result;

                }
                stackResult.Push(digitForPush.ToString());

                if (9 < result)
                {
                    valueForTransfer++;

                }

            }
            string totalString = string.Join("", stackResult);

            return (totalString);
        }
    }
}