using System;
using System.Collections.Generic;

namespace _05.Jan._2018_Pr01_Snowballs
{
    class _05_Jan_2018_Pr01_Snowballs
    {
        static void Main()
        {

            //80/100 - с double ; когато замених с decimal - единият от грешните тестове дори не тръгна
            List<int> listSnowData = new List<int>();
            List<int> listTimeData = new List<int>();
            List<int> listQltData = new List<int>();
            List<decimal> listTotalData = new List<decimal>();

            int countBalls = int.Parse(Console.ReadLine());

            decimal total = 0;
            decimal maxResult = 0;
            int maxCounter = 0;

            for (int i = 0; i < countBalls; i++)
            {
                int snow = int.Parse(Console.ReadLine());
                int time = int.Parse(Console.ReadLine());
                int quality = int.Parse(Console.ReadLine());

                double snowTime = snow / time;

                total = (decimal)Math.Pow(snowTime, quality);

                listSnowData.Add(snow);
                listTimeData.Add(time);
                listQltData.Add(quality);
                listTotalData.Add(total);

                if (total > maxResult)
                {
                    maxResult = total;
                    maxCounter++;
                }
            }

            Console.WriteLine($"{ listSnowData[maxCounter - 1]} : { listTimeData[maxCounter - 1]} = { listTotalData[maxCounter - 1]} ({ listQltData[maxCounter - 1]})");
        }
    }
}
