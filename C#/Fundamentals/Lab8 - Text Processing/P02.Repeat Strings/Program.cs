using System;
using System.Text;

namespace P02.Repeat_Strings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            StringBuilder sb = new StringBuilder();

            foreach (var word in words)
            {
                for (int k = 0; k < word.Length; k++)
                {
                    sb.Append(word);
                }
            }

            Console.WriteLine(sb);
        }
    }
}
