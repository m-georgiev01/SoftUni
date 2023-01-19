//1 + (2 - (2 + 3) * 4 / (3 + 1)) * 5
string expression = Console.ReadLine();
var openBracketsIndexes = new Stack<int>();

for (int i = 0; i < expression.Length; i++)
{
    if (expression[i] == '(')
    {
        openBracketsIndexes.Push(i);
    }
    else if (expression[i] == ')')
    {
        int startIndex = openBracketsIndexes.Pop();
        Console.WriteLine(expression.Substring(startIndex, i - startIndex + 1));
    }
}
