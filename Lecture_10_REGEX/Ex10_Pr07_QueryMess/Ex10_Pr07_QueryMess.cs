using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Ex10_Pr07_QueryMess
{
    class Ex10_Pr07_QueryMess
    {
        // 72/100 - the hell with this shit!!! :)
        static void Main()
        {

            while (true)
            {

                Dictionary<string, string> dictCurrentLine = new Dictionary<string, string>();

                string input = Console.ReadLine();

                if (input == "END")
                {
                    break;
                }

                string[] inputText = input
                    .Split("&");

                for (int i = 0; i < inputText.Length; i++)
                {

                    inputText[i] = inputText[i].Replace("%20", " ");
                    inputText[i] = inputText[i].Replace("+", " ");

                    int indexOfQuestion = inputText[i].IndexOf("?");

                    if (indexOfQuestion != -1)
                    {
                        inputText[i] = inputText[i].Remove(0, indexOfQuestion + 1);
                    }

                    inputText[i] = Regex.Replace(inputText[i], @"( )+", @" ");
                                        
                }

                for (int i = 0; i < inputText.Length; i++)
                {

                    int indexOfEquals = inputText[i].IndexOf("=");

                    string key = string.Join ("", inputText[i].TakeWhile(x => x != '='));

                    string value =string.Join("", inputText[i].Skip(indexOfEquals + 1 ).Take(inputText[i].Length - indexOfEquals - 1));

                    if (dictCurrentLine.ContainsKey(key) == false)
                    {
                        dictCurrentLine[key] = value;
                    }
                    else
                    {
                        dictCurrentLine[key] += ", " + value;
                    }

                }

                foreach (var item in dictCurrentLine)
                {
                    Console.Write($"{item.Key.Trim()}=[{item.Value.Trim()}]");
                }
                Console.WriteLine();

            }
        
        }
    }
}
