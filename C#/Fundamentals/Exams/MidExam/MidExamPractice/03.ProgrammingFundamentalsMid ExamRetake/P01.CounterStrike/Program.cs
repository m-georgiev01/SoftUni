using System;

namespace P01.CounterStrike
{
    class Program
    {
        static void Main(string[] args)
        {
            int initialEnergy = int.Parse(Console.ReadLine());

            int wonBattlesCounter = 0;
            bool isLost = false;

            string command;
            while ((command = Console.ReadLine()) != "End of battle")
            {
                int currDistance = int.Parse(command);

                if (initialEnergy - currDistance >= 0)
                {
                    initialEnergy -= currDistance;
                    wonBattlesCounter++;

                    if (wonBattlesCounter % 3 == 0)
                    {
                        initialEnergy += wonBattlesCounter;
                    }
                }
                else
                {
                    Console.WriteLine($"Not enough energy! Game ends with {wonBattlesCounter} won battles and {initialEnergy} energy");
                    isLost = true;
                    break;
                }
            }
            if (initialEnergy >= 0 && !isLost)
            {
                Console.WriteLine($"Won battles: {wonBattlesCounter}. Energy left: {initialEnergy}");
            }
            
        }
    }
}
