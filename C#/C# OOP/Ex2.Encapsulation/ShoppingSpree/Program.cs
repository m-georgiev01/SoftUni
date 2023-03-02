using ShoppingSpree;

List<Person> people = new();
List<Product> products = new();

string[] peopleInfo = Console.ReadLine().Split(new char[] { '=', ';' }, StringSplitOptions.RemoveEmptyEntries);
string[] productsInfo = Console.ReadLine().Split(new char[] { '=', ';' }, StringSplitOptions.RemoveEmptyEntries);

try
{
    for (int i = 0; i < peopleInfo.Length - 1; i += 2)
    {
        string name = peopleInfo[i];
        decimal money = decimal.Parse(peopleInfo[i + 1]);
        people.Add(new Person(name, money));
    }


    for (int i = 0; i < productsInfo.Length - 1; i += 2)
    {
        string name = productsInfo[i];
        decimal cost = decimal.Parse(productsInfo[i + 1]);
        products.Add(new Product(name, cost));
    }
}
catch (ArgumentException ae)
{
    Console.WriteLine(ae.Message);
    Environment.Exit(0);
}

string input = Console.ReadLine();

while (input != "END")
{
    string[] tokens = input.Split();

    string personName = tokens[0];
    string productName = tokens[1];

    var person = people.FirstOrDefault(x => x.Name == personName);
    var product = products.FirstOrDefault(x => x.Name == productName);

    try
    {
        Console.WriteLine(person.BuyProduct(product));
    }
    catch (InvalidOperationException ioe)
    {
        Console.WriteLine(ioe.Message);
    }

    input = Console.ReadLine();
}

foreach (var person in people)
{
    Console.WriteLine(person);
}