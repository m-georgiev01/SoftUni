using System;

namespace P03.AluminumJoinery
{
    class Program
    {
        static void Main(string[] args)
        {
            int numOfWindows = int.Parse(Console.ReadLine());
            string typeWindows = Console.ReadLine();
            string delivery = Console.ReadLine();

            double pricePerWindow = 0;
            double discount = 1;
            double total = 0;

            if (numOfWindows < 10)
            {
                Console.WriteLine("Invalid order");
                return;
            }

            switch (typeWindows)
            {
                case "90X130":
                    pricePerWindow = 110;

                    if (numOfWindows > 60)
                    {
                        discount = 0.92;
                    }
                    else if (numOfWindows > 30)
                    {
                        discount = 0.95;
                    }
                    break;

                case "100X150":
                    pricePerWindow = 140;

                    if (numOfWindows > 80)
                    {
                        discount = 0.9;
                    }
                    else if (numOfWindows > 40)
                    {
                        discount = 0.94;
                    }
                    break;

                case "130X180":
                    pricePerWindow = 190;

                    if (numOfWindows > 50)
                    {
                        discount = 0.88;
                    }
                    else if (numOfWindows > 20)
                    {
                        discount = 0.93;
                    }
                    break;

                case "200X300":
                    pricePerWindow = 250;

                    if (numOfWindows > 50)
                    {
                        discount = 0.86;
                    }
                    else if (numOfWindows > 25)
                    {
                        discount = 0.91;
                    }
                    break;

                default:
                    break;
            }

            total = numOfWindows * pricePerWindow;
            total *= discount;

            if (delivery == "With delivery")
            {
                total += 60;
            }

            if (numOfWindows > 99)
            {
                total *= 0.96;
            }

            Console.WriteLine($"{total:F2} BGN");
        }
    }
}
