using System;
using System.Linq;
using System.Text;

namespace P05.DigitsLettersAndOther
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            string digits = string.Empty;
            string letters = string.Empty;
            string otherChars = string.Empty;

            digits = new string (text.Where(x => Char.IsDigit(x)).ToArray());
            letters = new string (text.Where(x => Char.IsLetter(x)).ToArray());
            otherChars = new string (text.Where(x => !Char.IsLetterOrDigit(x)).ToArray());

            Console.WriteLine(digits);
            Console.WriteLine(letters);
            Console.WriteLine(otherChars);
        }
    }
}
