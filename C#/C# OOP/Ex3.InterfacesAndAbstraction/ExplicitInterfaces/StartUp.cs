using ExplicitInterfaces.Models;
using ExplicitInterfaces.Models.Interfaces;

namespace PersonInfo
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Citizen> citizens = new();

            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                var tokens = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                citizens.Add(new Citizen(tokens[0], tokens[1], int.Parse(tokens[2])));
            }

            foreach (var citizen in citizens)
            {
                Console.WriteLine(((IPerson)citizen).GetName());
                Console.WriteLine(((IResident)citizen).GetName());
            }
        }
    }
}
