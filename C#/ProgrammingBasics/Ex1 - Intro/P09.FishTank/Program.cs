using System;

namespace P09.FishTank
{
    class Program
    {
        static void Main(string[] args)
        {
            int lenght = int.Parse(Console.ReadLine());
            int width = int.Parse(Console.ReadLine());
            int height = int.Parse(Console.ReadLine());
            double perventageTaken = double.Parse(Console.ReadLine());

            double volumeInLiters = ((double)lenght * width * height) / 1000;

            double liters = volumeInLiters - (volumeInLiters * (perventageTaken / 100));
            Console.WriteLine(liters);
        }
    }
}
