using System;
using System.Linq;
using System.Text;

namespace P01.SecretChat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StringBuilder concealedMsg = new StringBuilder(Console.ReadLine());

            string command;
            while ((command = Console.ReadLine()) != "Reveal")
            {
                var cmdArgs = command.Split(":|:", StringSplitOptions.RemoveEmptyEntries);
                string currCommand = cmdArgs[0];

                if (currCommand == "InsertSpace")
                {
                    int index = int.Parse(cmdArgs[1]);
                    concealedMsg.Insert(index, ' ');
                }
                else if (currCommand == "Reverse")
                {
                    string substring = cmdArgs[1];
                    if (concealedMsg.ToString().Contains(substring))
                    {
                        int indexSubstring = concealedMsg.ToString().IndexOf(substring);
                        string firstOccurrence = concealedMsg.ToString().Substring(indexSubstring, substring.Length);
                        firstOccurrence = new string(firstOccurrence.Reverse().ToArray());
                        concealedMsg.Remove(indexSubstring, substring.Length);
                        concealedMsg.Append(firstOccurrence);
                    }
                    else
                    {
                        Console.WriteLine("error");
                        continue;
                    }
                }
                else if (currCommand == "ChangeAll")
                {
                    string substring = cmdArgs[1];
                    string replacement = cmdArgs[2];

                    concealedMsg.Replace(substring, replacement);
                }

                Console.WriteLine(concealedMsg.ToString());
            }

            Console.WriteLine($"You have a new text message: {concealedMsg.ToString()}");
        }
    }
}
