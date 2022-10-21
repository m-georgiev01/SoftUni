using System;
using System.Linq;

namespace P02.MuOnline
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] dungeonRooms = Console.ReadLine().Split("|", StringSplitOptions.RemoveEmptyEntries);

            int health = 100;
            int bitcoins = 0;
            int bestReachedRoom = -1;

            for (int i = 0; i < dungeonRooms.Length; i++)
            {
                string[] commandForTheRoom = dungeonRooms[i].Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string currCommand = commandForTheRoom[0];
                int value = int.Parse(commandForTheRoom[1]);

                if (currCommand == "potion")
                {
                    bestReachedRoom = i;
                    int newValue = value;
                    
                    if (health + newValue > 100)
                    {
                        newValue = 100 - health;
                    }

                    health += newValue;
                    Console.WriteLine($"You healed for {newValue} hp.");
                    Console.WriteLine($"Current health: {health} hp.");
                }
                else if (currCommand == "chest")
                {
                    bestReachedRoom = i;
                    bitcoins += value;
                    Console.WriteLine($"You found {value} bitcoins.");
                }
                else
                {
                    bestReachedRoom = i;
                    health -= value;

                    if (health > 0)
                    {
                        Console.WriteLine($"You slayed {currCommand}.");
                    }
                    else
                    {
                        Console.WriteLine($"You died! Killed by {currCommand}.");
                        Console.WriteLine($"Best room: {++bestReachedRoom}");
                        break;
                    }
                }
            }

            if (bestReachedRoom != -1 && health > 0)
            {
                Console.WriteLine("You've made it!");
                Console.WriteLine($"Bitcoins: {bitcoins}");
                Console.WriteLine($"Health: {health}");
            }
        }
    }
}
