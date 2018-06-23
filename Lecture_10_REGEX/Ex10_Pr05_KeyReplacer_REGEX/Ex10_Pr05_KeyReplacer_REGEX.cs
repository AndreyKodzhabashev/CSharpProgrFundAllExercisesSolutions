using System;
using System.Text.RegularExpressions;

namespace Ex10_Pr05_KeyReplacer_REGEX
{
    class Ex10_Pr05_KeyReplacer_REGEX
    {
        // 100/100 with the commented variant of taking start and stop point - With wrong Zero test, where "Empty result" have not be written on the Console

        // 66/100 with the current variant to taking start and stop point

        static void Main()
        {
            string startEnd = Console.ReadLine();

            string text = Console.ReadLine();

            string startEndPattern = @"(^[A-Za-z]+?(?=[\|<])).+((?<=[|\<])[A-Za-z]+$)";

            Regex startEndRegex = new Regex(startEndPattern);

            Match startAndEnd = startEndRegex.Match(startEnd);

            //string[] startEndSpliter = startEnd
            //    .Split(@"\|<".ToCharArray());
            //string start = startEndSpliter[0];
            //string end = startEndSpliter[startEndSpliter.Length - 1];

            string start = startAndEnd.Groups[1].Value;
            string end = startAndEnd.Groups[2].Value;

            string textRegexPattern = $@"(?<={start}).*?(?={end})";

            Regex textOperations = new Regex(textRegexPattern);

            MatchCollection result = textOperations.Matches(text);

            if (result.Count == 0)
            {
                Console.WriteLine("Empty result");
            }
            else
            {
                Console.WriteLine(string.Join("", result));
            }
        }
    }
}