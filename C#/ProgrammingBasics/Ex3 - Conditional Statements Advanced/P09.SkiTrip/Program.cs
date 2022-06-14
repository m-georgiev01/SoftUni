using System;

namespace P09.SkiTrip
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            string roomType = Console.ReadLine();
            string grade = Console.ReadLine();

            int nights = days - 1;
            double pricePerNight = 0;
            double total = 0;

            switch (roomType)
            {
                case "room for one person":
                    pricePerNight = 18;
                    total = pricePerNight * nights;
                    break;

                case "apartment":
                    pricePerNight = 25;
                    total = pricePerNight * nights;

                    if (nights < 10)
                    {
                        total *= 0.7;
                    }
                    else if(nights >= 10 && nights <= 15)
                    {
                        total *= 0.65;
                    }
                    else if (nights > 15)
                    {
                        total *= 0.5;
                    }
                    break;

                case "president apartment":
                    pricePerNight = 35;
                    total = pricePerNight * nights;

                    if (nights < 10)
                    {
                        total *= 0.9;
                    }
                    else if (nights >= 10 && nights <= 15)
                    {
                        total *= 0.85;
                    }
                    else if (nights > 15)
                    {
                        total *= 0.8;
                    }
                    break;
            }

            if (grade == "positive")
            {
                total *= 1.25;
            }
            else if(grade == "negative")
            {
                total *= 0.9;
            }

            Console.WriteLine($"{total:F2}");
        }
    }
}
