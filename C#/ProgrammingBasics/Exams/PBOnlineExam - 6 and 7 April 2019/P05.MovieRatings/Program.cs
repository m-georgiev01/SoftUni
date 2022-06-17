using System;

namespace P05.MovieRatings
{
    class Program
    {
        static void Main(string[] args)
        {
            int movies = int.Parse(Console.ReadLine());

            double max = double.MinValue;
            string maxName = "";

            double min = double.MaxValue;
            string minName = "";

            double sumRating = 0;

            for (int i = 0; i < movies; i++)
            {
                string movieName = Console.ReadLine();
                double rating = double.Parse(Console.ReadLine());

                if (rating > max)
                {
                    max = rating;
                    maxName = movieName;
                }
                if (rating < min)
                {
                    min = rating;
                    minName = movieName;
                }

                sumRating += rating;
            }
            double avg = sumRating / movies;

            Console.WriteLine($"{maxName} is with highest rating: {max:F1}");
            Console.WriteLine($"{minName} is with lowest rating: {min:F1}");
            Console.WriteLine($"Average rating: {avg:F1}");
        }
    }
}
