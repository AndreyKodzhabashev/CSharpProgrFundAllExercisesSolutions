using System;
using System.Collections.Generic;
using System.Linq;

namespace Ex06_Pr07_Bomb_Numbers
{
    class Ex06_Pr07_Bomb_Numbers
    {
        static void Main()
        {
            // 80/100 - double,decimal = same shit

            List<decimal> listNumbers = Console.ReadLine()
                 .Split(' ',StringSplitOptions.RemoveEmptyEntries)
                 .Select(decimal.Parse)
                 .ToList();

            List<decimal> listConditions = Console.ReadLine()
                 .Split(' ',StringSplitOptions.RemoveEmptyEntries)
                 .Select(decimal.Parse)
                 .ToList();

            for (int i = 0; i < listNumbers.Count; i++)
            {
                if (listNumbers[i] == listConditions[0])
                {
                    int power = (int)listConditions[1];
                    if (i + power >= listNumbers.Count)
                    {
                        listNumbers.RemoveRange(i, listNumbers.Count - i);
                        listNumbers.RemoveRange(listNumbers.Count - power, power);
                        continue;
                    }
                    else if (i - power < 0)
                    {
                        listNumbers.RemoveRange(0, i + 1);
                        listNumbers.RemoveRange(0, power);
                        continue;
                    }


                    listNumbers.RemoveRange(i - power, 2 * power + 1);


                }
            }
            decimal result = 0;
            for (int i = 0; i < listNumbers.Count; i++)
            {
                result += listNumbers[i];
            }

            Console.WriteLine(result);
        }
    }
}
