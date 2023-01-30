//color, clothes, count
Dictionary<string, Dictionary<string, int>> wardrobe = new();

int n = int.Parse(Console.ReadLine());
for (int i = 0; i < n; i++)
{
    string[] tokens = Console.ReadLine().Split(" -> ");
    string color = tokens[0];
    string[] clothes = tokens[1].Split(',');

    if (!wardrobe.ContainsKey(color))
    {
        wardrobe.Add(color, new Dictionary<string, int>());
    }

    foreach (string cl in clothes)
    {
        if (!wardrobe[color].ContainsKey(cl))
        {
            wardrobe[color].Add(cl, 1);
        }
        else
        {
            wardrobe[color][cl]++;
        }
    }
}

string[] wanted = Console.ReadLine().Split();

foreach (var (color, clothesInfo) in wardrobe)
{
    Console.WriteLine($"{color} clothes:");
    foreach (var (cl, count) in clothesInfo)
    {
        if (color == wanted[0] && cl == wanted[1])
        {
            Console.WriteLine($"* {cl} - {count} (found!)");
        }
        else
        {
            Console.WriteLine($"* {cl} - {count}");
        }
    }
}