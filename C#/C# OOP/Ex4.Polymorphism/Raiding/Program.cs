using Raiding.Factories;
using Raiding.Models.Interfaces;

List<IBaseHero> heroes = new();
HeroFactory heroFactory = new();

int n = int.Parse(Console.ReadLine());

for (int i = 0; i < n; i++)
{
    string name = Console.ReadLine();
    string type = Console.ReadLine();

    try
    { 
        IBaseHero hero = heroFactory.CreateHero(type, name);
        heroes.Add(hero);
    }
    catch (ArgumentException ae)
    {
        Console.WriteLine(ae.Message);
        i--;
    }
}

int bossPower = int.Parse(Console.ReadLine());

foreach (var hero in heroes)
{
    Console.WriteLine(hero.CastAbility());
}

if (heroes.Sum(h => h.Power) >= bossPower)
{
    Console.WriteLine("Victory!");
}
else
{
    Console.WriteLine("Defeat...");
}