using BirthdayCelebrations.Models;
using BirthdayCelebrations.Models.Interfaces;

namespace BirthdayCelebrations
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<IBirthdable> society = new();

            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                var tokens = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string type = tokens[0];

                IBirthdable member;

                if (type == "Citizen")
                {
                    member = new Citizen(tokens[3], tokens[1], int.Parse(tokens[2]), tokens[4]);
                }
                else if (type == "Pet")
                {
                    member = new Pet(tokens[1], tokens[2]);
                }
                else
                {
                    continue;
                }

                society.Add(member);
            }

            string wantedYear = Console.ReadLine();

            var filteredList = society
                .Where(s => s.BirthDate.EndsWith(wantedYear))
                .Select(s => s.BirthDate);

            foreach (var birthDate in filteredList)
            {
                Console.WriteLine(birthDate);
            }
        }
    }
}
