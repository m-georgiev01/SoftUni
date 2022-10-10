using System;

namespace P06.CalculateRectangleArea
{
    class Program
    {
        static void Main(string[] args)
        {
            double width = double.Parse(Console.ReadLine());
            double heigth = double.Parse(Console.ReadLine());

            Console.WriteLine(GetRectArea(width, heigth)); 
        }

        static double GetRectArea(double width, double heigth)
        {
            return width * heigth;
        }
    }
}
