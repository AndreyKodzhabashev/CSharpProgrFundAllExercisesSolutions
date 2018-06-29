using System;
using System.Collections.Generic;
using System.Linq;

namespace _26_Feb_2017_Pr04_Hornet_Armada
{
    class _26_Feb_2017_Pr04_Hornet_Armada
    {
        // 70/100
        static void Main()
        {
            Dictionary<string, List<LegionProps>> dictLegions = new Dictionary<string, List<LegionProps>>();

            int linesCount = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < linesCount; i++)
            {
                string[] inputData = Console.ReadLine()
                    .Split(" =->:".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string legionName = inputData[1];

                long lastActivity = long.Parse(inputData[0]);
                string soldierType = inputData[2];
                long soldierCount = long.Parse(inputData[3]);

                LegionProps currentRecord = new LegionProps(soldierType, soldierCount, lastActivity);

                if (dictLegions.ContainsKey(legionName) == false)
                {
                    dictLegions[legionName] = new List<LegionProps>();
                    dictLegions[legionName].Add(currentRecord);

                }
                else
                {
                    var currentPropList = dictLegions[legionName];

                    int isProperty = currentPropList.FindIndex(x => x.SoldierType == soldierType);

                    if (isProperty == -1)
                    {
                        currentPropList.Add(currentRecord);
                    }
                    else
                    {


                        var temporary = currentPropList[isProperty];

                        temporary.SoldierCount += soldierCount;

                        long storedActivity = temporary.LastActivity;

                        if (storedActivity < lastActivity)
                        {
                            currentPropList[isProperty].LastActivity = lastActivity;
                        }
                    }
                }
            }


            string[] finalCommands = Console.ReadLine()
                .Split(new[] { '\\' }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            if (finalCommands.Length == 2)
            {
                long printActivity = long.Parse(finalCommands[0]);
                string printType1 = finalCommands[1];

                Dictionary<string, long> dictTemp101 = new Dictionary<string, long>();

                foreach (var legion in dictLegions)
                {
                    var tempList = dictLegions[legion.Key];


                    foreach (var group in tempList)
                    {
                        if (group.LastActivity < printActivity && group.SoldierType == printType1)
                        {
                            dictTemp101.Add(legion.Key, group.SoldierCount);

                        }
                    }

                }

                foreach (var item in dictTemp101.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"{item.Key} -> {item.Value}");
                }

            }
            else
            {
                string typeFinal = finalCommands[0];

                Dictionary<string, long> tempDictVar2 = new Dictionary<string, long>();

                foreach (var item in dictLegions)
                {
                    var temp3 = item.Value;

                    for (int k = 0; k < temp3.Count; k++)
                    {
                        var type = temp3[k];
                        if (type.SoldierType == typeFinal)
                        {
                            tempDictVar2.Add(item.Key, type.LastActivity);
                        }
                    }
                }

                foreach (var item in tempDictVar2.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"{item.Value} : {item.Key}");
                }
            }

        }
    }
    public class LegionProps
    {
        public LegionProps(string soldierType, long soldierCount, long lastActivity)
        {
            SoldierType = soldierType;
            SoldierCount = soldierCount;
            LastActivity = lastActivity;
        }

        public string SoldierType { get; set; }
        public long SoldierCount { get; set; }
        public long LastActivity { get; set; }
    }
}