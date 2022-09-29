using System;

namespace P09.CharsToString
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

            string result = string.Empty;

            for (int j = 0; j < chs.Length; j++)
            {
                result += chs[j];
            }

            Console.WriteLine(result);
        }
    }
}
