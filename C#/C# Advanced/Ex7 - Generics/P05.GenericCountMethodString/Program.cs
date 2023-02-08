using P05.GenericCountMethodString;

Box<string> box = new();

int n = int.Parse(Console.ReadLine());
for (int i = 0; i < n; i++)
{
    string input = Console.ReadLine();
    box.Add(input);
}

string elementToCompare = Console.ReadLine();

Console.WriteLine(box.Count(elementToCompare));
