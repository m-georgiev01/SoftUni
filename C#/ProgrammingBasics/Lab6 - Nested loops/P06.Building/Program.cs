using System;

namespace P06.Building
{
    class Program
    {
        static void Main(string[] args)
        {
            int floors = int.Parse(Console.ReadLine());
            int rooms = int.Parse(Console.ReadLine());
            char type = ' ';

            for (int i = floors; i >= 1; i--)
            {
                if (i == floors)
                {
                    type = 'L';
                }
                else if (i % 2 == 0)
                {
                    type = 'O';
                }
                else
                {
                    type = 'A';
                }


                for (int j = 0; j < rooms; j++)
                {
                    if (j == rooms - 1)
                    {
                        Console.WriteLine($"{type}{i}{j}");
                    }
                    else
                    {
                        Console.Write($"{type}{i}{j} ");
                    }
                    
                }
            }
        }
    }
}
