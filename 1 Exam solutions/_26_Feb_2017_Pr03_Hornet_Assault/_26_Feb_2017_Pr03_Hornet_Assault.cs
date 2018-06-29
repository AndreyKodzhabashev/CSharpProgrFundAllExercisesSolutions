using System;
using System.Linq;

namespace _26_Feb_2017_Pr03_Hornet_Assault
{
    // 100/100  
    class _26_Feb_2017_Pr03_Hornet_Assault
    {
        static void Main()
        {
            long[] hives = Console.ReadLine()
                .Split()
                .Select(long.Parse)
                .ToArray();

            long[] hornets = Console.ReadLine()
                .Split()
                .Select(long.Parse)
                .ToArray();

            long counterHornetToKill = -1;

            for (long i = 0; i < hives.Length; i++)
            {

                long hornetsPower = 0;
                for (int j = 0; j < hornets.Length; j++)
                {
                    hornetsPower += hornets[j];
                }

                if (hornetsPower < 1)
                {
                    break;
                }
                else if (hornetsPower > hives[i])
                {
                    hives[i] = 0;
                }
                else
                {
                    counterHornetToKill++;
                    hives[i] = hives[i] - hornetsPower;

                    hornets[counterHornetToKill] = 0;
                }

            }
            
            if (hives.Sum() > 0)
            {
                Console.WriteLine(string.Join(" ", hives.Where(x => x > 0)));
            }
            else
            {
                Console.WriteLine(string.Join(" ", hornets.Where(x => x > 0)));
            }
            
        }
    }
}