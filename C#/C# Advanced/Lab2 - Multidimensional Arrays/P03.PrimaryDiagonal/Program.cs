int size = int.Parse(Console.ReadLine());
int sum = 0;

for (int row = 0; row < size; row++)
{
    int[] data = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
    for (int col = 0; col < size; col++)
    {
        if (row == col)
        {
            sum += data[col];
        }
    }
}

Console.WriteLine(sum);