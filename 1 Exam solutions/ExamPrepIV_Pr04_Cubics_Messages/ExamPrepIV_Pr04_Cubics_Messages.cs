using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace ExamPrepIV_Pr04_Cubics_Messages
{
    class ExamPrepIV_Pr04_Cubics_Messages
    {
        static void Main()
        {

            List<string> result = new List<string>();
                        
            while (true)
            {
                string inputMessage = Console.ReadLine();
                if (inputMessage.Equals("Over!"))
                {
                    break;
                }

                string countLetters = Console.ReadLine();

                //string regexPattern = $@"([A-Za-z]{countLetters})";
                string regexPattern = $@"([0-9]+?)([A-Za-z]{countLetters}+)(.+)";

                Regex regex = new Regex(regexPattern);

                bool isMessage = regex.IsMatch(inputMessage);

                MatchCollection matches = regex.Matches(inputMessage);

                if (isMessage == false)
                {
                    continue;
                }

                string currentMessage = Regex.Match(inputMessage, regexPattern).Value;

                Console.WriteLine();
            }
        }
    }
}
