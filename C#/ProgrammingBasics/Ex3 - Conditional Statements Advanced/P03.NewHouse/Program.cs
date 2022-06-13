using System;

namespace P03.NewHouse
{
    class Program
    {
        static void Main(string[] args)
        {
            string flowersType = Console.ReadLine();
            int countFlowers = int.Parse(Console.ReadLine());
            int budget = int.Parse(Console.ReadLine());

            double flowersPrice = 0;

            if (flowersType == "Roses")
            {
                flowersPrice = countFlowers * 5;

                if (countFlowers > 80)
                {
                    flowersPrice *=  0.9;
                }
            }
            else if (flowersType == "Dahlias")
            {
                flowersPrice = (double)countFlowers * 3.8;

                if (countFlowers > 90)
                {
                    flowersPrice *= 0.85;
                }
            }
            else if (flowersType == "Tulips")
            {
                flowersPrice = (double)countFlowers * 2.8;

                if (countFlowers > 80)
                {
                    flowersPrice *= 0.85;
                }
            }
            else if (flowersType == "Narcissus")
            {
                flowersPrice = countFlowers * 3;

                if (countFlowers < 120)
                {
                    flowersPrice *= 1.15;
                }
            }
            else if (flowersType == "Gladiolus")
            {
                flowersPrice = (double)countFlowers * 2.5;

                if (countFlowers < 80)
                {
                    flowersPrice *= 1.2;
                }
            }

            if (budget >= flowersPrice)
            {
                Console.WriteLine($"Hey, you have a great garden with {countFlowers} {flowersType} and {(budget - flowersPrice):F2} leva left.");
            }
            else
            {
                Console.WriteLine($"Not enough money, you need {(flowersPrice - budget):F2} leva more.");
            }

            
        }
    }
}
