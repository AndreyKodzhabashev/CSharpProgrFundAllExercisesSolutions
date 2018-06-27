using System;
using System.Collections.Generic;
using System.Linq;

namespace _05_Nov_2018_Pr04_AnonimousCache
{
    class _05_Nov_2018_Pr04_AnonimousCache
    {
        // 100/100
        static void Main()
        {
            
            Dictionary<string, Dictionary<string, long>> dictColectedData = new Dictionary<string, Dictionary<string, long>>();

            Dictionary<string, Dictionary<string, long>> dictTempDataStore = new Dictionary<string, Dictionary<string, long>>();

            while (true)
            {
                string[] inputLine = Console.ReadLine()
                   
                    .Split(new[] { ' ', '-', '>', '|' }, StringSplitOptions.RemoveEmptyEntries)
                    ;

                if (inputLine[0].Equals("thetinggoesskrra", StringComparison.InvariantCultureIgnoreCase))
                {
                    break;
                }

                if (inputLine.Length == 1)
                {
                    string dataSet = inputLine[0];

                    if (dictTempDataStore.ContainsKey(dataSet))
                    {
                        dictColectedData[dataSet] = new Dictionary<string, long>(dictTempDataStore[dataSet]);
                        dictTempDataStore.Remove(dataSet);
                    }
                    else
                    {
                        dictColectedData[dataSet] = new Dictionary<string, long>();

                    }
                }
                else
                {
                    string dataKey = inputLine[0];
                    long dataSize = long.Parse(inputLine[1]);
                    string dataSet = inputLine[2];

                    if (dictColectedData.ContainsKey(dataSet) == false)
                    {
                        if (dictTempDataStore.ContainsKey(dataSet) == false)
                        {
                            dictTempDataStore[dataSet] = new Dictionary<string, long>();
                        }

                        dictTempDataStore[dataSet][dataKey] = dataSize;
                    }
                    else
                    {
                        dictColectedData[dataSet][dataKey] = dataSize;
                    }
                }

            }
            if (dictColectedData.Count > 0)
            {

                KeyValuePair<string, Dictionary<string, long>> result = dictColectedData
                    .OrderByDescending(ds => ds.Value.Sum(x => x.Value)).First();

                Console.WriteLine($"Data Set: {result.Key}, Total Size: {result.Value.Sum(x => x.Value)}");

                string prefix = "$.";

                foreach (var value in result.Value)
                {
                    Console.WriteLine($"{prefix}{value.Key}");
                }
            }
        }
    }
}
