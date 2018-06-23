using System;

namespace ExamPprepII_Pr01_ChariryMarathon
{
    class ExamPprepII_Pr01_ChariryMarathon
    {
        static void Main()

            // 100/100
        {
            int daysRunning = int.Parse(Console.ReadLine());
            long countRunner = long.Parse(Console.ReadLine());
            long averageNumLapsPerRunner = long.Parse(Console.ReadLine());
            long trackLength = long.Parse(Console.ReadLine());
            long trackCapacity = long.Parse(Console.ReadLine());
            decimal moneyPerKilometer = decimal.Parse(Console.ReadLine());


            decimal totalMoney = 0;

            for (int i = 1; i <= daysRunning; i++)
            {

                long countCurrentRunners = 0;

                if (countRunner > trackCapacity)
                {
                    countCurrentRunners = trackCapacity;
                    countRunner -= countCurrentRunners;
                }
                else
                {
                    countCurrentRunners = countRunner;
                    countRunner -= countCurrentRunners;
                }

                long totalLaps = countCurrentRunners * averageNumLapsPerRunner;

                double totalMileageKM = (totalLaps * trackLength) / 1000;

                totalMoney += (decimal)totalMileageKM * moneyPerKilometer;
            }
            
            
            Console.WriteLine($"Money raised: {totalMoney.ToString("f2")}");

        }
    }
}