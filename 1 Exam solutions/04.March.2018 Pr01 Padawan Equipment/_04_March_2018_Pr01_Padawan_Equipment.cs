using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.March._2018_Pr01_Padawan_Equipment
{
    // 100/100
    class _04_March_2018_Pr01_Padawan_Equipment
    {
        static void Main()
        {
            //Reading input data from the console
            //Declaring and initializing the necessary variables
            double budget = double.Parse(Console.ReadLine());
            int countStudents = int.Parse(Console.ReadLine());
            double ligthSaberPrice = double.Parse(Console.ReadLine());
            double robesPrice = double.Parse(Console.ReadLine());
            double beltPrice = double.Parse(Console.ReadLine());

            //we calculate the lightsaber count needed. We have to round the result UP to the next integer. As the method Ceiling returns data type Double, we have to cast it to Int
            int ligthSabersCount = (int)Math.Ceiling(countStudents * 1.1);
            
            //calculate the count of free belts and declaring a new variable for total count of belts we have to buy
            int freebeltCount = countStudents / 6;
            int beltsTotalCount = countStudents - freebeltCount;

            //calculating the total sum we need to buy all items
            double neededMoney = ligthSabersCount * ligthSaberPrice + beltsTotalCount * beltPrice + countStudents * robesPrice;

            //we check if the money we have are enough and print to the console the necessary numers, rounded to the second digit after the floathing point.
            if (neededMoney <= budget)
            {
                //if the check result is True, we will enter here 
                Console.WriteLine($"The money is enough - it would cost {neededMoney:F2}lv.");
            }
            else
            {
                //if the check result is False, we will enter here
                Console.WriteLine($"Ivan Cho will need {(neededMoney - budget):F2}lv more.");
            }

        }
    }
}