using System;
using System.Collections.Generic;
using System.Linq;

namespace P03.ChatLogger
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> chatMsges = new List<string>();

            string command;
            while ((command = Console.ReadLine()) != "end")
            {
                string[] cmdArgs = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string currCommand = cmdArgs[0];

                if (currCommand == "Chat")
                {
                    chatMsges.Add(cmdArgs[1]);
                }
                else if (currCommand == "Delete")
                {
                    if (chatMsges.Contains(cmdArgs[1]))
                    {
                        chatMsges.Remove(cmdArgs[1]);
                    }
                }
                else if (currCommand == "Edit")
                {
                    if (chatMsges.Contains(cmdArgs[1]))
                    {
                        chatMsges[chatMsges.IndexOf(cmdArgs[1])] = cmdArgs[2];
                    }
                }
                else if (currCommand == "Pin")
                {
                    if (chatMsges.Contains(cmdArgs[1]))
                    {
                        chatMsges.Add(cmdArgs[1]);
                        chatMsges.Remove(cmdArgs[1]);
                    }
                }
                else if (currCommand == "Spam")
                {
                    string[] spamMsges = cmdArgs.Skip(1).ToArray();
                    chatMsges.AddRange(spamMsges);
                }
            }

            Console.WriteLine(string.Join(Environment.NewLine, chatMsges));
        }
    }
}
