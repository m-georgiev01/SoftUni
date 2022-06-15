using System;

namespace P01.OldBooks
{
    class Program
    {
        static void Main(string[] args)
        {
            string wantedBook = Console.ReadLine();
            string currentBook = Console.ReadLine();

            int countSearchedBooks = 0;
            bool isFound = false;

            while (currentBook != "No More Books")
            {
                if (currentBook == wantedBook)
                {
                    isFound = true;
                    Console.WriteLine($"You checked {countSearchedBooks} books and found it.");
                    break;
                }

                countSearchedBooks++;
                currentBook = Console.ReadLine();
            }

            if (isFound == false)
            {
                Console.WriteLine("The book you search is not here!");
                Console.WriteLine($"You checked {countSearchedBooks} books.");
            }
        }
    }
}
