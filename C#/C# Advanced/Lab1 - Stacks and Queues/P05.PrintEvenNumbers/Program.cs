int[] input = Console.ReadLine()
              .Split()
              .Select(int.Parse)
              .ToArray();

var numbers = new Queue<int>(input);

for (int i = 0; i < numbers.Count; i++)
{
    int currNum = numbers.Dequeue();
    
    if (currNum % 2 == 0)
    {
        numbers.Enqueue(currNum);
        continue;
    }

    i--;
}

Console.WriteLine(string.Join(", ", numbers));