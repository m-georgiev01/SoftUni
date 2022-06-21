using System;

namespace P02.AddBags
{
    class Program
    {
        static void Main(string[] args)
        {
            double luggageOver20 = double.Parse(Console.ReadLine());
            double kg = double.Parse(Console.ReadLine());
            int days = int.Parse(Console.ReadLine());
            int numOfLuggage = int.Parse(Console.ReadLine());

            double luggageTo10 = luggageOver20 * 0.2;
            double luggage10To20 = luggageOver20 * 0.5;

            double total = 0;

            if (kg < 10)
            {
                total += numOfLuggage * luggageTo10;
            }
            else if (kg >= 10 && kg <= 20)
            {
                total += numOfLuggage * luggage10To20;
            }
            else if (kg > 20)
            {
                total += numOfLuggage * luggageOver20;
            }

            if (days > 30)
            {
                total *= 1.1;
            }
            else if (days >= 7 && days <= 30)
            {
                total *= 1.15;
            }
            else
            {
                total *= 1.4;
            }

            Console.WriteLine($"The total price of bags is: {total:F2} lv.");
        }
    }
}
