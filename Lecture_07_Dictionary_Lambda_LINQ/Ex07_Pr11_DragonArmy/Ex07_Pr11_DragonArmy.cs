using System;
using System.Linq;
using System.Collections.Generic;

namespace Ex07_Pr11_DragonArmy
{
    // 100/100
    class Ex07_Pr11_DragonArmy
    {
        static void Main()
        {
            Dictionary<string, SortedDictionary<string, DragonPowers>> dictListOfDragons = new Dictionary<string, SortedDictionary<string, DragonPowers>>();

            int dragonCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < dragonCount; i++)
            {
                string[] dragonData = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string dragonName = dragonData[1];
                string dragonType = dragonData[0];

                long dragonDamage = long.TryParse(dragonData[2], out dragonDamage) ? dragonDamage : 45;

                long dragonHealth = long.TryParse(dragonData[3], out dragonHealth) ? dragonHealth : 250;

                long dragonArmor = long.TryParse(dragonData[4], out dragonArmor) ? dragonArmor : 10;

                DragonPowers skillSet = CreateDragon(dragonHealth, dragonDamage, dragonArmor);

                if (dictListOfDragons.ContainsKey(dragonType) == false)
                {
                    dictListOfDragons.Add(dragonType, new SortedDictionary<string, DragonPowers>());

                    var temp = dictListOfDragons[dragonType];

                    temp.Add(dragonName, skillSet);

                }
                else
                {
                    var temp = dictListOfDragons[dragonType];
                    
                    if (temp.ContainsKey(dragonName) == false)
                    {
                        temp.Add(dragonName, skillSet);

                    }
                    temp[dragonName] = skillSet;

                }

            }
            foreach (var item in dictListOfDragons)
            {

                var temp = item.Value;

                double averageHealth = temp.Values.Average(x => x.Health);
                double averageArmor = temp.Values.Average(x => x.Armor);
                double averageDamage = temp.Values.Average(x => x.Damage);
                

                Console.WriteLine($"{item.Key}::({averageHealth:f2}/{averageDamage:f2}/{averageArmor:f2})");

                foreach (var anim in item.Value)
                {
                   
                    Console.WriteLine($"-{anim.Key} -> damage: {anim.Value.Health}, health: {anim.Value.Damage}, armor: {anim.Value.Armor}");
                    
                }
            }
        }

        class DragonPowers
        {
            public long Health { get; set; }
            public long Damage { get; set; }
            public long Armor { get; set; }
        }
        private static DragonPowers CreateDragon(long dragonDamage, long dragonHealth, long dragonArmor)
        {
            DragonPowers dragon = new DragonPowers();
            dragon.Damage = dragonDamage;
            dragon.Health = dragonHealth;
            dragon.Armor = dragonArmor;
            return dragon;
        }
    }
}