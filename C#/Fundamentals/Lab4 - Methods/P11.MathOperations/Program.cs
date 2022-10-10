using System;

namespace P11.MathOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            string command = Console.ReadLine();
            int b = int.Parse(Console.ReadLine());

            Console.WriteLine(Calculate(a, command, b));
        }
        private static double Calculate(int a, string command, int b)
        {
            double result = 0;

            switch (command)
            {
                case "+":
                    result = a + b;
                    break;

                case "-":
                    result = a - b;
                    break;

                case "*":
                    result = a * b;
                    break;

                case "/":
                    result = (double)a / b;
                    break;
            }

            return result;
        }
    }
}
