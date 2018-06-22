using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Ex10_Pr04_Weather
{
    class Ex10_Pr04_Weather
    {
        // 100/100
        static void Main()
        {
            //TODO - create a Class CityData to store the propetries for each city.
            //And a list where to store the instances of the class CityData
            List<CityData> listCities = new List<CityData>();
            //DONE - the Class is at the end of the page

            //TODO - create endless loop and the condition ot its break;
            /*in the loop:
            - creating REGEX pattern
            - applying it over the inputed text
            - verifying if there is a valid data about a city(if NO - we skip the current loop turn)
            - extracting the data about name, temperature and weathertype
            - verifying if the city has already been created and in this loop turn we just receiving a data update
                if NO - we create new instance of the Class CityData 
                if YES - we extract the record about the city, stored in the listCities and rewrite the temperature and watherType data */

            while (true)
            {
                //TODO read the input text and create a break rule
                string inputText = Console.ReadLine();
                if (inputText.Equals("end"))
                {
                    break;
                }
                //DONE

                //TODO - create a REGEX pattern and REGEX instance
                Regex regex = new Regex(@"([A-Z]{2})([0-9]+\.[0-9]+)([A-Za-z]+)(?=\|)");
                //DONE

                //TODO - verify if there is valid data and exract it. Skip the loop turn if there is no valid data
                Match forcast = regex.Match(inputText);
                if (forcast.Groups.Count < 4)
                {
                    continue;
                }
                //DONE

                //TODO - create variables for the city propetries
                string name = forcast.Groups[1].ToString();
                double avgTemp = double.Parse(forcast.Groups[2].ToString());
                string weatherType = forcast.Groups[3].ToString();
                //DONE

                //TODO - verify if the received data is about a new or already recorded city
                int existsCity = listCities.FindIndex(x => x.Name == name);
                
                //new city
                if (existsCity == -1)
                {
                    CityData currentCity = new CityData(name, avgTemp, weatherType);

                    listCities.Add(currentCity);
                }
                //recorded city
                else
                {
                    listCities[existsCity].AvgTemp = avgTemp;
                    listCities[existsCity].WeatherType = weatherType;
                }
                //DONE
            }
            //DONE the whole loop

            //TODO - print the result
            foreach (var city in listCities.OrderBy(x => x.AvgTemp))
            {

                Console.WriteLine($"{city.Name} => {city.AvgTemp:f2} => {city.WeatherType}");
            }
            //DONE
        }
    }
}