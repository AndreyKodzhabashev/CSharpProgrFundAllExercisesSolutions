using System;

namespace Ex08_Pr03_Inttersection_of_Sircle
{
    class Ex08_Pr03_Inttersection_of_Sircle
    {
        // 100/100
        static void Main()
        {
            string[] firstCircleInput = Console.ReadLine().Split(' ');
            string[] secondCircleInput = Console.ReadLine().Split(' ');

            //create the first center point and set the first circle properties

            Circle firstCircle = new Circle();
            firstCircle.Radius = double.Parse(firstCircleInput[2]);
            firstCircle.X = double.Parse(firstCircleInput[0]);
            firstCircle.Y = double.Parse(firstCircleInput[1]);
            //create the second center point and set the second circle properties

            Circle secondCircle = new Circle();
            secondCircle.Radius = double.Parse(secondCircleInput[2]);
            secondCircle.X = double.Parse(secondCircleInput[0]);
            secondCircle.Y = double.Parse(secondCircleInput[1]);

            bool circlesIntersect = Intersect(firstCircle, secondCircle);
            if (circlesIntersect)
            {
                Console.WriteLine("Yes");
            }
            else
            {
                Console.WriteLine("No");
            }
        }
        static public bool Intersect(Circle firstCircle, Circle secondCircle)
        {
            //find the distance between the points
            double deltaX = Math.Abs(firstCircle.X - secondCircle.X);
            double deltaY = Math.Abs(firstCircle.Y - secondCircle.Y);
            double distance = Math.Sqrt(Math.Pow(deltaX, 2) + Math.Pow(deltaY, 2));
            double sumRadiuses = firstCircle.Radius + secondCircle.Radius;
            //if the distance between the points is greater than the sum of the radiuses AND
            //if the radius of the smaller circle + the distance between the points is NOT
            //less than the radius of the larger circle, the circles intersect
            /* !(Math.Min(firstCircle.Radius, secondCircle.Radius) +
                distance < Math.Max(firstCircle.Radius, secondCircle.Radius)) */
            if (sumRadiuses >= distance)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
    public class Circle
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Radius { get; set; }
    }
}