using System;

namespace P08.MathPower
{
    class Program
    {
        static void Main(string[] args)
        {
            double num = double.Parse(Console.ReadLine());
            double power = double.Parse(Console.ReadLine());

            Console.WriteLine(RaiseToPower(num, power));
        }

        static double RaiseToPower(double num, double power)
        {
            double result = num;

            for (int i = 1; i < power; i++)
            {
                result *= num;
            }

            return result;
        }
    }
}
