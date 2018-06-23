using System;
using System.Collections.Generic;
using System.Linq;

namespace Ex05_Magic_Exchangable_Words
{
    // 60/100
    class Ex05_Magic_Exchangable_Words
    {
        static void Main()
        {
            string[] inputText = Console.ReadLine()
                .Split(' ')
                .ToArray();

            var firstWord = new List<char>();
            var secondWord = new List<char>();

            List<char> remains = new List<char>();
            int difference = 0;
           
            if (inputText[0].Length == inputText[1].Length)
            {
                firstWord = inputText[0].ToList();
                secondWord = inputText[1].ToList();
            }
            else if (inputText[0].Length < inputText[1].Length)
            {
                difference = inputText[1].Length - inputText[0].Length;

                firstWord = inputText[0].ToList();
                secondWord = inputText[1].Take(firstWord.Count).ToList();

                remains = inputText[1]
                            .Reverse()
                            .Take(difference)
                            .ToList();
            }
            else
            {
                difference = inputText[0].Length - inputText[1].Length;

                firstWord = inputText[0].Take(secondWord.Count).ToList();
                secondWord = inputText[1].ToList();

                remains = inputText[0]
                            .Reverse()
                            .Take(difference)
                            .ToList();
            }

            if (remains.Count==0)
            {
                Console.WriteLine(IsExchangable(firstWord,secondWord).ToString().ToLower());
            }
            else
            {
                bool temp1 = false;
                if (IsExchangable(firstWord, secondWord))
                {
                    var temp = new Dictionary<char, char>();

                    for (int i = 0; i < firstWord.Count; i++)
                    {
                        temp[firstWord[i]] = secondWord[i];
                    }

                    foreach (var item in remains)
                    {
                        if (temp.ContainsKey(item) || temp.ContainsValue(item))
                        {
                            temp1 = true;
                        }
                    }
                }
                Console.WriteLine(temp1.ToString().ToLower());
            }
        }

        static bool IsExchangable(List<char> word1, List<char> word2)
        {
            bool isExchangable = true;
            Dictionary<char, char> dictCompairedChars = new Dictionary<char, char>(word1.Count);

            for (int i = 0; i < word1.Count; i++)
            {
                if (dictCompairedChars.ContainsKey(word1[i]))
                {
                    if (dictCompairedChars[word1[i]] == word2[i])
                    {
                        continue;
                    }
                    else
                    {
                        isExchangable = false;
                        break;
                    }
                }
                else if (dictCompairedChars.ContainsKey(word2[i]))
                {
                    if (dictCompairedChars[word2[i]] == word1[i])
                    {
                        continue;
                    }
                    else
                    {
                        isExchangable = false;
                        break;
                    }

                }
                else
                {
                    dictCompairedChars.Add(word1[i], word2[i]);
                }

            }

            return isExchangable;                  
        }
    }
}