using System;

namespace P05.TrainingLab
{
    class Program
    {
        static void Main(string[] args)
        {
            double h = double.Parse(Console.ReadLine());
            double w = double.Parse(Console.ReadLine());

            int cols = (int)((w - 1) / 0.7);
            int rows = (int)(h / 1.2);

            int seats = cols * rows - 3;

            Console.WriteLine(seats);
        }
    }
}
