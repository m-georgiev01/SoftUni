using System;

namespace P01.ValidUsernames
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] usernames = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);

            foreach (var un in usernames)
            {
                bool isValid = true;

                if (un.Length >= 3 && un.Length <= 16)
                {
                    foreach (char x in un)
                    {
                        if (x != '_' && x != '-' && !char.IsLetterOrDigit(x))
                        {
                            isValid = false;
                            break;
                        }
                    }

                    if (isValid)
                    {
                        Console.WriteLine(un);
                    }

                }
            }
        }
    }
}
