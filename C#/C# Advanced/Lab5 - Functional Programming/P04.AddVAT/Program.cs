double[] prices = Console.ReadLine()
    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
    .Select(x => double.Parse(x) * 1.2)
    .ToArray();

Console.WriteLine(string.Join(Environment.NewLine, prices.Select(x => $"{x:f2}")));