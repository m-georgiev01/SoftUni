var customers = new Queue<string>();

string input;
while ((input = Console.ReadLine()) != "End")
{
    if (input == "Paid")
    {
        Console.WriteLine(string.Join(Environment.NewLine, customers));
        customers.Clear();
    }
    else
    {
        customers.Enqueue(input);
    }
}

Console.WriteLine($"{customers.Count} people remaining.");