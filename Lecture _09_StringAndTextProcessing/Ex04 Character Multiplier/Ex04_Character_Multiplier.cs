using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Ex04_Character_Multiplier
{
    // 80/100 - first test - runtime error
    class Ex04_Character_Multiplier
    {
        static void Main()
        {
            string inputText = Console.ReadLine();
            if (inputText.Contains(" ") == false)
            {
                int result2 = 0;
                var test1 = inputText.ToCharArray();
                foreach (var item in test1)
                {
                    result2 += item;
                    Console.WriteLine(result2);
                    return;
                }
            }

            List<string> strings = inputText
                .Trim()
                .Split(new char[] { (' ') }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            string textA = strings[0];
            string textB = strings[1];

            int result = 0;

            char[] firstText = textA.ToCharArray();
            char[] secondText = textB.ToCharArray();

            if (textA.Length == textB.Length)
            {
                for (int i = 0; i < firstText.Length; i++)
                {
                    result += firstText[i] * secondText[i];
                }
            }
            else if (textA.Length < textB.Length)
            {
                for (int i = 0; i < textA.Length; i++)
                {
                    result += textA[i] * textB[i];
                }

                int countCharsRemainingFromB = textB.Length - textA.Length;
                var test = textB.Reverse().Take(countCharsRemainingFromB).ToArray();
                for (int i = 0; i < test.Length; i++)
                {
                    result += test[i];
                }
            }
            else
            {
                for (int i = 0; i < textA.Length; i++)
                {
                    result += textA[i] * textB[i];
                }

                int countCharsRemainingFromA = textA.Length - textB.Length;
                var test = textB.Reverse().Take(countCharsRemainingFromA).ToArray();
                for (int i = 0; i < test.Length; i++)
                {
                    result += test[i];
                }
            }
            Console.WriteLine(result);
        }
    }
}