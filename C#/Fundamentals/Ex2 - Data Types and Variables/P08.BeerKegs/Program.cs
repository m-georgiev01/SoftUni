using System;

namespace P08.BeerKegs
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            string biggestKegModel = string.Empty;
            double biggestVolume = double.MinValue;

            for (int i = 0; i < n; i++)
            {
                string model = Console.ReadLine();
                double radius = double.Parse(Console.ReadLine());
                int height = int.Parse(Console.ReadLine());

                double currentVolume = Math.PI * Math.Pow(radius, 2) * height;

                if (currentVolume > biggestVolume)
                {
                    biggestVolume = currentVolume;
                    biggestKegModel = model;
                }
            }

            Console.WriteLine(biggestKegModel);
        }
    }
}
