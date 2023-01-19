string input = Console.ReadLine();
var stack = new Stack<char>();

for (int i = 0; i < input.Length; i++)
{
    stack.Push(input[i]);
}

for (int i = 0; i < input.Length; i++)
{
    Console.Write(stack.Pop());
}