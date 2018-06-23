using System;
using System.Linq;
using System.Text;

namespace Ex05B_Pr05_PizzaIngredients
{
    //100/100
    class Ex05B_Pr05_PizzaIngredients
    {
        static void Main(string[] args)
        {
            string[] arrStoreInventory = Console.ReadLine()
                .Split()
                .ToArray();

            int lenghtOfIngredient = int.Parse(Console.ReadLine());

            int ingredCount = -1;


            string[] arrAddedIngreds = new string[10];

            foreach (var ingred in arrStoreInventory)
            {
                if (ingred.Length == lenghtOfIngredient)
                {
                    
                    ingredCount++;
                    arrAddedIngreds[ingredCount] = ingred;

                    Console.WriteLine($"Adding {ingred}.");
                }

                if (ingredCount == 9)
                {
                    break;
                }
            }
            
            Console.WriteLine($"Made pizza with total of {ingredCount + 1} ingredients.");
            Console.WriteLine($"The ingredients are: {string.Join(", ", arrAddedIngreds.TakeWhile(x => x == null == false).ToArray())}.");
        }
    }
}
