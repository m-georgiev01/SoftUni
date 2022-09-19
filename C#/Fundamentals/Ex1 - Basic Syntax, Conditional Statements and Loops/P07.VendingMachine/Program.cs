using System;

namespace P07.VendingMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputCoins = Console.ReadLine();

            double balance = 0;

            while (inputCoins != "Start")
            {
                switch (inputCoins)
                {
                    case "0.1":
                        balance += 0.1;
                        break;

                    case "0.2":
                        balance += 0.2;
                        break;

                    case "0.5":
                        balance += 0.5;
                        break;

                    case "1":
                        balance += 1;
                        break;

                    case "2":
                        balance += 2;
                        break;

                    default:
                        Console.WriteLine($"Cannot accept {inputCoins}");
                        break;
                }
                inputCoins = Console.ReadLine();
            }

            string inputProducts = Console.ReadLine();

            while (inputProducts != "End")
            {
                switch (inputProducts)
                {
                    case "Nuts":
                        if (balance >= 2)
                        {
                            Console.WriteLine($"Purchased nuts");
                            balance -= 2;
                        }
                        else
                        {
                            Console.WriteLine("Sorry, not enough money");
                        }
                        break;

                    case "Water":
                        if (balance >= 0.7)
                        {
                            Console.WriteLine($"Purchased water");
                            balance -= 0.7;
                        }
                        else
                        {
                            Console.WriteLine("Sorry, not enough money");
                        }
                        break;

                    case "Crisps":
                        if (balance >= 1.5)
                        {
                            Console.WriteLine($"Purchased crisps");
                            balance -= 1.5;
                        }
                        else
                        {
                            Console.WriteLine("Sorry, not enough money");
                        }
                        break;

                    case "Soda":
                        if (balance >= 0.8)
                        {
                            Console.WriteLine($"Purchased soda");
                            balance -= 0.8;
                        }
                        else
                        {
                            Console.WriteLine("Sorry, not enough money");
                        }
                        break;

                    case "Coke":
                        if (balance >= 1)
                        {
                            Console.WriteLine($"Purchased coke");
                            balance -= 1;
                        }
                        else
                        {
                            Console.WriteLine("Sorry, not enough money");
                        }
                        break;

                    default:
                        Console.WriteLine("Invalid product");
                        break;
                }

                inputProducts = Console.ReadLine();
            }

            Console.WriteLine($"Change: {balance:F2}");
        }
    }
}
