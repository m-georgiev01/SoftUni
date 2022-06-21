using System;

namespace P05.BestPlayer
{
    class Program
    {
        static void Main(string[] args)
        {
            string player = Console.ReadLine();

            int max = int.MinValue;
            string maxName = "";

            while (player != "END")
            {
                int goals = int.Parse(Console.ReadLine());

                if (goals >= 10)
                {
                    max = goals;
                    maxName = player;
                    break;
                }

                if (goals > max)
                {
                    max = goals;
                    maxName = player;
                }

                player = Console.ReadLine();
            }

            Console.WriteLine($"{maxName} is the best player!");
            if (max >= 3)
            {
                Console.WriteLine($"He has scored {max} goals and made a hat-trick !!!");
            }
            else
            {
                Console.WriteLine($"He has scored {max} goals.");
            }
        }
    }
}
