using System;

namespace P06.Reapinting
{
    class Program
    {
        static void Main(string[] args)
        {
            int nylon = int.Parse(Console.ReadLine());
            int paint = int.Parse(Console.ReadLine());
            int paintSolvent = int.Parse(Console.ReadLine());
            int hours = int.Parse(Console.ReadLine());

            double sumNylon = (nylon + 2) * 1.5;
            double sumPaint = (paint + (paint * 0.1)) * 14.5;

            //0,4 e dobaveno za torbichki
            double sumMaterials = sumNylon + sumPaint + paintSolvent * 5 + 0.4;

            double hourWage = sumMaterials * 0.3;

            double total = sumMaterials + hours * hourWage;
            Console.WriteLine($"{total}");
        }
    }
}
