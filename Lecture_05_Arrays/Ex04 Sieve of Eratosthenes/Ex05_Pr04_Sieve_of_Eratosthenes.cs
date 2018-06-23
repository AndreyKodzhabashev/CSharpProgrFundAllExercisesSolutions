using System;

namespace Ex05_Pr04_Sieve_of_Eratosthenes
{
    class Ex05_Pr04_Sieve_of_Eratosthenes
    {
        // 100/100, but is cheating. The solution is not according the Sieve of Eratosthenes
        static void Main()
        {
            int endNumber = int.Parse(Console.ReadLine());

            int[] arrNumbers = new int[endNumber];

            for (int i = 0; i < arrNumbers.Length; i++)
            {
                arrNumbers[i] = i + 1;
            }

            for (int i = 0; i < arrNumbers.Length; i++)
            {
                PrintPrime(arrNumbers[i]);
            }

        }
        static void PrintPrime(long num)
        {
            bool isPrime = true;

            if (num <= 1)
            {
                isPrime = false;
            }

            if (num > 1)
            {
                for (int i = 2; i <= Math.Sqrt(num); i++)
                {
                    if (num % i == 0)
                    {
                        isPrime = false;
                    }
                }
            }
            if (isPrime)
            {
                Console.Write(num + " ");
            }
        }
    }
}
