using P03.GenericSwapMethodString;

List<Box<string>> boxes = new();

int n = int.Parse(Console.ReadLine());
for (int i = 0; i < n; i++)
{
    Box<string> box = new(Console.ReadLine());
    boxes.Add(box);
}

var tokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
int indexOne = int.Parse(tokens[0]);
int indexTwo = int.Parse(tokens[1]);

SwapBoxesInList(boxes, indexOne, indexTwo);

foreach (var box in boxes)
{
    Console.WriteLine(box);
}


void SwapBoxesInList<T>(List<T> list, int indexOne, int indexTwo)
{
    if (indexOne >= 0 && indexOne < list.Count &&
        indexTwo >= 0 && indexTwo < list.Count)
    {
        (list[indexOne], list[indexTwo]) = (list[indexTwo], list[indexOne]);
    }
}