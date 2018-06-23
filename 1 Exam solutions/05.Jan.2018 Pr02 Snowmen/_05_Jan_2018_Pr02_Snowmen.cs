using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.Jan._2018_Pr02_Snowmen
{
    class _05_Jan_2018_Pr02_Snowmen
    {
        static void Main()
        {

            var snowmen = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            while (snowmen.Count > 1)
            {
                
                for (int i = 0; i < snowmen.Count; i++)
                {
                    if (snowmen.Count(x => x != -1) == 1)
                    {
                        break;
                    }
                    if (snowmen[i] == -1)
                    {
                        continue;
                    }

                    int attacker = i;
                    int target = snowmen[i] % snowmen.Count;

                    int diffrent = Math.Abs(attacker - target);

                    if (attacker == target)
                    {
                        snowmen[attacker] = -1;
                        Console.WriteLine($"{attacker} performed harakiri");
                        
                    }
                    else if (diffrent % 2 == 0)
                    {
                        snowmen[target] = -1;
                        Console.WriteLine($"{attacker} x {target} -> {attacker} wins");
                        
                    }
                    else
                    {
                        snowmen[attacker] = -1;
                        Console.WriteLine($"{attacker} x {target} -> {target} wins");
                        
                    }
                }
                snowmen = snowmen
                        .Where(x => x != -1)
                        .ToList();
            }
        }
    }
}