int[] tokens = Console.ReadLine()
                     .Split()
                     .Select(int.Parse)
                     .ToArray();

int numPop = tokens[1];
int lookFor = tokens[2];

int[] numbers = Console.ReadLine()
    .Split()
    .Select(int.Parse)
    .ToArray();

var stack = new Stack<int>(numbers);

for (int i = 0; i < numPop;i++)
{
    stack.Pop();
}

if (stack.Contains(lookFor))
{
    Console.WriteLine("true");
}
else
{
    if (stack.Any())
    { 
        Console.WriteLine(stack.Min());
    }
    else
    {
        Console.WriteLine(0);
    }
   
}