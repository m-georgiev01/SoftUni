using System;

namespace P12.TradeCommissions
{
    class Program
    {
        static void Main(string[] args)
        {
            string city = Console.ReadLine();
            double salesVolume = double.Parse(Console.ReadLine());

            int column = 0;
            double commision = 0;

            if (salesVolume >= 0 && salesVolume <= 500)
            {
                column = 1;
            }
            else if (salesVolume > 500 && salesVolume <= 1000)
            {
                column = 2;
            }
            else if (salesVolume > 1000 && salesVolume <= 10000)
            {
                column = 3;
            }
            else if (salesVolume > 10000)
            {
                column = 4;
            }
            else if (salesVolume < 0)
            {
                Console.WriteLine("error");
                return;
            }

            switch (city)
            {
                case "Sofia":
                    if (column == 1)
                    {
                        commision = salesVolume * 0.05;
                    }
                    else if (column == 2)
                    {
                        commision = salesVolume * 0.07;
                    }
                    else if (column == 3)
                    {
                        commision = salesVolume * 0.08;
                    }
                    else if (column == 4)
                    {
                        commision = salesVolume * 0.12;
                    }
                    break;
                case "Varna":
                    if (column == 1)
                    {
                        commision = salesVolume * 0.045;
                    }
                    else if (column == 2)
                    {
                        commision = salesVolume * 0.075;
                    }
                    else if (column == 3)
                    {
                        commision = salesVolume * 0.1;
                    }
                    else if (column == 4)
                    {
                        commision = salesVolume * 0.13;
                    }
                    break;
                case "Plovdiv":
                    if (column == 1)
                    {
                        commision = salesVolume * 0.055;
                    }
                    else if (column == 2)
                    {
                        commision = salesVolume * 0.08;
                    }
                    else if (column == 3)
                    {
                        commision = salesVolume * 0.12;
                    }
                    else if (column == 4)
                    {
                        commision = salesVolume * 0.145;
                    }
                    break;

            }

            if (commision == 0)
            {
                Console.WriteLine("error");
            }
            else
            {
                Console.WriteLine($"{commision:F2}");
            }

        }
    }
}
