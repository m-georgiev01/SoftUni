using System;

namespace P03.Vacation
{
    class Program
    {
        static void Main(string[] args)
        {
            double wantedMoney = double.Parse(Console.ReadLine());
            double money = double.Parse(Console.ReadLine());

            int countDays = 0;
            int countConsistentSpendingDays = 0;

            while (money < wantedMoney && countConsistentSpendingDays < 5)
            {
                string operation = Console.ReadLine();
                double sum = double.Parse(Console.ReadLine());

                countDays++;

                if (operation == "spend")
                {
                    countConsistentSpendingDays++;

                    if (money - sum >= 0)
                    {
                        money -= sum;
                    }
                    else
                    {
                        money = 0;
                    }
                    
                }
                else if (operation == "save")
                {
                    money += sum;
                    countConsistentSpendingDays = 0;

                    if (money >= wantedMoney)
                    {
                        Console.WriteLine($"You saved the money for {countDays} days.");
                    }
                }
            }

            if (countConsistentSpendingDays == 5)
            {
                Console.WriteLine("You can't save the money.");
                Console.WriteLine($"{countDays}");
            }
        }
    }
}
