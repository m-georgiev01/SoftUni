using System;
using System.Text;

namespace P01.StringGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StringBuilder text = new StringBuilder(Console.ReadLine());

            string command;
            while ((command = Console.ReadLine()) != "Done")
            {
                var cmdArgs = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string currCmd = cmdArgs[0];

                if (currCmd == "Change")
                {
                    char oldChar = char.Parse(cmdArgs[1]);
                    char replacement = char.Parse(cmdArgs[2]);

                    text.Replace(oldChar, replacement);
                    Console.WriteLine(text.ToString());
                }
                else if (currCmd == "Includes")
                {
                    string substring = cmdArgs[1];
                    Console.WriteLine(text.ToString().Contains(substring));
                }
                else if (currCmd == "End")
                {
                    string substring = cmdArgs[1];
                    Console.WriteLine(text.ToString().EndsWith(substring));
                }
                else if (currCmd == "Uppercase")
                {
                    string upperText = text.ToString().ToUpper();
                    text.Clear();
                    text.Append(upperText);
                    Console.WriteLine(text.ToString());
                    
                }
                else if (currCmd == "FindIndex")
                {
                    char c = char.Parse(cmdArgs[1]);
                    Console.WriteLine(text.ToString().IndexOf(c));
                }
                else if (currCmd == "Cut")
                {
                    int startIndex = int.Parse(cmdArgs[1]);
                    int count = int.Parse(cmdArgs[2]);
                    string substring = text.ToString().Substring(startIndex, count);
                    text.Clear();
                    text.Append(substring);
                    Console.WriteLine(text.ToString());
                }
            }
        }
    }
}
