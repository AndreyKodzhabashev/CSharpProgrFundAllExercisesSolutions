using System;

namespace Ex05B_Pr08_UpgradedMatcher
{
    class Ex05B_Pr08_UpgradedMatcher
    {
        // 100/100 There is wrong answer
        static void Main()
        {
            string[] productsName = Console.ReadLine()
                 .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            long[] productQuantities = Array.ConvertAll(Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries), s => long.Parse(s));

            string[] productPrice = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            while (true)
            {
                string[] productAndQuantity = Console.ReadLine()
                    .Split();

                string product = productAndQuantity[0];


                if (product.Equals("done"))
                {
                    return;
                }
                else
                {
                    

                    int productIndex = Array.IndexOf(productsName, product);

                    long quantity;

                    if (productIndex > productQuantities.Length - 1)
                    {
                        quantity = 0;
                        Console.WriteLine($"We do not have enough {product}");
                        continue;
                    }
                    else
                    {
                        quantity = long.Parse(productAndQuantity[1]);
                    }

                    if (quantity > productQuantities[productIndex])
                    {
                        Console.WriteLine($"We do not have enough {product}");
                    }
                    else
                    {
                        Console.WriteLine($"{product} x {quantity} costs {(quantity * double.Parse(productPrice[productIndex])):f2}");

                        productQuantities[productIndex] -= quantity;
                    }
                }
            }
        }
    }
}