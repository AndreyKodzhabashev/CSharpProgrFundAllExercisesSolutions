using System;
using System.Linq;

namespace Ex05B_Pr06_Heists
{
    class Ex05B_Pr06_Heists
    {
        // 100/100
        static void Main()
        {

            int[] prices = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int jewelsPrice = prices[0];
            int goldPrice = prices[1];

            long income = 0;
            long expences = 0;

            while (true)
            {
                string[] lootAndExpences = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                if (lootAndExpences[0].Equals("Jail"))
                {
                    break;
                }

                int currentJewels = 0;
                int currentGold = 0;

                foreach (var item in lootAndExpences[0])
                {
                    if (item == '%')
                    {
                        currentJewels++;
                    }
                    else if (item == '$')
                    {
                        currentGold++;
                    }

                }

                income += jewelsPrice * currentJewels + goldPrice * currentGold;

                expences += int.Parse(lootAndExpences[1]);

            }

            if (income - expences >= 0)
            {
                Console.WriteLine($"Heists will continue. Total earnings: {income - expences}.");
            }
            else
            {
                Console.WriteLine($"Have to find another job. Lost: {expences - income}.");
            }
        }
    }
}
