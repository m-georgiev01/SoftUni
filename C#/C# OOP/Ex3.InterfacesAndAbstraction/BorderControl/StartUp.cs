using BorderControl.Models;
using BorderControl.Models.Interfaces;

namespace BorderControl
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<IIdentifiable> society = new();

            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                var tokens = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                IIdentifiable identifiable;
                if (tokens.Length == 3)
                {
                    identifiable = new Citizen(tokens[2], tokens[0], int.Parse(tokens[1]));
                }
                else
                {
                    identifiable = new Robot(tokens[1], tokens[0]);
                }

                society.Add(identifiable);
            }

            string fakeIdsLastDigits = Console.ReadLine();
            
            var fakeIDsList = society
                .Where(s => s.Id.EndsWith(fakeIdsLastDigits))
                .Select(s => s.Id);

            foreach (var fakeId in fakeIDsList)
            {
                Console.WriteLine(fakeId);
            }

        }
    }
}
