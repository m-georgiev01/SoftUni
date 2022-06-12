using System;

namespace P04.ToyShop
{
    class Program
    {
        static void Main(string[] args)
        {
            double vacationPrice = double.Parse(Console.ReadLine());
            int puzzles = int.Parse(Console.ReadLine());
            int talkingDolls = int.Parse(Console.ReadLine());
            int teddyBears = int.Parse(Console.ReadLine());
            int minions = int.Parse(Console.ReadLine());
            int trucks = int.Parse(Console.ReadLine());

            double totalPrice = puzzles * 2.6 + talkingDolls * 3 + teddyBears * 4.1 + minions * 8.20 + trucks * 2;
            int countToys = puzzles + talkingDolls + teddyBears + minions + trucks;

            if (countToys >= 50)
            {
                totalPrice *= 0.75;
            }
            //Za naem
            totalPrice *= 0.9;

            if (totalPrice >= vacationPrice)
            {
                Console.WriteLine($"Yes! {(totalPrice - vacationPrice):F2} lv left.");
            }
            else
            {
                Console.WriteLine($"Not enough money! {(vacationPrice - totalPrice):F2} lv needed.");
            }
        }
    }
}
