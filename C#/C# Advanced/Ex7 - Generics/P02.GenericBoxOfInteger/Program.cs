using P02.GenericBoxOfInteger;

int n = int.Parse(Console.ReadLine());
for (int i = 0; i < n; i++)
{
    int value = int.Parse(Console.ReadLine());
    Box<int> box = new(value);
    Console.WriteLine(box.ToString());
}