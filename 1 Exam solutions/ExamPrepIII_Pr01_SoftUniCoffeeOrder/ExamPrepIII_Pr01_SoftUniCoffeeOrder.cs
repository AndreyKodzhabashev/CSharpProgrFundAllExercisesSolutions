using System;
using System.Globalization;
namespace ExamPrepIII_Pr01_SoftUniCoffeeOrder
{
    class ExamPrepIII_Pr01_SoftUniCoffeeOrder
    {
        // 100/100
        static void Main()
        {
            
            int ordersCount = int.Parse(Console.ReadLine());

            decimal totalPrice = 0;

            for (int i = 0; i < ordersCount; i++)
            {

                decimal pricePerCapsule = decimal.Parse(Console.ReadLine());

                DateTime purchaseDate = DateTime.ParseExact(Console.ReadLine(), "d/M/yyyy", CultureInfo.InvariantCulture);

                long capsulesCount = long.Parse(Console.ReadLine());
                
                int daysInMonth = DateTime.DaysInMonth(purchaseDate.Year, purchaseDate.Month);
                                
            decimal pricePerOrder = (daysInMonth * capsulesCount) * pricePerCapsule;


                Console.WriteLine($"The price for the coffee is: ${pricePerOrder:F2}");

                totalPrice += pricePerOrder;

            }

            Console.WriteLine($"Total: ${totalPrice:F2}");

        }
    }
}