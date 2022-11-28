using System;
using System.Linq;
using System.Text;

namespace P01.TheImitationGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StringBuilder encryptedMsg = new StringBuilder().Append(Console.ReadLine());

            string command;
            while ((command = Console.ReadLine()) != "Decode")
            {
                string[] cmdArgs = command.Split("|", StringSplitOptions.RemoveEmptyEntries);
                string currCommand = cmdArgs[0];

                if (currCommand == "Move")
                {
                    int numberOfLetters = int.Parse(cmdArgs[1]);
                    for (int i = 0; i < numberOfLetters; i++)
                    {
                        encryptedMsg.Append(encryptedMsg[i]);
                    }
                    encryptedMsg.Remove(0, numberOfLetters);
                }
                else if (currCommand == "Insert")
                {
                    int index = int.Parse(cmdArgs[1]);
                    string value = cmdArgs[2];

                    encryptedMsg.Insert(index, value);
                }
                else if (currCommand == "ChangeAll")
                {
                    string substring = cmdArgs[1];
                    string replacement = cmdArgs[2];

                    encryptedMsg.Replace(substring, replacement);
                }
            }

            Console.WriteLine($"The decrypted message is: {encryptedMsg.ToString()}");
        }
    }
}
