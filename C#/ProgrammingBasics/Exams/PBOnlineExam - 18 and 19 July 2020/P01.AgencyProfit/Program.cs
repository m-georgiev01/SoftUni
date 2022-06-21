using System;

namespace P01.AgencyProfit
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int ticketsAdults = int.Parse(Console.ReadLine());
            int ticketsKids = int.Parse(Console.ReadLine());
            double ticketAdultNet = double.Parse(Console.ReadLine());
            double servicePrice = double.Parse(Console.ReadLine());

            double total = ticketsAdults * (ticketAdultNet + servicePrice) +
                           ticketsKids * ((ticketAdultNet * 0.3) + servicePrice);

            double profit = total * 0.2;

            Console.WriteLine($"The profit of your agency from {name} tickets is {profit:F2} lv.");
        }
    }
}
