using P01.ListyIterator;

string[] createCmd = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
ListyIterator<string> li = new(createCmd.Skip(1).ToArray());

string cmd;
while ((cmd = Console.ReadLine()) != "END")
{
    switch (cmd)
    {
        case "Move":
            Console.WriteLine(li.Move());
            break;
        case "Print":
            try
            {
                li.Print();
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e.Message);
            }
            break;
        case "HasNext":
            Console.WriteLine(li.HasNext());
            break;
    }
}