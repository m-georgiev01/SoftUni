using System;

namespace P01.OscarsCeremony
{
    class Program
    {
        static void Main(string[] args)
        {
            int rent = int.Parse(Console.ReadLine());

            double figurines = rent * 0.7;
            double catering = figurines * 0.85;
            double sounding = catering * 0.5;

            double total = rent + figurines + catering + sounding;

            Console.WriteLine($"{total:F2}");
        }
    }
}
