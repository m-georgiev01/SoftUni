int[] size = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
char[,] playground= new char[size[0] , size[1]];

int currRow = 0;
int currCol = 0;
int touchedOponents = 0;
bool isFinished = false;
int moves = 0;

for (int row = 0; row < size[0]; row++)
{
    char[] data = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();
    for (int col = 0; col < size[1]; col++)
    {
        if (data[col] == 'B')
        {
            currRow = row;
            currCol = col;
            playground[row, col] = '-';
            continue;
        }
        playground[row, col] = data[col];
    }
}

string direction;
while ((direction = Console.ReadLine()) != "Finish")
{
    

    if (direction == "up")
    {
        Tuple<int, int> nextPosition = new(currRow - 1, currCol);
        MakeAMove(nextPosition, ref currRow, ref currCol);
    }
    else if (direction == "right")
    {
        Tuple<int, int> nextPosition = new(currRow, currCol + 1);
        MakeAMove(nextPosition, ref currRow, ref currCol);
    }
    else if (direction == "down")
    {
        Tuple<int, int> nextPosition = new(currRow + 1, currCol);
        MakeAMove(nextPosition, ref currRow, ref currCol);
    }
    else if (direction == "left")
    {
        Tuple<int, int> nextPosition = new(currRow, currCol - 1);
        MakeAMove(nextPosition, ref currRow, ref currCol);
    }

    if (isFinished)
    {
        break;
    }
}

Console.WriteLine("Game over!");
Console.WriteLine($"Touched opponents: {touchedOponents} Moves made: {moves}");

bool IsInPlayground(int row, int col)
{
    return row >= 0 && row < playground.GetLength(0) &&
           col >= 0 && col < playground.GetLength(1);
}

void MakeAMove(Tuple<int, int> nextPosition, ref int row, ref int col)
{
    if ((!IsInPlayground(nextPosition.Item1, nextPosition.Item2)) ||
        (playground[nextPosition.Item1, nextPosition.Item2] == 'O'))
    {
        return;
    }

    if (playground[nextPosition.Item1, nextPosition.Item2] == 'P')
    {
        touchedOponents++;

        if (touchedOponents == 3)
        {
            isFinished = true;
        }
    }

    moves++;
    playground[nextPosition.Item1, nextPosition.Item2] = '-';
    row = nextPosition.Item1;
    col = nextPosition.Item2;
}