using System;

namespace ExamPreIV_Pr01_Sweet_Dessert
{
    // 100/100
    class ExamPreIV_Pr01_Sweet_Dessert
    {
        static void Main(string[] args)
        {
            decimal totalCash = decimal.Parse(Console.ReadLine());
            int guestNumber = int.Parse(Console.ReadLine());
            decimal priceBananas = decimal.Parse(Console.ReadLine());
            decimal priceEggs = decimal.Parse(Console.ReadLine());
            decimal priceBerryKilo = decimal.Parse(Console.ReadLine());

            decimal dessertSets = (decimal)Math.Ceiling(guestNumber * 1.0 / 6);

            decimal totalPrice = dessertSets * (priceBananas * 2 + priceEggs * 4 + priceBerryKilo * 0.2m);

            if (totalCash >= totalPrice)
            {
                Console.WriteLine($"Ivancho has enough money - it would cost {totalPrice:F2}lv.");
            }
            else
            {
                Console.WriteLine($"Ivancho will have to withdraw money - he will need {totalPrice - totalCash:F2}lv more.");
            }
        }
    }
}