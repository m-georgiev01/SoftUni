using System;

namespace P09.YardGreening
{
    class Program
    {
        static void Main(string[] args)
        {
            double gardenArea = double.Parse(Console.ReadLine());
            double midPrice = gardenArea * 7.61;
            double totalPrice = midPrice - midPrice * 0.18;

            Console.WriteLine($"The final price is: {totalPrice} lv.");
            Console.WriteLine($"The discount is: {Math.Round(midPrice - totalPrice, 2)} lv.");
        }
    }
}
