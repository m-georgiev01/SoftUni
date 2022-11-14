using System;
using System.Linq;

namespace P01.Reverse_Strings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text;
            while ((text = Console.ReadLine()) != "end")
            {
                string reversedText = new string (text.Reverse().ToArray());
                Console.WriteLine($"{text} = {reversedText}");
            }
        }
    }
}
