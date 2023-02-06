namespace P09.PokemonTrainer
{
    public class Trainer
    {
        public Trainer(string name)
        {
            Name = name;
            Pokemons = new();
        }

        public string Name { get; set; }
        public int NumberOfBadges { get; set; }
        public List<Pokemon> Pokemons { get; set; }

        public void CheckPokemonFromGivenType (string pokemonType)
        {
            Pokemon? foundPokemon = Pokemons.Find(x => x.Element == pokemonType);

            if (foundPokemon != null)
            {
                NumberOfBadges++;
            }
            else
            {
                for (int i = 0; i < Pokemons.Count; i++)
                {
                    Pokemon currentPokemon = Pokemons[i];

                    currentPokemon.Health -= 10;

                    if (currentPokemon.Health <= 0)
                    {
                        Pokemons.Remove(currentPokemon);
                    }
                }
            }
        }
    }
}
