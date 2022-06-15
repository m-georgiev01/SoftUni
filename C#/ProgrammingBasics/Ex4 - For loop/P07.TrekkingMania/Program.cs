using System;

namespace P07.TrekkingMania
{
    class Program
    {
        static void Main(string[] args)
        {
            int groupsCount = int.Parse(Console.ReadLine());

            double groupOne = 0; //Musala
            double groupTwo = 0; //Monblan
            double groupThree = 0; //Kilimandjaro
            double groupFour = 0; //K2
            double groupFive = 0; // Everest

            int totalParticipants = 0;

            for (int i = 0; i < groupsCount; i++)
            {
                int participants = int.Parse(Console.ReadLine());

                if (participants <= 5)
                {
                    groupOne += participants;
                    totalParticipants += participants;
                }
                else if (participants >= 6 && participants <= 12)
                {
                    groupTwo += participants;
                    totalParticipants += participants;
                }
                else if (participants >= 13 && participants <= 25)
                {
                    groupThree += participants;
                    totalParticipants += participants;
                }
                else if (participants >= 26 && participants <= 40)
                {
                    groupFour += participants;
                    totalParticipants += participants;
                }
                else if (participants >= 41)
                {
                    groupFive += participants;
                    totalParticipants += participants;
                }
            }

            Console.WriteLine($"{((groupOne / totalParticipants) * 100):F2}%");
            Console.WriteLine($"{((groupTwo / totalParticipants) * 100):F2}%");
            Console.WriteLine($"{((groupThree / totalParticipants) * 100):F2}%");
            Console.WriteLine($"{((groupFour / totalParticipants) * 100):F2}%");
            Console.WriteLine($"{((groupFive / totalParticipants) * 100):F2}%");
        }
    }
}
