using System;
using System.Collections.Generic;

namespace P03.HeroesOfCodeAndLogicVII
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var heroes = new Dictionary<string, int[]>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                var hero = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string heroName = hero[0];
                int hP = int.Parse(hero[1]);
                int mP = int.Parse(hero[2]);

                heroes.Add(heroName, new int[] {hP, mP});
            }

            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                var cmdArgs = command.Split(" - ", StringSplitOptions.RemoveEmptyEntries);
                string currCmd = cmdArgs[0];
                string heroName = cmdArgs[1];
                

                if (currCmd == "CastSpell")
                {
                    var manaNeeded = int.Parse(cmdArgs[2]);
                    var spellName = cmdArgs[3];

                    if (heroes[heroName][1] - manaNeeded < 0)
                    {
                        Console.WriteLine($"{heroName} does not have enough MP to cast {spellName}!");
                        continue;
                    }

                    heroes[heroName][1] -= manaNeeded;
                    Console.WriteLine($"{heroName} has successfully cast {spellName} and now has {heroes[heroName][1]} MP!");
                }
                else if (currCmd == "TakeDamage")
                {
                    var dmg = int.Parse(cmdArgs[2]);
                    var attacker = cmdArgs[3];

                    if (heroes[heroName][0] - dmg <= 0)
                    {
                        heroes.Remove(heroName);
                        Console.WriteLine($"{heroName} has been killed by {attacker}!");
                        continue;
                    }

                    heroes[heroName][0] -= dmg;
                    Console.WriteLine($"{heroName} was hit for {dmg} HP by {attacker} and now has {heroes[heroName][0]} HP left!");
                }
                else if (currCmd == "Recharge")
                {
                    var amount = int.Parse(cmdArgs[2]);
                    var initialHeroMana = heroes[heroName][1];

                    heroes[heroName][1] += amount;
                    if (heroes[heroName][1] > 200)
                    {
                        heroes[heroName][1] = 200;
                    }

                    Console.WriteLine($"{heroName} recharged for {heroes[heroName][1] - initialHeroMana} MP!");
                }
                else if (currCmd == "Heal")
                {
                    var amount = int.Parse(cmdArgs[2]);
                    var initialHeroHp = heroes[heroName][0];

                    heroes[heroName][0] += amount;
                    if (heroes[heroName][0] > 100)
                    {
                        heroes[heroName][0] = 100;
                    }

                    Console.WriteLine($"{heroName} healed for {heroes[heroName][0] - initialHeroHp} HP!");
                }
            }

            foreach ((string heroName, int[] heroStats) in heroes)
            {
                Console.WriteLine(heroName);
                Console.WriteLine($"  HP: {heroStats[0]}");
                Console.WriteLine($"  MP: {heroStats[1]}");
            }
        }
    }
}
