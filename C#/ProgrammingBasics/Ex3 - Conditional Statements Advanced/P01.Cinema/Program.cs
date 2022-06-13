using System;

namespace P01.Cinema
{
    class Program
    {
        static void Main(string[] args)
        {
            string type = Console.ReadLine();
            int rows = int.Parse(Console.ReadLine());
            int columns = int.Parse(Console.ReadLine());

            int seats = rows * columns;
            double total = 0;

            if (type == "Premiere")
            {
                total = (double)seats * 12;
            }
            else if(type == "Normal")
            {
                total = seats * 7.5;
            }
            else if(type == "Discount")
            {
                total = (double)seats * 5;
            }

            Console.WriteLine($"{total:F2} leva");
        }
    }
}
