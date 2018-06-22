using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace EX10_Pr03_CameraView_REGEX
{
    class EX10_Pr03_CameraView_REGEX
    {
        // 100/100
        static void Main()
        {
            int[] tokens = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            int skip = tokens[0];
            int take = tokens[1];
            string pattern = @"(?:\|<)(.*?(?=[\|]))|(?:\|<)(.*$)";
            Regex regex = new Regex(pattern);

            string inputText = Console.ReadLine();

            MatchCollection substrings = regex.Matches(inputText);

            List<string> test = new List<string>();

            foreach (Match item in substrings)
            {
                test.Add(item.Value.ToString());

            }

            List<string> processed = new List<string>();

            foreach (var item in test)
            {
                var temp = string.Join("", item.Skip(skip + 2).Take(take));
                processed.Add(temp);
            }

            Console.WriteLine(string.Join(", ", processed));

        }
    }
}