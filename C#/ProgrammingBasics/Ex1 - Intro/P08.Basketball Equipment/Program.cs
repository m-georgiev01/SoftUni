using System;

namespace P08.Basketball_Equipment
{
    class Program
    {
        static void Main(string[] args)
        {
            int yearSubscription = int.Parse(Console.ReadLine());

            double shoes = yearSubscription * 0.6;
            double clothes = shoes * 0.8;
            double ball = clothes * 0.25;
            double accessaccessories = ball * 0.2;

            double total = yearSubscription + shoes + clothes + ball + accessaccessories;

            Console.WriteLine($"{total}");
        }
    }
}
