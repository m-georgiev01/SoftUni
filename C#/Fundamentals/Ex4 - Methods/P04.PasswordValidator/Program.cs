using System;

namespace P04.PasswordValidator
{
    class Program
    {
        static void Main(string[] args)
        {
            string pass = Console.ReadLine();

            if (CheckPassLength(pass) && CheckSymbols(pass) && CheckDigits(pass))
            {
                Console.WriteLine("Password is valid");
            }

            if (!CheckPassLength(pass))
            {
                Console.WriteLine("Password must be between 6 and 10 characters");
            }

            if (!CheckSymbols(pass))
            {
                Console.WriteLine("Password must consist only of letters and digits");
            }

            if (!CheckDigits(pass))
            {
                Console.WriteLine("Password must have at least 2 digits");
            }
        }
        private static bool CheckPassLength(string pass)
        {
            if (pass.Length < 6 || pass.Length > 10)
            {             
                return false;
            }
            return true;
        }
        private static bool CheckSymbols(string pass)
        {
            for (int i = 0; i < pass.Length; i++)
            {
                char currSymbol = pass[i];

                if (!Char.IsLetterOrDigit(currSymbol))
                {
                    return false;
                }
            }
            return true;
        }
        private static bool CheckDigits(string pass)
        {
            int digitsCount = 0;

            for (int i = 0; i < pass.Length; i++)
            {
                char currSymbol = pass[i];

                if (Char.IsDigit(currSymbol))
                {
                    digitsCount++;
                }
            }

            if (digitsCount < 2)
            {
                return false;
            }
            return true;
        }
    }
}
