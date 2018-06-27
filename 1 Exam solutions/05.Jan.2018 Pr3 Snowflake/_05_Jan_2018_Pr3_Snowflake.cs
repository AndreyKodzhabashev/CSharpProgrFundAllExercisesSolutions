using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _05.Jan._2018_Pr3_Snowflake
{
    // 100/100
    class _05_Jan_2018_Pr3_Snowflake
    {
        static void Main()
        {
            //TODO - reading the input text
            string surface = Console.ReadLine();
            string mantle = Console.ReadLine();
            string totalSnowflake = Console.ReadLine();
            string mantle1 = Console.ReadLine();
            string surface1 = Console.ReadLine();

            //TODO - creating REGEX patterns according the specified rules
            string surfacePattern = @"^([^A-Za-z0-9]+)$";
            string mantlePattern = @"^([0-9_]+)$";
            string totalFlakePattern = @"([^A-Za-z0-9]+)([0-9_]+)([A-Za-z]+)([0-9_]+)([^A-Za-z0-9]+)";

            //TODO - decraring REGEX with the suitable pattern
            Regex regexSf = new Regex(surfacePattern);
            Regex regexMn = new Regex(mantlePattern);
            Regex regexCr = new Regex(totalFlakePattern);
            
            //TODO - virification if the given input lines are correct
            //as the start and end Surface and Mantel have to be equal, we use the same regex pattern for verification
            bool isValidSurface = regexSf.IsMatch(surface);
            bool isValidMantle = regexMn.IsMatch(mantle);
            bool isValidCore = regexCr.IsMatch(totalSnowflake);
            bool isValidMantle1 = regexMn.IsMatch(mantle1);
            bool isValidSurface1 = regexSf.IsMatch(surface1);

            //TODO = extracting a MATCH form the total Snowflake input line
            Match finalCore = regexCr.Match(totalSnowflake);

            //TODO - if all bools are VALID print "Valid" and the count of group 3, which should be the Snowflake core
            if (isValidSurface && isValidMantle && isValidSurface1 && isValidMantle1 && isValidCore)
            {
                Console.WriteLine("Valid");
                Console.WriteLine(finalCore.Groups[3].Value.Length);
            }
            //if even one line is invalid
            else
            {
                Console.WriteLine("Invalid");
            }
        }
    }
}