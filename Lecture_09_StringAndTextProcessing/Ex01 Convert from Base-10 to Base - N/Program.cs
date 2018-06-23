using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Ex01_Convert_from_Base_10_to_Base___N
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputConditionsAsText = Console.ReadLine();

            string[] arrNumbers = inputConditionsAsText
                .Trim()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            int baseN = int.Parse(arrNumbers[0]);
            double numForConversion = double.Parse(arrNumbers[1]);

            Stack<int> stackBeforDotConvertedNum = new Stack<int>();
            List<int> stackAfterDotConvertedNum = new List<int>();

            if (arrNumbers[1].Contains('.'))
            {
                string numberAfterDot = arrNumbers[1];
                int indexOfDot = numberAfterDot.IndexOf('.');
                numberAfterDot = numberAfterDot.Substring(indexOfDot + 1, numberAfterDot.Length - indexOfDot - 1);
                string numberAfterDotforMultiply = "0." + numberAfterDot;

                double numAfterDot = double.Parse(numberAfterDotforMultiply);
                double currentDigit1 = 0;
                int counter = 0;
                //10.555 = binary 1010.10001110000101001
                while (stackAfterDotConvertedNum.Count == 23 == false)
                {
                    currentDigit1 = numAfterDot * baseN;

                    if ((int)currentDigit1 > 0)
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

                    numAfterDot = double.Parse(temp);
                }
            }

            int currentDigit;
            int wholePartForFirtherDivision;

            while (numForConversion > 0)
            {
                currentDigit = (int)numForConversion % baseN;

                wholePartForFirtherDivision = (int)numForConversion / baseN;

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
