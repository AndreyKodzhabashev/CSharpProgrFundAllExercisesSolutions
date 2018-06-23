using System;
using System.Collections.Generic;
using System.Numerics;
using System.Linq;

namespace _05_Nov_2017_Pr01_Anonymous_Downsite
{
    class _05_Nov_2017_Pr01_Anonymous_Downsite
    {        
        static void Main()
        {
            //Done - 100/100

            //input:
            //3
            //8
            //www.google.com 122300 94.23233
            //www.abv.bg 2333 11
            //www.kefche.com 12322 23.3222

            //output:
            //www.google.com
            //www.abv.bg
            //www.kefche.com
            //Total Loss: 11837653.10740000000000000000
            //Security Token: 512

            int damagedSites = int.Parse(Console.ReadLine());
            BigInteger securKey = BigInteger.Parse(Console.ReadLine());

            decimal totalLoss = 0M;

            List<string> sitesName = new List<string>();
            for (int i = 0; i < damagedSites; i++)
            {
                string[] currentInput = Console.ReadLine()
                    .Split(' ')
                    .ToArray();
                    
                sitesName.Add(currentInput[0]);

                long visits = long.Parse(currentInput[1]);
                decimal costPerVisit = decimal.Parse(currentInput[2]);

                decimal currentLoss = visits * costPerVisit;

                totalLoss += currentLoss;

            }
            BigInteger secToken = BigInteger.Pow(securKey, damagedSites);

            Console.WriteLine(string.Join(Environment.NewLine, sitesName));
            Console.WriteLine($"Total Loss: {totalLoss:f20}");
            Console.WriteLine($"Security Token: {secToken}");
        }
    }
}
