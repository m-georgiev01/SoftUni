int rows = int.Parse(Console.ReadLine());
long[][] pascal = new long[rows][];
pascal[0] = new[] {1L};

for (int row = 1; row < rows; row++)
{
    pascal[row] = new long[row + 1];
    for (int col = 0; col < row + 1; col++)
    {
        if (col < pascal[row - 1].Length)
        {
            pascal[row][col] += pascal[row - 1][col];
        }

        if (col - 1 >= 0)
        {
            pascal[row][col] += pascal[row - 1][col - 1];
        }
    }
}

for (int i = 0; i < rows; i++)
{
    Console.WriteLine(string.Join(" ", pascal[i]));
}