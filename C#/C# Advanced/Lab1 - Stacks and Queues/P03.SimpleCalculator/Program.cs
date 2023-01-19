string[] input = Console.ReadLine().Split();
var stack = new Stack<string>(input);

int sum = 0;

while (stack.Any())
{
    string digit = stack.Pop();
    string sign = string.Empty;
    stack.TryPop(out sign);

    int number = int.Parse($"{sign}{digit}");

    sum += number;
}

Console.WriteLine(sum);