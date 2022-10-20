using System;
using System.Collections.Generic;
using System.Linq;

namespace P09.PokemonDontGo
{
    class Program
    {
        static void Main(string[] args)
        {
            List<long> pokemons = Console.ReadLine()
                                  .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                  .Select(long.Parse)
                                  .ToList();

            long sumRemovedElements = 0;

            while (pokemons.Any())
            {
                int index = int.Parse(Console.ReadLine());
                long target = 0;

                if (index < 0)
                {
                    target = pokemons[0];
                    pokemons.RemoveAt(0);
                    pokemons.Insert(0, pokemons[pokemons.Count - 1]);
                }
                else if (index >= pokemons.Count)
                {
                    target = pokemons[pokemons.Count - 1];
                    pokemons.RemoveAt(pokemons.Count - 1);
                    pokemons.Add(pokemons[0]);
                }
                else
                {
                    target = pokemons[index];
                    pokemons.RemoveAt(index);
                }
                
                pokemons = pokemons.Select(x => (x <= target ? x += target : x -= target)).ToList();

                sumRemovedElements += target;
            }

            Console.WriteLine(sumRemovedElements);
        }
    }
}
