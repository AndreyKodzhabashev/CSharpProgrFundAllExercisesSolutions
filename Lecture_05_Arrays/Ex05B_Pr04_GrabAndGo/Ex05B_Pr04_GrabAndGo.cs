using System;
using System.Linq;

namespace Ex05B_Pr04_GrabAndGo
{
    // 100/100
    class Ex05B_Pr04_GrabAndGo
    {
        static void Main()
        {
            long[] arrNumbers = Console.ReadLine()
                .Split()
                .Select(long.Parse)
                .ToArray();

            long numToSearch = long.Parse(Console.ReadLine());

            int index = -1;

            for (int i = 0; i < arrNumbers.Length; i++)
            {
                
                if (arrNumbers[i] == numToSearch)
                {
                    index = i;
                }

            }

            long result = 0;

            if (index < 0)
            {
                Console.WriteLine("No occurrences were found!");
                return;
            }
            
            for (int i = 0; i < index; i++)
            {
                result += arrNumbers[i];
            }

            Console.WriteLine(result);
        }
    }
}