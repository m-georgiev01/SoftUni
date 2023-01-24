var stack = new Stack<int>();

int n = int.Parse(Console.ReadLine());

for (int i = 0; i < n; i++)
{
    string[] query = Console.ReadLine().Split();
    string type = query[0];

    if (type == "1")
    {
        int element = int.Parse(query[1]);
        stack.Push(element);
    }
    else if (type == "2")
    {
        if (stack.Any())
        {
            stack.Pop();
        }
    }
    else if (type == "3")
    {
        if (stack.Any())
        {
            Console.WriteLine(stack.Max());
        }
    }
    else if (type == "4")
    {
        if (stack.Any())
        {
            Console.WriteLine(stack.Min());
        }
    }
}

Console.WriteLine(string.Join(", ", stack));