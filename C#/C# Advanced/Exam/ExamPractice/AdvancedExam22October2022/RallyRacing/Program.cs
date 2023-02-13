int size = int.Parse(Console.ReadLine());
char[,] racingTrack = new char[size, size];

string racingNumber = Console.ReadLine();

int currRow = 0;
int currCol = 0;
int distanceCovered = 0;
bool isFinished = false;

for (int row = 0; row < size; row++)
{
    char[] data = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();
    for (int col = 0; col < size; col++)
    {
        racingTrack[row, col] = data[col];
    }
}

string cmd;
while ((cmd = Console.ReadLine()) != "End")
{
    switch (cmd)
    {
        case "up":
            currRow--;
            CheckPosition(currRow, currCol);
            break;

        case "right":
            currCol++;
            CheckPosition(currRow, currCol);
            break;

        case "down":
            currRow++;
            CheckPosition(currRow, currCol);
            break;

        case "left":
            currCol--;
            CheckPosition(currRow, currCol);
            break;
    }

    if (isFinished)
    {
        break;
    }
}

if (isFinished)
{
    Console.WriteLine($"Racing car {racingNumber} finished the stage!");
}
else
{
    Console.WriteLine($"Racing car {racingNumber} DNF.");
}

Console.WriteLine($"Distance covered {distanceCovered} km.");
PrintMatrix();

void CheckPosition(int row, int col)
{
    switch (racingTrack[row, col])
    {
        case '.':
            distanceCovered += 10;
            break;

        case 'F':
            distanceCovered += 10;
            isFinished = true;
            break;

        case 'T':
            distanceCovered += 30;
            racingTrack[row, col] = '.';
            Tuple<int, int> otherEndTunnel = CoordinatesOf(racingTrack, 'T');
            racingTrack[otherEndTunnel.Item1, otherEndTunnel.Item2] = '.';
            currRow = otherEndTunnel.Item1;
            currCol = otherEndTunnel.Item2;
            break;
    }
}

static Tuple<int, int> CoordinatesOf<T>(T[,] matrix, T value)
{
    for (int x = 0; x < matrix.GetLength(0); ++x)
    {
        for (int y = 0; y < matrix.GetLength(0); ++y)
        {
            if (matrix[x, y].Equals(value))
                return Tuple.Create(x, y);
        }
    }

    return default;
}

void PrintMatrix()
{
    racingTrack[currRow, currCol] = 'C';

    for (int r = 0; r < size; r++)
    {
        for (int c = 0; c < size; c++)
        {
            Console.Write($"{racingTrack[r, c]}");
        }

        Console.WriteLine();
    }
}