Dictionary<string, Dictionary<string, double>> dict = new();

string input;
while ((input = Console.ReadLine()) != "Revision")
{
    var tokens = input.Split(", ", StringSplitOptions.RemoveEmptyEntries);
    string shop = tokens[0];
    string product = tokens[1];
    double price = double.Parse(tokens[2]);

    if (!dict.ContainsKey(shop))
    {
        dict.Add(shop, new Dictionary<string, double>());
    }

    dict[shop].Add(product, price);
}

foreach (var (shop, productsinfo) in dict.OrderBy(x => x.Key))
{
    Console.WriteLine($"{shop}->");
    foreach (var (product, price) in productsinfo)
    {
        Console.WriteLine($"Product: {product}, Price: {price}");
    }
}