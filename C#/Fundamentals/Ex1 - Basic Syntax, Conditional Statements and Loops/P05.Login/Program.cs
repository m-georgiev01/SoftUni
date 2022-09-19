using System;

namespace P05.Login
{
    class Program
    {
        static void Main(string[] args)
        {
            string username = Console.ReadLine();
            string password = "";

            int counterAttempts = 0;

            for (int i = username.Length - 1; i >= 0 ; i--)
            {
                password += username[i];
            }

            string passwordInput = Console.ReadLine();

            while (password != passwordInput)
            {
                Console.WriteLine("Incorrect password. Try again.");
                counterAttempts++;

                if (counterAttempts == 3)
                {
                    Console.WriteLine($"User {username} blocked!");
                    break;
                }

                passwordInput = Console.ReadLine();
            }

            if (password == passwordInput)
            {
                Console.WriteLine($"User {username} logged in.");
            }
        }
    }
}
