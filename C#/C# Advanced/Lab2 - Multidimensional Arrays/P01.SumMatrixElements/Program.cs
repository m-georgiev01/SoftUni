int[] matrixSizes = Console.ReadLine()
    .Split(", ")
    .Select(int.Parse)
    .ToArray();

int rows = matrixSizes[0];
int cols = matrixSizes[1];
int sum = 0;

for (int row = 0; row < rows; row++)
{
    int[] data = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
    sum += data.Sum();
}

Console.WriteLine(rows);
Console.WriteLine(cols);
Console.WriteLine(sum);

