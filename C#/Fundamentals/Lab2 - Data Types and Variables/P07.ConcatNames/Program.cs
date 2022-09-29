using System;

namespace P07.ConcatNames
{
    class Program
    {
        static void Main(string[] args)
        {
            string fName = Console.ReadLine();
            string lName = Console.ReadLine();
            string delimiter = Console.ReadLine();

            Console.WriteLine($"{fName}{delimiter}{lName}");
        }
    }
}
