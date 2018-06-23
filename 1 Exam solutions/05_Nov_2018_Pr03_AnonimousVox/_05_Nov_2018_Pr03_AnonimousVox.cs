using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _05_Nev_2018_Pr03_AnonimousVox
{
    // 100/100 - not my code
    class _05_Nov_2018_Pr03_AnonimousVox
    {
        static void Main()
        {

            string input = Console.ReadLine();

            string[] values = Console.ReadLine()
                            .Trim()
                            .Split(new string[] { "{", "}" }, StringSplitOptions
                            .RemoveEmptyEntries)
                            .ToArray();

            string pattern = @"([a-zA-Z]+)(.+)(\1)";

            Regex reg = new Regex(pattern);
            int index = 0;

            MatchCollection matches = reg.Matches(input);

            foreach (Match item in matches)
            {
                if (index < values.Length)
                {
                    string currentValue = values[index];
                    Regex regex = new Regex(Regex.Escape(item.Groups[2].Value));
                    input = regex.Replace(input, values[index], 1);
                }

                index++;
            }

            Console.WriteLine(input);
        }
    }
}