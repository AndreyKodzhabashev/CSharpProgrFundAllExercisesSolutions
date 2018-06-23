using System;
using System.Collections.Generic;

namespace Ex10_Pr02_ExtractSentByKeyword_var2_NoREGEX
{
    class Ex10_Pr02_ExtractSentByKeyword_var2_NoREGEX
    {
        // 80/100 - wrong last test.
        static void Main()
        {
            string keyWord = Console.ReadLine();

            string[] inputText = Console.ReadLine()
                .Split('.', '?', '!');

            List<string> validSentences = new List<string>();

            foreach (var item in inputText)
            {
                if (item.Contains(" " + keyWord + " "))
                {
                    validSentences.Add(item);
                }
            }

            foreach (var item in validSentences)
            {
                Console.WriteLine(item.Trim());
            }
        }
    }
}