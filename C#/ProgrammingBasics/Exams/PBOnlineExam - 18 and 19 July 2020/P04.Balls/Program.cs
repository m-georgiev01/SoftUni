using System;

namespace P04.Balls
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            double points = 0;

            int redBalls = 0;
            int orangeBalls = 0;
            int yellowBalls = 0;
            int whiteBalls = 0;
            int blackBalls = 0;
            int otherBalls = 0;

            for (int i = 0; i < n; i++)
            {
                string ball = Console.ReadLine();

                switch (ball)
                {
                    case "red":
                        points += 5;
                        redBalls++;
                        break;

                    case "orange":
                        points += 10;
                        orangeBalls++;
                        break;

                    case "yellow":
                        points += 15;
                        yellowBalls++;
                        break;

                    case "white":
                        points += 20;
                        whiteBalls++;
                        break;

                    case "black":
                        points = Math.Floor(points/2);
                        blackBalls++;
                        break;

                    default:
                        otherBalls++;
                        break;
                }
            }

            Console.WriteLine($"Total points: {points}");
            Console.WriteLine($"Red balls: {redBalls}");
            Console.WriteLine($"Orange balls: {orangeBalls}");
            Console.WriteLine($"Yellow balls: {yellowBalls}");
            Console.WriteLine($"White balls: {whiteBalls}");
            Console.WriteLine($"Other colors picked: {otherBalls}");
            Console.WriteLine($"Divides from black balls: {blackBalls}");
        }
    }
}
