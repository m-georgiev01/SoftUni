using P01.GenericBoxOfString;

int n = int.Parse(Console.ReadLine());
for (int i = 0; i < n; i++)
{
    string value = Console.ReadLine();
    Box<string> box = new(value);
    Console.WriteLine(box.ToString());
}