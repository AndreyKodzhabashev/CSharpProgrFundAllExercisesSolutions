using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Ex08_Pr06_BookLibraryModification
{
    class Ex08_Pr05_BookLibrary
    {
        // 100/100
        static void Main()
        {

            int n = int.Parse(Console.ReadLine());

            Dictionary<string, decimal> moneyMade = new Dictionary<string, decimal>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                string nameofAuthor = input[1];

                decimal money = decimal.Parse(input[5]);

                if (moneyMade.ContainsKey(nameofAuthor) == false)
                {
                    moneyMade.Add(nameofAuthor, 0);
                }
                moneyMade[nameofAuthor] += money;
            }
            foreach (var item in moneyMade.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine(item.Key + " -> " + string.Format("{0:F2}", item.Value));
            }
        }

    }
}