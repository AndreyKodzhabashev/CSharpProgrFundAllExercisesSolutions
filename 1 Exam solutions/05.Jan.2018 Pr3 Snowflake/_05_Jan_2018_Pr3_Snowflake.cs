using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _05.Jan._2018_Pr3_Snowflake
{
    class _05_Jan_2018_Pr3_Snowflake
    {
        static void Main()
        {
            string surface = Console.ReadLine();
            string mantle = Console.ReadLine();
            string core = Console.ReadLine();
            string mantle1 = Console.ReadLine();
            string surface1 = Console.ReadLine();

            string surfacePattern = @"\W";
            string mantlePattern = @"[\d_]+";
            string corePattern = @"[A-Za-z]+";
            string mantlePattern1 = @"[\d_]+";
            string surfacePattern1 = @"\W";


            Regex regexSf = new Regex(surfacePattern);
            Regex regexMn = new Regex(mantlePattern);
            Regex regexCr = new Regex(corePattern);
            Regex regexMn1 = new Regex(mantlePattern1);
            Regex regexSf1 = new Regex(surfacePattern1);

            bool isValidSurface = regexSf.IsMatch(surface);
            bool isValidMantle = regexMn.IsMatch(mantle);
            bool isValidCore = regexCr.IsMatch(core);
            bool isValidMantle1 = regexMn1.IsMatch(mantle1);
            bool isValidSurface1 = regexSf1.IsMatch(surface1);

            // core = regexSf.Replace(core, " ").ToString();

            //core = regexMn.Replace(core, " ").ToString();
            //core = regexMn1.Replace(core, " ").ToString();
            //core = regexSf1.Replace(core, " ").ToString();

            //core = core.Trim();
            //bool isCoreValid = false;

            //for (int i = 0; i < core.Length; i++)
            //{
            //    if ((65 <= core[i] && core[i] <= 09) || (97 < core[i] && core[i] <= 122))
            //    {
            //        isCoreValid = true;
            //    }
            //}

            Match finalCore = regexCr.Match(core);

            if (isValidSurface && isValidMantle && isValidSurface1 && isValidMantle1 && isValidCore)
            {
                Console.WriteLine("Valid");
                Console.WriteLine(finalCore.Length);
            }
            else
            { 
                Console.WriteLine("Invalid");
            }
        }
    }
}