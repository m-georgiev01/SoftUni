using System;

namespace P03.CharactersInRange
{
    class Program
    {
        static void Main(string[] args)
        {
            char start = char.Parse(Console.ReadLine());
            char end = char.Parse(Console.ReadLine());

            PrintCharsInRange(start, end);
        }
        private static void PrintCharsInRange(char start, char end)
        {
            if (start > end)
            {
                char temp = start;
                start = end;
                end = temp;
            }

            for (int i = start + 1; i < end; i++)
            {
                Console.Write((char)i + " ");
            }
        }
    }
}
