using System;
using System.Linq;

namespace Ex05_Pr05_CompareCharArrays
{
    class Ex05_Pr05_CompareCharArrays
    {
        // 100/100
        static void Main()
        {
            char[] firstArray = Console.ReadLine().Split(' ').Select(char.Parse).ToArray();
            char[] secondArray = Console.ReadLine().Split(' ').Select(char.Parse).ToArray();

            for (int i = 0; i < Math.Min(firstArray.Length, secondArray.Length); i++)
            {
                if (firstArray.Length != secondArray.Length)
                {
                    if (firstArray.Length < secondArray.Length)
                    {
                        PrintArray(firstArray);
                        PrintArray(secondArray);
                        return;
                    }
                    else if (secondArray.Length < firstArray.Length)
                    {
                        PrintArray(secondArray);
                        PrintArray(firstArray);
                        return;
                    }
                }
                else if (firstArray[i] < secondArray[i])
                {
                    PrintArray(firstArray);
                    PrintArray(secondArray);
                    return;
                }
                else if (secondArray[i] < firstArray[i])
                {
                    PrintArray(secondArray);
                    PrintArray(firstArray);
                    return;
                }
                else
                {
                    PrintArray(firstArray);
                    PrintArray(secondArray);
                    return;
                }
            }
        }
        static void PrintArray(char[] Array)
        {
            for (int i = 0; i < Array.Length; i++)
            {
                Console.Write(Array[i]);
            }
            Console.WriteLine();
        }
    }
}