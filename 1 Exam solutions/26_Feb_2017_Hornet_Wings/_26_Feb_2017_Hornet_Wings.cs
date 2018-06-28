using System;

namespace _26_Feb_2017_Hornet_Wings
{
    class _26_Feb_2017_Hornet_Wings
    {
        // 100/100
        static void Main()
        {

            int wingsFlap = int.Parse(Console.ReadLine());
            double distancePer1000Flaps = double.Parse(Console.ReadLine());
            int endurance = int.Parse(Console.ReadLine());

            // constant = 100 flaps per second
            //calculate distance
            double distance = (wingsFlap * 1.0 / 1000) * distancePer1000Flaps;

            //calculate main time
            double mainSecs = wingsFlap * 1.0 / 100;
            //calculate additional time
            double additSeconds = (wingsFlap / endurance) * 5;
            //calculate total time
            double totalSecs = additSeconds + mainSecs;

            //print
            Console.WriteLine($"{distance.ToString("f2")} m.");
            Console.WriteLine($"{totalSecs} s.");

        }
    }
}