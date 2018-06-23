using System;
using System.Collections.Generic;
using System.Linq;

namespace _05_Jan_2018_SnowWhite_var_2
{
    class _05_Jan_2018_SnowWhite_var_2
    {
        // 100/100
        static void Main()
        {
            Dictionary<string, int> dictDwarfList = new Dictionary<string, int>();

            while (true)
            {
                string inputData = Console.ReadLine();

                if (inputData == "Once upon a time")
                {
                    break;
                }

                string[] inputDataSplit = inputData
                    .Split(" <:> ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string dwarfName = inputDataSplit[0];
                string dwarfHatColor = inputDataSplit[1];
                int dwarfPhysics = int.Parse(inputDataSplit[2]);

                string dwarfID = dwarfName + ":" + dwarfHatColor;

                if (dictDwarfList.ContainsKey(dwarfID) == false)
                {
                    dictDwarfList.Add(dwarfID, 0);

                }
                dictDwarfList[dwarfID] = Math.Max(dwarfPhysics, dictDwarfList[dwarfID]);
            }

            foreach (var dwarf in dictDwarfList.OrderByDescending(x => x.Value).ThenByDescending(x => dictDwarfList.Where(y => y.Key.Split(':')[1] == x.Key.Split(':')[1]).Count()))
            {
                Console.WriteLine($"({dwarf.Key.Split(':')[1]}) {dwarf.Key.Split(':')[0]} <-> {dwarf.Value}");
            }
        }
    }
}
