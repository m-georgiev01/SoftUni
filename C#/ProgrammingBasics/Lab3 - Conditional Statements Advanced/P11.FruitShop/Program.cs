using System;

namespace P11.FruitShop
{
    class Program
    {
        static void Main(string[] args)
        {
            string fruit = Console.ReadLine();
            string day = Console.ReadLine();
            double quantity = double.Parse(Console.ReadLine());

            double productPrice = 0;

            switch (day)
            {
                case "Monday":
                case "Tuesday":
                case "Wednesday":
                case "Thursday":
                case "Friday":

                    switch (fruit)
                    {
                        case "banana":
                            productPrice = 2.5;
                            break;
                        case "apple":
                            productPrice = 1.2;
                            break;
                        case "orange":
                            productPrice = 0.85;
                            break;
                        case "grapefruit":
                            productPrice = 1.45;
                            break;
                        case "kiwi":
                            productPrice = 2.7;
                            break;
                        case "pineapple":
                            productPrice = 5.5;
                            break;
                        case "grapes":
                            productPrice = 3.85;
                            break;
                    }
                    break;

                case "Saturday":
                case "Sunday":

                    switch (fruit)
                    {
                        case "banana":
                            productPrice = 2.7;
                            break;
                        case "apple":
                            productPrice = 1.25;
                            break;
                        case "orange":
                            productPrice = 0.9;
                            break;
                        case "grapefruit":
                            productPrice = 1.6;
                            break;
                        case "kiwi":
                            productPrice = 3;
                            break;
                        case "pineapple":
                            productPrice = 5.6;
                            break;
                        case "grapes":
                            productPrice = 4.2;
                            break;
                    }
                    break;
            }

            if (productPrice == 0)
            {
                Console.WriteLine("error");
            }
            else
            {
                double finalPrice = productPrice * quantity;
                Console.WriteLine($"{finalPrice:F2}");
            }
        }
    }
}
