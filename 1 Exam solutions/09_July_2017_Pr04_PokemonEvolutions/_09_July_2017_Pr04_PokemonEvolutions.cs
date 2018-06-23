using System;
using System.Collections.Generic;
using System.Linq;

namespace _09_July_2017_Pr04_PokemonEvolutions
{
    class _09_July_2017_Pr04_PokemonEvolutions
    {
        static void Main()
        {
            Dictionary<string, List<PokemonEvolution>> dictPokemonDataBase = new Dictionary<string, List<PokemonEvolution>>();

            while (true)
            {

                string input = Console.ReadLine();

                if (input.Equals("wubbalubbadubdub"))
                {
                    break;
                }

                string[] pokeData = input
                    .Split(" -> ",
                    StringSplitOptions.RemoveEmptyEntries);

                string pokemonName = pokeData[0];

                if (pokeData.Length == 1 && dictPokemonDataBase.ContainsKey(pokemonName))
                {
                    Console.WriteLine($"# {pokemonName}");

                    foreach (var evol in dictPokemonDataBase[pokemonName])
                    {
                        Console.WriteLine($"{evol.EvolutionType} <-> {evol.EvolutionIndex}");

                    }
                    continue;
                }
                else
                {
                    PokemonEvolution currentPoke = new PokemonEvolution();
                    currentPoke.EvolutionType = pokeData[1];
                    currentPoke.EvolutionIndex = ulong.Parse(pokeData[2]);

                    if (dictPokemonDataBase.ContainsKey(pokemonName) == false)
                    {
                        dictPokemonDataBase.Add(pokemonName, new List<PokemonEvolution>());

                    }
                    dictPokemonDataBase[pokemonName].Add(currentPoke);

                }
            }

            foreach (var poke in dictPokemonDataBase)
            {
                Console.WriteLine("# " + poke.Key);

                foreach (var evol in poke.Value.OrderByDescending(x => x.EvolutionIndex))
                {
                    Console.WriteLine($"{evol.EvolutionType} <-> {evol.EvolutionIndex}");

                }
            }

        }
    }
    
}