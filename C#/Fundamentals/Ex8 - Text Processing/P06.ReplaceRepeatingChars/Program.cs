using System;
using System.Text;

namespace P06.ReplaceRepeatingChars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            var sb = new StringBuilder();

            for (int i = 0; i < text.Length - 1; i++)
            {
                if (text[i] == text[i + 1])
                {
                    continue;
                }
                sb.Append(text[i]);
            }

            sb.Append(text[text.Length - 1]);

            Console.WriteLine(sb.ToString());
        }
    }
}
