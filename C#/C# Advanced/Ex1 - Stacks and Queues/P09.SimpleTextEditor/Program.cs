using System.Text;

Stack<string> textHistory = new();
StringBuilder text = new();

int n = int.Parse(Console.ReadLine());
for (int i = 0; i < n; i++)
{
    string[] cmdArgs = Console.ReadLine().Split();
    string currCmd = cmdArgs[0];

    if (currCmd == "1")
    {
        string someText = cmdArgs[1];
        text.Append(someText);
        textHistory.Push(text.ToString());
    }
    else if (currCmd == "2")
    {
        int count = int.Parse(cmdArgs[1]);
        text.Remove(text.Length - count, count);
        textHistory.Push(text.ToString());
    }
    else if (currCmd == "3")
    {
        int index = int.Parse(cmdArgs[1]);
        Console.WriteLine(text[--index]);
    }
    else if (currCmd == "4")
    {
        textHistory.Pop();
        text.Clear();

        if (textHistory.Any())
        {
            text.Append(textHistory.Peek());
        }
    }
}