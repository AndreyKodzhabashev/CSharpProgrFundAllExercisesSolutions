using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _05.Jan._2018_Pr04_SnowWhite
{

    class _05_Jan_2018_Pr04_SnowWhite
    {
        // 80/100 - its the maximum points i have reached. There is something with the sorting, but what... ?!?!?!
        static void Main()
        {
            List<Dwarf> listDwarfs = new List<Dwarf>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input.Equals("Once upon a time"))
                {
                    break;
                }

                string[] inputSplit = input
                    .Split(" <:> ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string dwarfName = inputSplit[0];
                string dwarfHatColor = inputSplit[1];
                int dwarfPhysics = int.Parse(inputSplit[2]);

                Dwarf currentDwarf;

                int indexOfExistingDwarf = listDwarfs.FindIndex(x => x.Name == dwarfName && x.HatColor == dwarfHatColor);

                currentDwarf = new Dwarf(dwarfName, dwarfHatColor, dwarfPhysics);

                if (indexOfExistingDwarf == -1)
                {

                    listDwarfs.Add(currentDwarf);
                }
                else
                {
                    var currentDwarfTemp = listDwarfs[indexOfExistingDwarf];

                    if (currentDwarfTemp.Physics <= dwarfPhysics)
                    {
                        listDwarfs.RemoveAt(indexOfExistingDwarf);
                        listDwarfs.Add(currentDwarf);
                    }
                    //currentDwarf.Physics = Math.Max(currentDwarf.Physics, dwarfPhysics);
                }
            }

            foreach (var dwarf in listDwarfs.OrderByDescending(x => x.Physics).ThenByDescending(z => z.Name).ThenByDescending(x => listDwarfs.Where(y => y.HatColor == y.HatColor).Count()))
            {
                Console.WriteLine($"({dwarf.HatColor}) {dwarf.Name} <-> {dwarf.Physics}");
            }
        }
    }
    class Dwarf
    {
        public Dwarf(string name, string hatColor, int physics)
        {
            this.Name = name;
            this.HatColor = hatColor;
            this.Physics = physics;
        }

        public string Name { get; set; }
        public string HatColor { get; set; }
        public int Physics { get; set; }
    }
}