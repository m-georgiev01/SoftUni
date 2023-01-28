Dictionary<string, Dictionary<string, List<string>>> dict = new();

int n = int.Parse(Console.ReadLine());
for (int i = 0; i < n; i++)
{
    string[] tokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
    string continent = tokens[0];
    string country = tokens[1];
    string city = tokens[2];

    if (!dict.ContainsKey(continent))
    {
        dict.Add(continent, new Dictionary<string, List<string>>());
    }

    if (!dict[continent].ContainsKey(country))
    {
        dict[continent].Add(country, new List<string>() {city});
        continue;
    }

    dict[continent][country].Add(city);
}

foreach (var (continent, countryInfo) in dict)
{
    Console.WriteLine($"{continent}:");
    foreach (var (countryName, cities) in countryInfo)
    {
        Console.WriteLine($" {countryName} -> {string.Join(", ", cities)}");
    }
}
