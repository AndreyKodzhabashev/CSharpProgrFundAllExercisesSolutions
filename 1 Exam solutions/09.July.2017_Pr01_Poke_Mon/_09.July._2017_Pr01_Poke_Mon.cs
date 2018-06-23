using System;
using System.Numerics;

namespace _09.July._2017_Pr01_Poke_Mon
{
    class _09_July_2017_Pr01_Poke_Mon
    {
        // 90/100 - + RunTime Error
        static void Main()
        {
            long N = long.Parse(Console.ReadLine());
            long M = long.Parse(Console.ReadLine());
            long Y = long.Parse(Console.ReadLine());

            int pokeCount = 0;

            long fif = N;

            double fifthy = N * 1.0 / 2;

            while (N >= M)
            {
                pokeCount++;

                N = N - M;

                if (N == fifthy)
                {
                    N = N / Y;
                }

            }

            Console.WriteLine(N);
            Console.WriteLine(pokeCount);

        }
    }
}