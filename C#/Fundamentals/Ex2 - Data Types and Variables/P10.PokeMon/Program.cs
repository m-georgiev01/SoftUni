using System;

namespace P10.PokeMon
{
    class Program
    {
        static void Main(string[] args)
        {
            int power = int.Parse(Console.ReadLine());
            int distance = int.Parse(Console.ReadLine());
            int exhaustionFactor= int.Parse(Console.ReadLine());

            int countPokedTargets = 0;
            int startingPower = power;

            while (power >= distance)
            {
                power -= distance;
                countPokedTargets++;

                if ((power == startingPower * 0.5) && exhaustionFactor > 0)
                {
                    power /= exhaustionFactor;
                }
            }


            Console.WriteLine(power);
            Console.WriteLine(countPokedTargets);

        }
    }
}
