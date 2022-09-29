using System;

namespace P06.ReversedChars
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] chs = new char[3];

            for (int i = 0; i < chs.Length; i++)
            {
                chs[i] = char.Parse(Console.ReadLine());
            }

            Array.Reverse(chs);

            for (int j = 0; j < chs.Length; j++)
            {
                Console.Write($"{chs[j]} ");
            }
        }
    }
}
