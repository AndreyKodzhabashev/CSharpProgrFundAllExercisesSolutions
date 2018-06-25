using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace ExamPrepII_Pr03_NetherRealms
{
    class ExamPrepII_Pr03_NetherRealms
    {
        // 90/100 -  test 5 - runtime error
        static void Main()
        {
            //Reading the input
            string inputDemons = Console.ReadLine();

            //Splitting different deamons, if any
            string[] deamonsNames = inputDemons
                .Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            //Trim each deamon to remove white spaces before and after the name, if any
            for (int i = 0; i < deamonsNames.Length; i++)
            {
                deamonsNames[i] = deamonsNames[i].Trim();
            }

            //creating Class Deamon and list to store deamonst
            List<Deamon> listDaemons = new List<Deamon>();

            //start to process every entry
            for (int i = 0; i < deamonsNames.Length; i++)
            {

                string currentDeamon = deamonsNames[i];
                //extracting Damage of the current deamon
                string regexPatternDamage = @"[0-9\.\-\+]+";
                Regex regexDamage = new Regex(regexPatternDamage);
                MatchCollection DamageBase = regexDamage.Matches(currentDeamon);

                double damage = 0;

                foreach (Match item in DamageBase)
                {
                    damage += double.Parse(item.Value);
                }

                foreach (var item in currentDeamon)
                {
                    if (item == '/')
                    {
                        damage /= 2;
                    }
                    else if (item == '*')
                    {
                        damage *= 2;
                    }
                }

                //lets deal with the Health

                string regexPatternHealth = @"[^0-9\.\+\-\*\/]";

                Regex regexHealth = new Regex(regexPatternHealth);

                MatchCollection totalHealth = regexHealth.Matches(currentDeamon);
                List<int> tempHealth = new List<int>();

                foreach (Match item in totalHealth)
                {

                    tempHealth.Add(char.Parse(item.Value));
                }

                double health = tempHealth.Sum();

                listDaemons.Add(new Deamon(currentDeamon, health, damage));

            }

            foreach (var deamon in listDaemons.OrderBy(x => x.Name))
            {

                Console.WriteLine($"{deamon.Name} - {deamon.Health} health, {deamon.Damage:f2} damage");
            }
        }
    }
}