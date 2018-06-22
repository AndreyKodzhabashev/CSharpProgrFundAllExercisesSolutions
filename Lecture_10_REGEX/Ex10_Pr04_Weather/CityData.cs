using System;
using System.Collections.Generic;
using System.Text;

namespace Ex10_Pr04_Weather
{
    class CityData
    {
        public CityData(string name, double avgTemp, string weatherType)
        {
            this.Name = name;
            this.AvgTemp = avgTemp;
            this.WeatherType = weatherType;
        }

        public string Name { get; set; }
        public double AvgTemp { get; set; }
        public string WeatherType { get; set; }
    }
}
