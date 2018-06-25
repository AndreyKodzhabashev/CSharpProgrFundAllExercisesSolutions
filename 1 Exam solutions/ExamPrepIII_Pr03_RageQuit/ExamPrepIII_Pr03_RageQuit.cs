using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace ExamPrepIII_Pr03_RageQuit
{
    // 100/100
    class ExamPrepIII_Pr03_RageQuit
    {
        static void Main()
        {
                      
            MatchCollection words = Regex.Matches(Console.ReadLine().ToUpper(), @"([\D]+)([\d]+)");

            StringBuilder result = new StringBuilder();

            List<char> temp = new List<char>();

            foreach (Match word in words)
            {
               
                for (int i = 0; i < int.Parse(word.Groups[2].Value); i++)
                {
                    result.Append(word.Groups[1].Value);
                }

                
                for (int i = 0; i < word.Groups[2].Length; i++)
                {
                    if (temp.Contains(word.Groups[2].Value[i]) == false)
                    {
                        temp.Add(word.Groups[2].Value[i]);
                    }
                }
                               
            }
         
            Console.WriteLine($"Unique symbols used: {result.ToString().Distinct().ToArray().Count()}");
            Console.WriteLine(result.ToString());
         
        }
    }
}