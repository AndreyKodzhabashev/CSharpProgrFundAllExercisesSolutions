using System;
using System.Collections.Generic;
using System.Linq;

namespace Ex05_Pr09_IndexOfLetters
{
    class Ex05_Pr09_IndexOfLetters
    {
        // 100/100
        static void Main()
        {
            string alphabet = "abcdefghijklmnopqrstuvwxyz";
            List<char> alphabetLetters = alphabet.ToList();

            char[] arrCurrentWord = Console.ReadLine().ToCharArray();

            foreach (var item in arrCurrentWord)
            {
                Console.WriteLine($"{item} -> {alphabetLetters.IndexOf(item)}");
            }
        }
    }
}
