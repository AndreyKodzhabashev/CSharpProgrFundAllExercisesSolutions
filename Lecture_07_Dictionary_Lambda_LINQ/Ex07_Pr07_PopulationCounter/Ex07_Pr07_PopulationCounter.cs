using System;
using System.Collections.Generic;
using System.Linq;


namespace Ex07_Pr07_PopulationCounter
{
    class Ex07_Pr07_PopulationCounter
    {
        // 100/100
        static void Main()
        {
            Dictionary<string, Dictionary<string, ulong>> dictPopulCounter = new Dictionary<string, Dictionary<string, ulong>>();

            while (true)
            {
                //TODO - prepraring the input data;

                string inputData = Console.ReadLine();
              
                if (inputData.ToLower().Equals("report"))
                {
                    break;
                }
                
                string[] tempData = inputData
                    .Split('|', StringSplitOptions.RemoveEmptyEntries)
                    ;

                string city = tempData[0];
                string country = tempData[1];
                ulong peopleCount = ulong.Parse(tempData[2]);

                //DONE - input data and break condition

                //TODO - collecting all data
                
                if (dictPopulCounter.ContainsKey(country) == false)
                {

                    Dictionary<string, ulong> temp = new Dictionary<string, ulong>();
                    temp.Add(city, peopleCount);

                    dictPopulCounter[country] = temp;
                    
                }
                else
                {
                   dictPopulCounter[country].Add(city,peopleCount);
                    
                }
                
                //DONE - data collected. We are waiting the BreakCondition - "report"

            }
            // TODO - lets calculate total population if each country and put it to a collection

            Dictionary<string, ulong> dictTotalPopulation = new Dictionary<string, ulong>();
            foreach (var country in dictPopulCounter)
            {
                ulong sum = 0;

                foreach (var city in country.Value)
                {
                    sum += city.Value;
                }
                dictTotalPopulation.Add(country.Key, sum);

             //DONE - calculated population of each country            
            }
            //TODO - lets print country => population, descending by population
            foreach (var country in dictTotalPopulation.OrderByDescending(c => c.Value))
            {
                Console.WriteLine($"{country.Key} (total population: {country.Value})");

                //TODO - lets print the cities, descending by population count

                var cities = dictPopulCounter[country.Key];

                foreach (var city in cities.OrderByDescending(c =>c.Value))
                {
                    Console.WriteLine($"=>{city.Key}: {city.Value}");
                }
                
            }
        }
    }
}