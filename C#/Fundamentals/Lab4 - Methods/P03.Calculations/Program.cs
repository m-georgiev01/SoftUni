using System;

namespace P03.Calculations
{
    class Program
    {
        static void Main(string[] args)
        {
            string operation = Console.ReadLine();
            double a = double.Parse(Console.ReadLine());
            double b = double.Parse(Console.ReadLine());

            switch (operation)
            {
                case "add":
                    Add(a,b);
                    break;
                case "multiply":
                    Multiply(a, b);
                    break;
                case "subtract":
                    Subtract(a, b);
                    break;
                case "divide":
                    Divide(a, b);
                    break;
            }
        }

        static void Add(double a, double b)
        {
            Console.WriteLine(a + b);
        }
        static void Multiply(double a, double b)
        {
            Console.WriteLine(a * b);
        }
        static void Subtract(double a, double b)
        {
            Console.WriteLine(a - b);
        }
        static void Divide(double a, double b)
        {
            Console.WriteLine(a / b);
        }
    }
}
