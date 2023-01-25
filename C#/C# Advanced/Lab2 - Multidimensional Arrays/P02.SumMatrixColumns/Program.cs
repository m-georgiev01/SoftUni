int[] matrixSizes = Console.ReadLine()
    .Split(", ")
    .Select(int.Parse)
    .ToArray();

int rows = matrixSizes[0];
int cols = matrixSizes[1];

int[,] matrix = new int[rows, cols];

for (int row = 0; row < rows; row++)
{
    int[] data = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
    for (int col = 0; col < cols; col++)
    {
        matrix[row, col] = data[col];
    }
}

for (int c = 0; c < cols; c++)
{
    int sum = 0;
    for (int r = 0; r < rows; r++)
    {
        sum += matrix[r, c];
    }

    Console.WriteLine(sum);
}