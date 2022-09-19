using System;

namespace P09.PadawanEquipment
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int countStudents = int.Parse(Console.ReadLine());
            double pricePerLightsaber = double.Parse(Console.ReadLine());
            double pricePerRobe = double.Parse(Console.ReadLine());
            double pricePerBelt = double.Parse(Console.ReadLine());

            int freeBelts = countStudents / 6;
            int bonusLightsabers = (int)Math.Ceiling(countStudents * 0.1);

            double neededMoney = pricePerLightsaber * (countStudents + bonusLightsabers) + 
                                 pricePerRobe * countStudents + 
                                 pricePerBelt * (countStudents - freeBelts);

            if (neededMoney <= budget)
            {
                Console.WriteLine($"The money is enough - it would cost {neededMoney:F2}lv.");
            }
            else
            {
                Console.WriteLine($"John will need {(neededMoney - budget):F2}lv more.");
            }
        }
    }
}
