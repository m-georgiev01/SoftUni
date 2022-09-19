using System;

namespace P03.Vacation
{
    class Program
    {
        static void Main(string[] args)
        {
            int countOfPeople = int.Parse(Console.ReadLine());
            string typeOfGroup = Console.ReadLine();
            string dayOfStay = Console.ReadLine();

            double pricePerPeson = 0;
            double total = 0;

            if (typeOfGroup == "Students")
            {
                if (dayOfStay == "Friday")
                {
                    pricePerPeson = 8.45;
                }
                else if (dayOfStay == "Saturday")
                {
                    pricePerPeson = 9.8;
                }
                else if (dayOfStay == "Sunday")
                {
                    pricePerPeson = 10.46;
                }

                total = pricePerPeson * countOfPeople;

                if (countOfPeople >= 30)
                {
                    total *= 0.85;
                }
            }
            else if (typeOfGroup == "Business")
            {
                if (dayOfStay == "Friday")
                {
                    pricePerPeson = 10.9;
                }
                else if (dayOfStay == "Saturday")
                {
                    pricePerPeson = 15.6;
                }
                else if (dayOfStay == "Sunday")
                {
                    pricePerPeson = 16;
                }

                if (countOfPeople >= 100)
                {
                    countOfPeople -= 10;
                }
                total = pricePerPeson * countOfPeople;
            }
            else if (typeOfGroup == "Regular")
            {
                if (dayOfStay == "Friday")
                {
                    pricePerPeson = 15;
                }
                else if (dayOfStay == "Saturday")
                {
                    pricePerPeson = 20;
                }
                else if (dayOfStay == "Sunday")
                {
                    pricePerPeson = 22.5;
                }

                total = pricePerPeson * countOfPeople;

                if (countOfPeople >= 10 && countOfPeople <= 20)
                {
                    total *= 0.95;
                }
            }

            Console.WriteLine($"Total price: {total:F2}");
        }
    }
}
