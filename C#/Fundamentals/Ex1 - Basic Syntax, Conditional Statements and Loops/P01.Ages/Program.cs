using System;

namespace P01.Ages
{
    class Program
    {
        static void Main(string[] args)
        {
            int age = int.Parse(Console.ReadLine());
            string stageInLife = "";

            if (age >= 0 && age <= 2)
            {
                stageInLife = "baby";
            }
            else if (age >= 3 && age <= 13)
            {
                stageInLife = "child";
            }
            else if (age >= 14 && age <= 19)
            {
                stageInLife = "teenager";
            }
            else if (age >= 20 && age <= 65)
            {
                stageInLife = "adult";
            }
            else if (age >= 66)
            {
                stageInLife = "elder";
            }

            Console.WriteLine(stageInLife);
        }
    }
}
