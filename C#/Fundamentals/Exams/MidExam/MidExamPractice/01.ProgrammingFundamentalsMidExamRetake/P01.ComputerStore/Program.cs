using System;

namespace P01.ComputerStore
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();

            double total = 0;

            while (command != "special" && command != "regular")
            {
                //without tax
                double partPrice = double.Parse(command);

                if (partPrice < 0)
                {
                    Console.WriteLine("Invalid price!");
                    command = Console.ReadLine();
                    continue;
                }

                total += partPrice;

                command = Console.ReadLine();
            }
            double totalWithTaxes = total * 1.2;

            if (command == "special")
            {
                totalWithTaxes = (totalWithTaxes * 0.9);
            }

            if (total == 0)
            {
                Console.WriteLine("Invalid order!");
                return;
            }

            Console.WriteLine("Congratulations you've just bought a new computer!");
            Console.WriteLine($"Price without taxes: {total:F2}$");
            Console.WriteLine($"Taxes: {(total * 0.2):F2}$");
            Console.WriteLine("-----------");
            Console.WriteLine($"Total price: {totalWithTaxes:F2}$");
        }
    }
}
