using System;
using System.Collections.Generic;
using System.Linq;

namespace Ex07B_Pr04_Supermarket_Database
{
    class Ex07B_Pr04_Supermarket_Database
    {
        // 100/100
        static void Main()
        {

            Dictionary<string, double[]> dictMarketWharehouse
                = new Dictionary<string, double[]>();

            while (true)
            {
                string inputText = Console.ReadLine();

                if (inputText.Equals("stocked"))
                {
                    break;
                }

                string[] productAttribs = inputText
                    .Split(' ')
                    .ToArray();

                if (dictMarketWharehouse.ContainsKey(productAttribs[0]) == false)
                {
                    double[] arrQuantityAndPrice = new double[productAttribs.Length - 1];
                    arrQuantityAndPrice[0] = double.Parse(productAttribs[2]);
                    arrQuantityAndPrice[1] = double.Parse(productAttribs[1]);

                    dictMarketWharehouse.Add(productAttribs[0], arrQuantityAndPrice);
                }
                else
                {
                    var currentProductQuontityAndPrice = dictMarketWharehouse[productAttribs[0]];

                    currentProductQuontityAndPrice[0] += double.Parse(productAttribs[2]);
                    currentProductQuontityAndPrice[1] = double.Parse(productAttribs[1]);

                    dictMarketWharehouse[productAttribs[0]] = currentProductQuontityAndPrice;
                }
            }

            double grandTotal = 0;

            foreach (var product in dictMarketWharehouse)
            {

                var temp = product.Value;
                double total = temp[0] * temp[1];
                grandTotal += total;

                Console.WriteLine($"{product.Key}: ${temp[1]:F2} * {temp[0]} = ${total:F2}");

            }

            Console.WriteLine(new string('-', 30));
            Console.WriteLine($"Grand Total: ${grandTotal:F2}");
        }
    }
}