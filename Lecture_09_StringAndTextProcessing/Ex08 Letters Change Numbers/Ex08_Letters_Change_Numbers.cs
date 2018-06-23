using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Numerics;

namespace Ex08_Letters_Change_Numbers
{
    class Ex08_Letters_Change_Numbers
    {
        // 100/100
        static void Main()
        {
            while (true)
            {
                string startString = Console.ReadLine();

                if (startString.Equals("End"))
                {
                    return;
                }
                string[] inputStrings = startString
                    .Trim()
                    .Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                double totalResult = 0;

                foreach (var item in inputStrings)
                {
                    double result = 0;
                    char[] currentStringAsChars = item.ToCharArray();
                                                          

                    char firstLetter = currentStringAsChars[0];
                    char lastLetter = currentStringAsChars[currentStringAsChars.Length - 1];

                    double digit = double.Parse(string.Join("", item).Remove(item.Length - 1, 1).Remove(0, 1).ToString());

                    double firstLetterAlphabetPosition = char.ToUpper(firstLetter) - 64;
                    double lastLetterAlphabetPosition = char.ToUpper(lastLetter) - 64;


                    if ('A' <= firstLetter && firstLetter <= 'Z')
                    {
                        result = digit / firstLetterAlphabetPosition ;
                    }
                    else if ('a' <= firstLetter && firstLetter <= 'z')
                    {
                        result = digit * firstLetterAlphabetPosition;
                    }

                    if ('A' <= lastLetter && lastLetter <= 'Z')
                    {
                        result -= lastLetterAlphabetPosition;
                    }
                    else if ('a' <= lastLetter && lastLetter <= 'z')
                    {
                        result += lastLetterAlphabetPosition;
                    }

                    totalResult += result;
                }

                Console.WriteLine($"{totalResult:F2}");
            }
        }
    }
}