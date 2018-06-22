using System;
using System.Text.RegularExpressions;

namespace Ex10_Pr01_ExtractEmails
{
    class Ex10_Pr01_ExtractEmails
    {
        // 75/100 - dont know how to eliminate match, when starts with dot(.)
        static void Main()
        {
            Regex regex = new Regex(@"^|\b[A-Za-z]+(?<=)[\.-]*[A-Za-z]+@[A-Za-z]([A-Za-z\.-]+)\.[A-Za-z]+");

            string text = Console.ReadLine();

            MatchCollection emails = regex.Matches(text);

            foreach (Match item in emails)
            {
                Console.WriteLine(item.Value.ToString());
            }
        }
    }
}