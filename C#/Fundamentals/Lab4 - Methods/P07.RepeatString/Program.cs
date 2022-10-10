using System;

namespace P07.RepeatString
{
    class Program
    {
        static void Main(string[] args)
        {
            string sequence = Console.ReadLine();
            int repeats = int.Parse(Console.ReadLine());

            Console.WriteLine(RepeatString(sequence, repeats));
        }

        static string RepeatString(string sequence, int repeats)
        {
            string newSequence = string.Empty;
            for (int i = 0; i < repeats; i++)
            {
                newSequence += sequence;
            }

            return newSequence;
        }
    }
}
