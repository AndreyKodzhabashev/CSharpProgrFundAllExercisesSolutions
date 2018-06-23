using System;
using System.Text.RegularExpressions;

namespace Ex10_Pr02_ExtractSentencesByKeyword
{
    class Ex10_Pr02_ExtractSentencesByKeyword
    {
        // 100/100 the regex pattern is not exactly correct
        static void Main()
        {
            string keyWord = Console.ReadLine();
            
            string pattern = $@"\b([^.!?]+)\b({keyWord})\b(.*?)(?=[.?!])";
            
            string inputText = Console.ReadLine();

            Regex regex = new Regex(pattern);

            MatchCollection matches = regex.Matches(inputText);

            foreach (Match item in matches)
            {
                Console.WriteLine(item.Value.ToString());
            }
        }
    }
}