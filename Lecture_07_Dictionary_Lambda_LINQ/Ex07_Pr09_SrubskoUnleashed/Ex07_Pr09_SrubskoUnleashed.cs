using System;
using System.Collections.Generic;
using System.Linq;

namespace Ex07_Pr09_SrubskoUnleashed
{
    class Ex07_Pr09_SrubskoUnleashed
    {
        // 100/100
        static void Main()
        {
            Dictionary<string, Dictionary<string, long>> dictSingerData = new Dictionary<string, Dictionary<string, long>>();

            while (true)
            {
                int price;
                int ticketsCount;

                //TODO - read the input
                string input = Console.ReadLine();

                if (input.Equals("End"))
                {
                    break;
                }

                int indexOfKlyomba = input.IndexOf("@");

                if (input[indexOfKlyomba - 1].Equals(' ') == false)
                {
                    continue;
                }

                //TODO - extracting the singer`s name
                int nameLength = indexOfKlyomba;
                string singersName = input.Substring(0, nameLength).Trim();

                string[] inputData = input
                    .Split();

                //TODO - verify if the input is correct
                if (inputData.Length < 4)
                {
                    continue;
                }

                try
                {
                    price = int.Parse(inputData[inputData.Length - 1]);
                }
                catch (Exception)
                {
                    continue;
                }

                try
                {
                    ticketsCount = int.Parse(inputData[inputData.Length - 2]);

                }
                catch (Exception)
                {
                    continue;
                }

                //TODO - to extract the venue;
                string venue = string.Join("", input.Skip(indexOfKlyomba + 1));//.TakeWhile(x => x <= '9' == false &&  x >= '0' == false));

                List<string> tempVenue = venue
                    .Split()
                    .ToList();

                tempVenue.RemoveRange((tempVenue.Count - 2), 2);

                venue = string.Join(" ", tempVenue);

                long result = ticketsCount * price;
                //DONE

                //TODO - distributing the colected data
                if (dictSingerData.ContainsKey(venue))
                {
                    var temp = dictSingerData[venue];

                    if (temp.ContainsKey(singersName))
                    {
                        temp[singersName] += result;
                    }
                    else
                    {
                        temp.Add(singersName, result);
                    }
                }
                else
                {
                    var temp = new Dictionary<string, long>();
                    temp.Add(singersName, result);

                    dictSingerData.Add(venue, temp);
                }
            }

            foreach (var venue in dictSingerData)
            {
                Console.WriteLine(venue.Key);

                foreach (var singer in venue.Value.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"#  {singer.Key} -> {singer.Value}");
                }
            }

        }
    }
}