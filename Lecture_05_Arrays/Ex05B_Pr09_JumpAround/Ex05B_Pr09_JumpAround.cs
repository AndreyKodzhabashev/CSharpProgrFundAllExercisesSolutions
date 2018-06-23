using System;
using System.Linq;

namespace Ex05B_Pr09_JumpAround
{
    class Ex05B_Pr09_JumpAround
    {
        // 60/100
        static void Main()
        {
            int[] arrNumbers = Array.ConvertAll(Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries), x => int.Parse(x));

            int sum = arrNumbers[0];

            int currentPosition = 0;
            int jumper = arrNumbers[0];

            int roundCounter = 0;

            while ((jumper + currentPosition) < arrNumbers.Length )
            {
                //if (roundCounter == 0 == false && currentPosition - jumper > -1 == false)
                //{
                //    break;

                //}
                while ((currentPosition + jumper) < arrNumbers.Length)
                {
                    int currentIndexValueRight = arrNumbers[jumper];

                    sum += currentIndexValueRight;

                    currentPosition += jumper;

                    jumper = currentIndexValueRight;
                }

                --jumper;

                while ((currentPosition - jumper) > -1)
                {
                    int currentIndexValueLeft = arrNumbers[jumper];

                    sum += currentIndexValueLeft;

                    currentPosition -= jumper;

                    jumper = currentIndexValueLeft;
                                        
                }
                ++jumper;

                roundCounter++;
            }
            Console.WriteLine(sum);
        }
    }
}
