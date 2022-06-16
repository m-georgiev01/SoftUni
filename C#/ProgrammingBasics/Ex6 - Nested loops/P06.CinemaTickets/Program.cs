using System;

namespace P06.CinemaTickets
{
    class Program
    {
        static void Main(string[] args)
        {
            string movie = Console.ReadLine();

            int totalTickets = 0;

            int studentTicketCount = 0;
            int standartTicketCount = 0;
            int kidTicketCount = 0;

            while (movie != "Finish")
            {
                int freeSeats = int.Parse(Console.ReadLine());
                int currentMovieTakenSeats = 0;

                string ticketType = Console.ReadLine();

                while (ticketType != "End")
                {
                    totalTickets++;
                    currentMovieTakenSeats++;

                    switch (ticketType)
                    {
                        case "student":
                            studentTicketCount++;
                            break;

                        case "standard":
                            standartTicketCount++;
                            break;

                        case "kid":
                            kidTicketCount++;
                            break;

                        default:
                            break;
                    }

                    if (currentMovieTakenSeats == freeSeats)
                    {
                        break;
                    }

                    ticketType = Console.ReadLine();
                }

                Console.WriteLine($"{movie} - {(((double)currentMovieTakenSeats / freeSeats) * 100):F2}% full.");

                movie = Console.ReadLine();
            }

            if (movie == "Finish")
            {
                Console.WriteLine($"Total tickets: {totalTickets}");
                Console.WriteLine($"{(((double)studentTicketCount / totalTickets) * 100):F2}% student tickets.");
                Console.WriteLine($"{(((double)standartTicketCount / totalTickets) * 100):F2}% standard tickets.");
                Console.WriteLine($"{(((double)kidTicketCount / totalTickets) * 100):F2}% kids tickets.");
            }
        }
    }
}
