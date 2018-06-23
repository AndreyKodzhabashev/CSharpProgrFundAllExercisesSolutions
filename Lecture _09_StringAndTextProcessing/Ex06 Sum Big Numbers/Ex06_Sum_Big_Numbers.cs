using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Ex06_Sum_Big_Numbers
{
    // 60/100
    class Ex06_Sum_Big_Numbers
    {
        static void Main()
        {

            string firstNumAsText = Console.ReadLine();
            string secondNumAsText = Console.ReadLine();

            string tempDigit = "";

            int compare = String.Compare(firstNumAsText.Length.ToString(), secondNumAsText.Length.ToString());
            int diff = 0;

            string result = "";

            if (compare == 0)
            {
                result = SumMassiveDigits(firstNumAsText, secondNumAsText);
                if (result[0] == '0')
                {
                    result = result.Remove(0, 1).ToString();
                }
            }
            else if (compare == -1)
            {
                diff = secondNumAsText.Length - firstNumAsText.Length;
                tempDigit = secondNumAsText.Substring(0, diff);
                secondNumAsText = secondNumAsText.Remove(0, diff).ToString();

                result = SumMassiveDigits(firstNumAsText, secondNumAsText);


                if (result[0] == '0')
                {
                    result = result.Remove(0, 1).Insert(0, tempDigit).ToString();
                }
                else if (result[0] == '1')
                {
                    result = result.Remove(0, 1).ToString();
                    int currentResult = 0;
                    int toTransfer = 0;
                    for (int i = tempDigit.Length - 1; i >= 0; i--)
                    {
                        int tempDigit1 = 1;
                        int currentDigit = int.Parse(tempDigit[i].ToString());

                        currentResult = currentDigit + tempDigit1 + toTransfer;

                        string toAppend = (currentResult % 10).ToString();
                        toTransfer = currentResult / 10;

                        result = result.Insert(0, toAppend).ToString();

                        if (i == 0 && toTransfer == 0 == false)
                        {
                            result = result.Insert(0, (toTransfer.ToString())).ToString();
                        }

                    }
                }


            }
            else if (compare == 1)
            {
                diff = firstNumAsText.Length - secondNumAsText.Length;
                tempDigit = firstNumAsText.Substring(0, diff);
                firstNumAsText = firstNumAsText.Remove(0, diff).ToString();

                result = SumMassiveDigits(firstNumAsText, secondNumAsText);

                if (result[0] == '0')
                {
                    result = result.Remove(0, 1).Insert(0, tempDigit).ToString();
                }
                else if (result[0] == '1')
                {
                    result = result.Remove(0, 1).ToString();
                    int currentResult = 0;
                    int toTransfer = 0;
                    for (int i = tempDigit.Length - 1; i >= 0; i--)
                    {
                        int tempDigit1 = 1;
                        int currentDigit = int.Parse(tempDigit[i].ToString());

                        currentResult = currentDigit + tempDigit1 + toTransfer;

                        string toAppend = (currentResult % 10).ToString();
                        toTransfer = currentResult / 10;

                        result = result.Insert(0, toAppend).ToString();

                        if (i == 0 && toTransfer == 0 == false)
                        {
                            result = result.Insert(0, (toTransfer.ToString())).ToString();
                        }

                    }
                }
            }


            Console.WriteLine(result);
        }
        static string SumMassiveDigits(string first, string second)
        {

            Stack<string> stackResult = new Stack<string>();
            int valueForTransfer = 0;
            for (int i = first.Length - 1; i >= 0; i--)
            {
                int firstNum = int.Parse(first[i].ToString());
                int secondNum = int.Parse(second[i].ToString());

                int result = firstNum + secondNum + valueForTransfer;
                valueForTransfer = 0;
                int digitForPush = result % 10;

                if (9 < result)
                {
                    valueForTransfer++;

                }
                stackResult.Push(digitForPush.ToString());

                if (i == 0)
                {
                    stackResult.Push(valueForTransfer.ToString());

                }
            }
            string totalString = string.Join("", stackResult);

            return (totalString);
        }
    }
}
