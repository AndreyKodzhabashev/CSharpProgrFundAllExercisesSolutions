using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace _05_Jan_2018_Pr01_Snowballs_var2
{
    class _05_Jan_2018_Pr01_Snowballs_var2
    {
        static void Main()
        {

            BigInteger ballCount = BigInteger.Parse(Console.ReadLine());

            List<SnowBall> listBalls = new List<SnowBall>();

            for (BigInteger i = 0; i < ballCount; i++)
            {
                BigInteger snow = BigInteger.Parse(Console.ReadLine());
                BigInteger time = BigInteger.Parse(Console.ReadLine());
                BigInteger quallity = BigInteger.Parse(Console.ReadLine());

                BigInteger result = (BigInteger)BigInteger.Pow((snow / time), (int)quallity);

                SnowBall currentBall = new SnowBall( snow, time, quallity, result);

                listBalls.Add(currentBall);
            }

            foreach (var ball in listBalls.OrderByDescending(x =>x.Result))
            {

                Console.WriteLine($"{ball.Snow} : {ball.Time} = {ball.Result} ({ball.Quallity})");
                break;

            }

        }
    }
    class SnowBall
    {
        public SnowBall(BigInteger snow, BigInteger time, BigInteger quallity, BigInteger result)
        {
            Snow = snow;
            Time = time;
            Quallity = quallity;
            Result = result;
        }

        public BigInteger Snow { get; set; }
        public BigInteger Time { get; set; }
        public BigInteger Quallity { get; set; }

        public BigInteger Result { get; set; }
    }
}