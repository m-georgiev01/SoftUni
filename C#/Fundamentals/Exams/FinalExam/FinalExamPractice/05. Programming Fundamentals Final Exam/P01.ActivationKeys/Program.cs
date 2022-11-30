using System;
using System.Text;

namespace P01.ActivationKeys
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StringBuilder activationKey = new StringBuilder(Console.ReadLine());

            string command;
            while ((command = Console.ReadLine()) != "Generate")
            {
                var cmdArgs = command.Split(">>>", StringSplitOptions.RemoveEmptyEntries);
                var currCmd = cmdArgs[0];

                if (currCmd == "Contains")
                {
                    string substring = cmdArgs[1];

                    if (!activationKey.ToString().Contains(substring))
                    {
                        Console.WriteLine("Substring not found!");
                        continue;
                    }

                    Console.WriteLine($"{activationKey} contains {substring}");
                }
                else if (currCmd == "Flip")
                {
                    string cmd = cmdArgs[1];
                    int startIndex = int.Parse(cmdArgs[2]);
                    int endIndex = int.Parse(cmdArgs[3]);
                    string substring = activationKey.ToString().Substring(startIndex, endIndex - startIndex);

                    if (cmd == "Upper")
                    {
                        substring = substring.ToUpper();
                    }
                    else if (cmd == "Lower")
                    {
                        substring = substring.ToLower();
                    }

                    activationKey.Remove(startIndex, endIndex - startIndex);
                    activationKey.Insert(startIndex, substring);
                    Console.WriteLine(activationKey.ToString());
                }
                else if (currCmd == "Slice")
                {
                    int startIndex = int.Parse(cmdArgs[1]);
                    int endIndex = int.Parse(cmdArgs[2]);

                    activationKey.Remove(startIndex, endIndex - startIndex);
                    Console.WriteLine(activationKey.ToString());
                }
            }

            Console.WriteLine($"Your activation key is: {activationKey.ToString()}");
        }
    }
}
