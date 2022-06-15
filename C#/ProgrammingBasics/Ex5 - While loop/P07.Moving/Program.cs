using System;

namespace P07.Moving
{
    class Program
    {
        static void Main(string[] args)
        {
            int width = int.Parse(Console.ReadLine());
            int length = int.Parse(Console.ReadLine());
            int heigth = int.Parse(Console.ReadLine());
            string command = Console.ReadLine();

            int apartmentSpace = width * length * heigth;

            while (command != "Done")
            {             
                int boxes = int.Parse(command);

                apartmentSpace -= boxes;
                if (apartmentSpace < 0)
                {                   
                    Console.WriteLine($"No more free space! You need {Math.Abs(apartmentSpace)} Cubic meters more.");
                    break;
                }

                command = Console.ReadLine();
            }

            if (command == "Done")
            {
                Console.WriteLine($"{apartmentSpace} Cubic meters left.");
            }
                           
        }
    }
}
