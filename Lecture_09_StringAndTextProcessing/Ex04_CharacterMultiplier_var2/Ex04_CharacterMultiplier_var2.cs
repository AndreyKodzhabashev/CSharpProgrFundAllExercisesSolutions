using System;
using System.Linq;

namespace Ex04_CharacterMultiplier_var2
{
    // 80/100 - first test - wrong result
    class Ex04_CharacterMultiplier_var2
    {
        static void Main()
        {

            string[] input = Console.ReadLine()
                .Split();

            string firstWord = input[0];
            string secondWord = input[1];

            int lengthOfTheShorterWord = Math.Min(firstWord.Length, secondWord.Length);

            int result = 0;

            if (firstWord.Length == 0)
            {
                result = secondWord.Split("").Skip(1).SelectMany(x => x).ToArray().Sum(x => x);

            }
            else if (secondWord.Length == 0)
            {
                result = firstWord.Split("").Skip(1).SelectMany(x => x).ToArray().Sum(x => x);

            }
            else
            {
                for (int i = 0; i < lengthOfTheShorterWord; i++)
                {
                    result += firstWord[i] * secondWord[i];
                }

                if (firstWord.Length < secondWord.Length)
                {
                    for (int i = firstWord.Length; i < secondWord.Length; i++)
                    {
                        result += secondWord[i];
                    }
                }
                else
                {
                    for (int i = firstWord.Length; i < secondWord.Length; i++)
                    {
                        result += secondWord[i];
                    }
                }
            }
            
            Console.WriteLine(result);
        }
    }
}
