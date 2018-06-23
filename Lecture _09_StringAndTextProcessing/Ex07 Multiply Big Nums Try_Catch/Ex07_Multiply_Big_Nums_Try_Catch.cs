using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace Ex07_Multiply_Big_Nums_Try_Catch
{
    class Ex07_Multiply_Big_Nums_Try_Catch
    {
        // 100/100
        static void Main()
        {
            string inputBigNumber = Console.ReadLine();
            int multiplier = int.Parse(Console.ReadLine());

            BigInteger inputConditionsAsText = BigInteger.Parse(inputBigNumber);

            string test = inputConditionsAsText.ToString();

            if (test.Contains("E") == false || test.Contains("+") == false)
            {
                int inputConditionsAsText1 = multiplier;

                Console.WriteLine(inputConditionsAsText * inputConditionsAsText1);
                return;
            }

            Stack<string> result = new Stack<string>();
            BigInteger forTransfering = 0;
            BigInteger theOnes = 0;

            if (inputBigNumber.Contains(".") == false)
            {

                char[] bigNumber = inputBigNumber.ToCharArray();

                for (int i = bigNumber.Length - 1; i >= 0; i--)
                {

                    var tempResult = BigInteger.Parse(bigNumber[i].ToString()) * multiplier + forTransfering;

                    if (i == 0)
                    {
                        result.Push(tempResult.ToString());
                        break;
                    }
                    theOnes = tempResult % 10;

                    result.Push(theOnes.ToString());

                    forTransfering = tempResult / 10;


                }
                StringBuilder sb = new StringBuilder();

                foreach (var digit in result)
                {
                    sb.Append(digit);
                }

                Console.WriteLine(sb.ToString());
                return;
            }

        }
    }
}
