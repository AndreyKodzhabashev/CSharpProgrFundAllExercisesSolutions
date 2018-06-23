using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace Ex07_Pr03_A_Miner_Task
{
    class Ex07_Pr03_A_Miner_Task
    {
        // 100/100
        static void Main()
        {

            Dictionary<string, BigInteger> dictItems = new Dictionary<string, BigInteger>();
            int counter = 1;
            
            string tempQuantity = "";

            while (true)
            {
                string tempItem = Console.ReadLine();

                if (tempItem == "stop")
                {
                    foreach (var item in dictItems)
                    {
                        Console.WriteLine($"{item.Key} -> {item.Value}");
                    }
                    return;
                }

                if (counter % 2 != 0)
                {
                    tempQuantity = Console.ReadLine();
                    counter = 1;
                }
                
                if (dictItems.ContainsKey(tempItem))
                {
                    dictItems[tempItem] += (int.Parse(tempQuantity));
                }
                else
                {
                    dictItems.Add(tempItem, int.Parse(tempQuantity));
                }

                tempQuantity = "";

            }
        }
    }
}