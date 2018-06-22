using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Ex10_Pr06_ValidUsernames
{
    class Ex10_Pr06_ValidUsernames
    {
        // 100/100
        static void Main()
        {
            string validNamesPattern = @"\b[A-Za-z]\w{2,24}\b";

            string inputText = Console.ReadLine();

            Regex regex = new Regex(validNamesPattern);

            MatchCollection valids = regex.Matches(inputText);

            List<string> listNames = valids.Select(x => x.Value.ToString()).ToList();

            List<KeyValuePair<string, int>> calculatedNames = new List<KeyValuePair<string, int>>();

            for (int i = 0; i < listNames.Count - 1; i++)
            {

                var name1 = listNames[i];
                var name2 = listNames[i + 1];

                int result = name1.Length + name2.Length;

                var concat = name1 + ":" + name2;

                KeyValuePair<string, int> temp = new KeyValuePair<string, int>(concat, result);

                calculatedNames.Add(temp);
            }

            var test = calculatedNames.OrderByDescending(c => c.Value).First();

            var pairNames = test.Key.ToString().Split(":");

            string first = pairNames[0];
            string second = pairNames[1];


            Console.WriteLine(first);
            Console.WriteLine(second);

        }
    }
}