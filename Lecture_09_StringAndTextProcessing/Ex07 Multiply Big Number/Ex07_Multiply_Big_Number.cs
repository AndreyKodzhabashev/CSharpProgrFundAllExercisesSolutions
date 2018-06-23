using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace Ex07_Multiply_Big_Number
{
    class Ex07_Multiply_Big_Number
    {
        static void Main()
        {
            // 60/100 points
            string inputBigNumber = Console.ReadLine();

            int multiplier = int.Parse(Console.ReadLine());

            Stack<string> result = new Stack<string>();
            var forTransfering = 0;
            var theOnes = 0;

            if (inputBigNumber.Contains(".") == false)
            {

                char[] bigNumber = inputBigNumber.ToCharArray();

                for (int i = bigNumber.Length - 1; i >= 0; i--)
                {

                    var tempResult = int.Parse(bigNumber[i].ToString()) * multiplier + forTransfering;

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
            else
            {
                var dotLocation = inputBigNumber.IndexOf('.');

                var numBeforeDot = inputBigNumber.Take(dotLocation).ToArray();
                var numAfterDot = inputBigNumber.Reverse().Take(dotLocation).Reverse().ToArray();

                var resultAfterDot = 0;
                for (int i = numAfterDot.Length - 1; i >= 0; i--)
                {
                    resultAfterDot = int.Parse(numAfterDot[i].ToString()) * multiplier + forTransfering;
                                        
                    theOnes = resultAfterDot % 10;

                    result.Push(theOnes.ToString());

                    forTransfering = resultAfterDot / 10;
                }

                result.Push(".");

                var beforDotResult = 0;
                for (int i = numBeforeDot.Length - 1; i >= 0; i--)
                {

                    beforDotResult = int.Parse(numBeforeDot[i].ToString()) * multiplier + forTransfering;

                    if (i == 0)
                    {
                        result.Push(beforDotResult.ToString());
                        break;
                    }
                    theOnes = beforDotResult % 10;

                    result.Push(theOnes.ToString());

                    forTransfering = beforDotResult / 10;


                }
                StringBuilder sb1 = new StringBuilder();

                foreach (var digit in result)
                {
                    sb1.Append(digit);
                }
                Console.WriteLine(sb1.ToString());

            }
        }
    }
}
