using System;
using System.Linq;
using System.Collections.Generic;

namespace ExamPrepII_Pr02_Ladybugs
{
    class ExamPrepII_Pr02_Ladybugs
    {
        static void Main()
        {
            // 80/100 points

            //TODO - creation of the field and initialization the initial ladybugs places
            int fieldSize = int.Parse(Console.ReadLine());

            long[] arrField = new long[fieldSize];

            Console.ReadLine()
                .Split(new[] { ' ' })
                .Select(int.Parse)
                .Where(x => x >= 0 && x < fieldSize)
                .ToList()
                .ForEach(x => arrField[x] = 1);
            //DONE - field created, ladybugs placed

            // we start to receiving the command lines
            while (true)
            {
                string command = Console.ReadLine();

                if (command.Equals("end"))
                {
                    break;
                }
                
                // splitting the three separate commands
                string[] commandProps = command
                    .Split(new[] { ' ' })
                    .Select(x => x.ToString().Trim())
                    .ToArray();

                long startPoint = long.Parse(commandProps[0]);
                //verify if the start point is in the field range. If it`s not - we skip to the next command line
                if (IndexIsInTheFieldRange(startPoint, fieldSize) == false)
                {
                    continue;
                }

                //if there is no bug at the starting point - we skip this round and continuing with the next command line
                if (arrField[startPoint] == 0)
                {
                    continue;
                }

                string direction = commandProps[1];
                long flyLength = long.Parse(commandProps[2]);

                //correction of the fly direction
                //for example, if the direction is "left", but the flight lenght is negative number (-4), actualy, the bug will fly in the opposite direction
                string corectedDirection = CorectionFlghtDirection(direction, flyLength);

                //if there is need for the direction to be corrected, so we have to correct also the sign of the flyLength

                if (direction == corectedDirection == false)
                {
                    flyLength = Math.Abs(flyLength);
                }

                // and now - we have to hit the sky. Let the flight beggins!!!

                switch (corectedDirection)
                {
                    case "left":
                        for (long i = startPoint; i >= 0; i -= flyLength)
                        {

                            if (arrField[i] == 0)
                            {
                                arrField[i] = 1;
                                arrField[startPoint] = 0;
                                break;
                            }

                            arrField[startPoint] = 0;
                        }

                        break;

                    case "right":

                        for (long i = startPoint; i < arrField.Length; i += flyLength)
                        {

                            if (arrField[i] == 0)
                            {
                                arrField[i] = 1;
                                arrField[startPoint] = 0;
                                break;
                            }
                            arrField[startPoint] = 0;
                        }

                        break;
                }                
            }

            //printing the result
            Console.WriteLine(string.Join(" ", arrField));
        }
        static bool IndexIsInTheFieldRange(long num, long fieldSize)
        {
            if (num < 0 || num > fieldSize - 1)
            {
                return false;
            }

            return true;
        }

        static string CorectionFlghtDirection(string direction, long num)
        {
            if (direction.Equals("left") && num < 0)
            {
                return "right";
            }

            if (direction.Equals("right") && num < 0)
            {
                return "left";
            }
            return direction;
        }
    }
}