using System;
using System.Collections.Generic;
using System.Linq;

namespace P06.CardsGame
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> firstPlayerHand = Console.ReadLine()
                                           .Split()
                                           .Select(int.Parse)
                                           .ToList();

            List<int> secondPlayerHand = Console.ReadLine()
                                           .Split()
                                           .Select(int.Parse)
                                           .ToList();

            for (int i = 0; i < firstPlayerHand.Count; i++)
            {
                if (secondPlayerHand.Count == 0)
                {
                    break;
                }

                if (firstPlayerHand[i] > secondPlayerHand[i])
                {
                    firstPlayerHand.Add(firstPlayerHand[i]);
                    firstPlayerHand.Add(secondPlayerHand[i]);
                    firstPlayerHand.RemoveAt(i);
                    secondPlayerHand.RemoveAt(i);

                    i--;
                }
                else if (secondPlayerHand[i] > firstPlayerHand[i])
                {
                    secondPlayerHand.Add(secondPlayerHand[i]);
                    secondPlayerHand.Add(firstPlayerHand[i]);
                    secondPlayerHand.RemoveAt(i);
                    firstPlayerHand.RemoveAt(i);

                    i--;
                }
                else
                {
                    firstPlayerHand.RemoveAt(i);
                    secondPlayerHand.RemoveAt(i);

                    i--;
                }
            }

            if (firstPlayerHand.Count == 0)
            {
                Console.WriteLine($"Second player wins! Sum: {secondPlayerHand.Sum()}");
            }
            else
            {
                Console.WriteLine($"First player wins! Sum: {firstPlayerHand.Sum()}");
            }
        }
    }
}
