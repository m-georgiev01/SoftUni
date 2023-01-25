int[] matrixSizes = Console.ReadLine()
    .Split(", ")
    .Select(int.Parse)
    .ToArray();

int rows = matrixSizes[0];
int cols = matrixSizes[1];

int[,] matrix = new int[rows, cols];

for (int row = 0; row < rows; row++)
{
    int[] data = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
    for (int col = 0; col < cols; col++)
    {
        matrix[row, col] = data[col];
    }
}

int maxSum = int.MinValue;
int maxValueRowIdx = 0;
int maxValueColIdx = 0;

for (int row = 0; row < rows; row++)
{
    for (int col = 0; col < cols; col++)
    {
        if (col < cols - 1 && row < rows - 1)
        {
            int currSum = matrix[row, col];
            currSum += matrix[row, col + 1];
            currSum += matrix[row + 1, col + 1];
            currSum += matrix[row + 1, col];

            if (currSum > maxSum)
            {
                maxValueRowIdx = row; 
                maxValueColIdx = col;
                maxSum = currSum;
            }
        }
    }
}

Console.WriteLine($"{matrix[maxValueRowIdx, maxValueColIdx]} {matrix[maxValueRowIdx, maxValueColIdx + 1]}");
Console.WriteLine($"{matrix[maxValueRowIdx + 1, maxValueColIdx]} {matrix[maxValueRowIdx + 1, maxValueColIdx + 1]}");
Console.WriteLine(maxSum);