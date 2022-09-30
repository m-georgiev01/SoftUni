using System;

namespace P04.SumOfChars
{
    class Program
    {
        static void Main(string[] args)
        {
            byte n = byte.Parse(Console.ReadLine());

            int sumChars = 0;

            for (byte i = 0; i < n; i++)
            {
                char input = char.Parse(Console.ReadLine());
                sumChars += (int)input;
            }

            Console.WriteLine($"The sum equals: {sumChars}");
        }
    }
}
