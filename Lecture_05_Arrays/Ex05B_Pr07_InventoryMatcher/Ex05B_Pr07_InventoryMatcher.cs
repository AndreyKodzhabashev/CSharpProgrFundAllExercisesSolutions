using System;

namespace Ex05B_Pr07_InventoryMatcher
{
    class Ex05B_Pr07_InventoryMatcher
    {
        // 100/100
        static void Main()
        {
            string[] productsName = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            long[] productQuantities = Array.ConvertAll(Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries), s => long.Parse(s));

            string[] productPrice = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            while (true)
            {
                string product = Console.ReadLine();

                if (product.Equals("done"))
                {
                    return;
                }
                else
                {
                    int productIndex = Array.IndexOf(productsName, product);
                    
                    Console.WriteLine($"{product} costs: {productPrice[productIndex]}; Available quantity: {productQuantities[productIndex]}");

                }
            }
        }
    }
}
