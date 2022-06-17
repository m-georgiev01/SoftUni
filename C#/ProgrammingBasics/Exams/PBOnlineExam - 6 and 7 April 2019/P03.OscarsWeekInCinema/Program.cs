using System;

namespace P03.OscarsWeekInCinema
{
    class Program
    {
        static void Main(string[] args)
        {
            string movie = Console.ReadLine();
            string type = Console.ReadLine();
            int tickets = int.Parse(Console.ReadLine());

            double pricePerTicket = 0;

            switch (movie)
            {
                case "A Star Is Born":
                    if (type == "normal")
                    {
                        pricePerTicket = 7.50;
                    }
                    else if (type == "luxury")
                    {
                        pricePerTicket = 10.5;
                    }
                    else if (type == "ultra luxury")
                    {
                        pricePerTicket = 13.5;
                    }
                    break;

                case "Bohemian Rhapsody":
                    if (type == "normal")
                    {
                        pricePerTicket = 7.35;
                    }
                    else if (type == "luxury")
                    {
                        pricePerTicket = 9.45;
                    }
                    else if (type == "ultra luxury")
                    {
                        pricePerTicket = 12.75;
                    }
                    break;

                case "Green Book":
                    if (type == "normal")
                    {
                        pricePerTicket = 8.15;
                    }
                    else if (type == "luxury")
                    {
                        pricePerTicket = 10.25;
                    }
                    else if (type == "ultra luxury")
                    {
                        pricePerTicket = 13.25;
                    }
                    break;

                case "The Favourite":
                    if (type == "normal")
                    {
                        pricePerTicket = 8.75;
                    }
                    else if (type == "luxury")
                    {
                        pricePerTicket = 11.55;
                    }
                    else if (type == "ultra luxury")
                    {
                        pricePerTicket = 13.95;
                    }
                    break;

                default:
                    break;
            }

            double total = tickets * pricePerTicket;

            Console.WriteLine($"{movie} -> {total:F2} lv.");
        }
    }
}
