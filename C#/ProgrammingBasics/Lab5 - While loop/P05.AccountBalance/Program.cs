using System;

namespace P05.AccountBalance
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            double total = 0;

            while (input != "NoMoreMoney")
            {
                double add = double.Parse(input);

                if (add < 0)
                {
                    Console.WriteLine("Invalid operation!");
                    break;
                }

                total += add;
                Console.WriteLine($"Increase: {add:F2}");

                input = Console.ReadLine();
            }

            Console.WriteLine($"Total: {total:F2}");
        }
    }
}
