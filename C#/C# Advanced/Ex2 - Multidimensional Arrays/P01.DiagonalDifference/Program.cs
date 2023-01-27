int size = int.Parse(Console.ReadLine());

int[,] matrix = new int[size, size];
int sumPrimaryDiagonal = 0;
int sumSecondaryDiagonal = 0;

for (int row = 0; row < size; row++)
{
    int[] data = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
    for (int col = 0; col < size; col++)
    {
        matrix[row, col] = data[col];
    }
}

for (int r = 0; r < size; r++)
{
    sumPrimaryDiagonal += matrix[r, r];
    sumSecondaryDiagonal += matrix[r, size - 1 - r];
}

Console.WriteLine(Math.Abs(sumPrimaryDiagonal - sumSecondaryDiagonal));