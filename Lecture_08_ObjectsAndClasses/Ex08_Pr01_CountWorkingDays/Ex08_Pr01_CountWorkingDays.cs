using System;
using System.Globalization;

namespace Ex08_Pr01_CountWorkingDays
{
    class Ex08_Pr01_CountWorkingDays
    {
        // 100/100
        static void Main()
        {
            string datePattern = "dd-MM-yyyy";

            DateTime[] oficialHolidays = new DateTime[] {
                new DateTime(4,01,01),
                new DateTime(4,03,03),
                new DateTime(4,05,01),
                new DateTime(4,05,06),
                new DateTime(4,05,24),
                new DateTime(4,09,06),
                new DateTime(4,09,22),
                new DateTime(4,11,01),
                new DateTime(4,12,24),
                new DateTime(4,12,25),
                new DateTime(4,12,26)

            };

            string firstDate = Console.ReadLine();
            string secondDate = Console.ReadLine();

            DateTime startDate = new DateTime();
            startDate = DateTime.ParseExact(firstDate, datePattern, CultureInfo.InvariantCulture);

            DateTime endDate = new DateTime();
            endDate = DateTime.ParseExact(secondDate, datePattern, CultureInfo.InvariantCulture);

            int counter = 0;

            for (DateTime i = startDate; i <= endDate; i = i.AddDays(1))
            {
                
                if (!(i.DayOfWeek == DayOfWeek.Saturday) &&
                    !(i.DayOfWeek == DayOfWeek.Sunday))
                {
                    counter++;


                    foreach (var item in oficialHolidays)
                    {
                        if (i.Day == item.Day && i.Month == item.Month)
                        {
                            counter--;
                        }
                    }
                }
            }

            Console.WriteLine(counter);
        }
    }
}
