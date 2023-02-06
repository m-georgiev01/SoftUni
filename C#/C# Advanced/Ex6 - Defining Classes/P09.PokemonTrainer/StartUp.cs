namespace P09.PokemonTrainer
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Dictionary<string, Trainer> trainers = new();

            string input;
            while ((input = Console.ReadLine()) != "Tournament")
            {
                var tokens = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string trainerName = tokens[0];
                string pokemonName = tokens[1];
                string pokemonElement = tokens[2];
                int pokemonHealth = int.Parse(tokens[3]);

                Pokemon p = new(pokemonName, pokemonElement, pokemonHealth);

                if (!trainers.ContainsKey(trainerName))
                {
                    trainers.Add(trainerName, new Trainer(trainerName));
                }

                trainers[trainerName].Pokemons.Add(p);
            }

            string pokemonType;
            while ((pokemonType = Console.ReadLine()) != "End")
            {
                foreach (var (_, trainer) in trainers)
                {
                    trainer.CheckPokemonFromGivenType(pokemonType);
                }
            }
            //"{trainerName} {badges} {numberOfPokemon}"
            foreach (var (trainerName, trainer) in trainers.OrderByDescending(t => t.Value.NumberOfBadges))
            {
                Console.WriteLine($"{trainerName} {trainer.NumberOfBadges} {trainer.Pokemons.Count}");
            }
        }
    }
}
