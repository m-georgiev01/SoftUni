using System;

namespace P04.VacationBookList
{
    class Program
    {
        static void Main(string[] args)
        {
            int pages = int.Parse(Console.ReadLine());
            int pagesPerHour = int.Parse(Console.ReadLine());
            int daysLimit = int.Parse(Console.ReadLine());

            int hN = pages / pagesPerHour;
            Console.WriteLine(hN / daysLimit);
        }
    }
}
