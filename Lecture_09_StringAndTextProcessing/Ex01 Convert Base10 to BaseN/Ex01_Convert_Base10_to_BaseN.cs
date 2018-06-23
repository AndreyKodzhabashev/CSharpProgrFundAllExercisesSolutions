using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace Ex01_Convert_Base10_to_BaseN
{
    class Ex01_Convert_Base10_to_BaseN
    {
        // 100/100
        static void Main()
        {
            string inputConditionsAsText = Console.ReadLine();
            
            string[] arrNumbers = inputConditionsAsText
                .Trim()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            int baseN = int.Parse(arrNumbers[0]);
            BigInteger numForConversion = BigInteger.Parse(arrNumbers[1]);
            
            Stack<BigInteger> stackBeforDotConvertedNum = new Stack<BigInteger>();
            List<BigInteger> stackAfterDotConvertedNum = new List<BigInteger>();

            if (arrNumbers[1].Contains('.'))
            {
                string numberAfterDot = arrNumbers[1];
                int indexOfDot = numberAfterDot.IndexOf('.');
                numberAfterDot = numberAfterDot.Substring(indexOfDot + 1, numberAfterDot.Length - indexOfDot - 1);
                string numberAfterDotforMultiply = "0." + numberAfterDot;
                
                BigInteger numAfterDot = BigInteger.Parse(numberAfterDotforMultiply);
                BigInteger currentDigit1 = 0;
                int counter = 0;
                //10.555 = binary 1010.10001110000101001
                while (stackAfterDotConvertedNum.Count == 23 == false)
                {
                    currentDigit1 = numAfterDot * baseN;

                    if (currentDigit1 >= 1)
                    {
                        stackAfterDotConvertedNum.Add(1);
                        counter++;
                    }
                    else
                    {
                        stackAfterDotConvertedNum.Add(0);
                        counter++;
                    }

                    if (currentDigit1 == 1)
                    {
                        break;
                    }
                    string wholePartForFirtherDivision1 = currentDigit1.ToString();

                    int positionOfSecondDot = wholePartForFirtherDivision1.IndexOf('.');

                    wholePartForFirtherDivision1 = wholePartForFirtherDivision1.Substring(positionOfSecondDot + 1, wholePartForFirtherDivision1.Length - positionOfSecondDot - 1);
                    string temp = "0." + wholePartForFirtherDivision1;

                    numAfterDot = BigInteger.Parse(temp);
                }
            }

            BigInteger currentDigit;
            BigInteger wholePartForFirtherDivision;

            while (numForConversion > 0)
            {
                currentDigit = numForConversion % baseN;

                wholePartForFirtherDivision = numForConversion / baseN;

                stackBeforDotConvertedNum.Push(currentDigit);

                numForConversion = wholePartForFirtherDivision;
            }

            if (inputConditionsAsText.Contains('.'))
            {
                Console.WriteLine(string.Join("", stackBeforDotConvertedNum) + "." + string.Join("", stackAfterDotConvertedNum));
            }
            else
            {
                Console.WriteLine(string.Join("", stackBeforDotConvertedNum));
            }
        }
    }
}