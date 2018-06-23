using System;
using System.Collections.Generic;
using System.Linq;

namespace Ex07B_Pr03_Immune_System
{
    class Ex07B_Pr03_Immune_System
    {
        //100/100
        static void Main()
        {

            int initialHealth = int.Parse(Console.ReadLine());
            int healthToDrop = initialHealth;

            List<string> listEncounteredViruses = new List<string>();

            while (true)
            {
                string virusName = Console.ReadLine();
                if (virusName.Equals("end"))
                {
                    break;
                }

                char[] arrVirusNameChar = virusName.ToCharArray();

                int[] arrVirusNameInt = new int[arrVirusNameChar.Length];

                for (int i = 0; i < arrVirusNameChar.Length; i++)
                {
                    arrVirusNameInt[i] = (int)arrVirusNameChar[i];
                }

                int virusStrength = arrVirusNameInt.Sum() / 3;

                int timeForDefeatingInSeconds = virusStrength * arrVirusNameInt.Length;

                if (listEncounteredViruses.Contains(virusName))
                {
                    timeForDefeatingInSeconds /= 3;
                }
                else
                {
                    listEncounteredViruses.Add(virusName);
                }

                int minutesForDefeating = timeForDefeatingInSeconds / 60;
                int secondsForDefeating = timeForDefeatingInSeconds % 60;

                healthToDrop -= timeForDefeatingInSeconds;
                if (healthToDrop >= 0)
                {

                    Console.WriteLine($"Virus {virusName}: {virusStrength} => {timeForDefeatingInSeconds} seconds");
                    Console.WriteLine($"{virusName} defeated in {minutesForDefeating}m {secondsForDefeating}s.");
                    Console.WriteLine($"Remaining health: {healthToDrop}");

                    healthToDrop = (int)(healthToDrop * 1.2);

                    if (healthToDrop > initialHealth)
                    {
                        healthToDrop = initialHealth;
                    }
                }
                else
                {
                    Console.WriteLine($"Virus {virusName}: {virusStrength} => {timeForDefeatingInSeconds} seconds");
                    Console.WriteLine("Immune System Defeated.");
                    return;
                }
            }
            Console.WriteLine($"Final Health: {(int)healthToDrop}");
        }
    }
}
