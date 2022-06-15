using System;

namespace P04.CleverLily
{
    class Program
    {
        static void Main(string[] args)
        {
            int age = int.Parse(Console.ReadLine());
            double washingMachinePrice = double.Parse(Console.ReadLine());
            int toyPrice = int.Parse(Console.ReadLine());

            int toyCount = 0;
            int moneyBirthdays = 0;

            double total = 0;

            for (int i = 1; i <= age; i++)
            {
                if(i % 2 != 0)
                {
                    toyCount++;
                }
                else if (i == 2)
                {
                    moneyBirthdays = 10;
                    moneyBirthdays--;
                }
                else
                {
                    moneyBirthdays += (10 * (i / 2));
                    moneyBirthdays--;
                }
            }

            total = moneyBirthdays + ((double)toyPrice * toyCount);

            if (total >= washingMachinePrice)
            {
                Console.WriteLine($"Yes! {(total - washingMachinePrice):F2}");
            }
            else
            {
                Console.WriteLine($"No! {(washingMachinePrice - total):F2}");
            }
        }
    }
}
