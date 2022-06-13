using System;

namespace P07.HotelRoom
{
    class Program
    {
        static void Main(string[] args)
        {
            string month = Console.ReadLine();
            int nightStays = int.Parse(Console.ReadLine());

            double apartmentPrice = 0;
            double studioPrice = 0;

            switch (month)
            {
                case "May":
                case "October":
                    studioPrice = nightStays * 50;
                    apartmentPrice = nightStays * 65;

                    if (nightStays > 7 && nightStays < 14)
                    {
                        studioPrice *= 0.95;
                    }
                    else if (nightStays > 14)
                    {
                        studioPrice *= 0.7;
                    }
                    break;

                case "June":
                case "September":
                    studioPrice = nightStays * 75.2;
                    apartmentPrice = nightStays * 68.7;

                    if (nightStays > 14)
                    {
                        studioPrice *= 0.8;
                    }
                    break;

                case "July":
                case "August":
                    studioPrice = nightStays * 76;
                    apartmentPrice = nightStays * 77;
                    break;

                default:
                    break;
            }

            if (nightStays > 14)
            {
                apartmentPrice *= 0.9;
            }

            Console.WriteLine($"Apartment: {apartmentPrice:F2} lv.");
            Console.WriteLine($"Studio: {studioPrice:F2} lv.");
        }
    }
}
