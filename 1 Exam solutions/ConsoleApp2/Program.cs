using System;

namespace ConsoleApp2
{
    class Program
    {
        static void Main()
        {
            string month = Console.ReadLine().ToLower();
            int nights = int.Parse(Console.ReadLine());


            double studio = 0;
            double doubeRoom = 0;
            double suite = 0;

            double discountStudio = 0;
            double discountDouble = 0;
            double discountSuite = 0;

            double extraNightStudio = 0;

            switch (month)
            {
                case "may":
                case "october":
                    studio = 50;
                    suite = 75;
                    doubeRoom = 65;
                    break;
                case "june":
                case "september":
                    studio = 60;
                    doubeRoom = 72;
                    suite = 82;
                    break;
                case "july":
                case "august":
                case "december":
                    studio = 68;
                    doubeRoom = 77;
                    suite = 89;
                    break;
            }

            if (7 < nights)
            {
                if (month.Equals("may") || month.Equals("october"))
                {
                    discountStudio = 5 * 1.0 / 100;
                }
                if (month.Equals("september") || month.Equals("october"))
                {
                    extraNightStudio = 1;
                }

            }
            if (14 < nights)
            {
                if (month.Equals("june") || month.Equals("september"))
                {
                    discountStudio = 10 * 1.0 / 100;
                }
                if (month.Equals("july") || month.Equals("august") || month.Equals("December"))
                {
                    discountSuite = 15 * 1.0 / 100;
                }
            }

            Console.WriteLine($"Studio: {(nights - extraNightStudio) * (studio - studio * discountStudio):f2} lv.");
            Console.WriteLine($"Double: {nights * (doubeRoom - doubeRoom * discountDouble):f2} lv.");
            Console.WriteLine($"Suite: {nights * (suite - suite * discountSuite):f2} lv.");

        }
    }
}