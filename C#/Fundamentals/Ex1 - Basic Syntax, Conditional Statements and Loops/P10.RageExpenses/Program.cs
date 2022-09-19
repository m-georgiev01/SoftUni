using System;

namespace P10.RageExpenses
{
    class Program
    {
        static void Main(string[] args)
        {
            int countLossGames = int.Parse(Console.ReadLine());
            double priceHeadset = double.Parse(Console.ReadLine());
            double priceMouse = double.Parse(Console.ReadLine());
            double priceKeyboard = double.Parse(Console.ReadLine());
            double priceDisplay = double.Parse(Console.ReadLine());

            int countTrashedHeadset = 0;
            int countTrashedMouse = 0;
            int countTrashedKeyboard = 0;
            int countTrashedDisplay = 0;

            for (int i = 1; i <= countLossGames; i++)
            {
                if (i % 2 == 0)
                {
                    countTrashedHeadset++;
                }
                if (i % 3 == 0)
                {
                    countTrashedMouse++;
                }
                if (i % 2 == 0 && i % 3 == 0)
                {
                    countTrashedKeyboard++;
                    if (countTrashedKeyboard % 2 == 0)
                    {
                        countTrashedDisplay++;
                    }
                }
            }
            double expenses = countTrashedHeadset * priceHeadset + countTrashedMouse * priceMouse +
                              countTrashedKeyboard * priceKeyboard + countTrashedDisplay * priceDisplay;
            Console.WriteLine($"Rage expenses: {expenses:F2} lv.");
        }
    }
}
