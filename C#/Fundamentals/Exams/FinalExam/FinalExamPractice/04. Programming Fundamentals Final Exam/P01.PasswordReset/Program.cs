using System;
using System.Linq;
using System.Text;

namespace P01.PasswordReset
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StringBuilder rawPass = new StringBuilder(Console.ReadLine());

            string command;
            while ((command = Console.ReadLine()) != "Done")
            {
                var cmdArgs = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string currCmd = cmdArgs[0];

                if (currCmd == "TakeOdd")
                {
                    int startLength = rawPass.Length;
                    rawPass.Append(new string(rawPass.ToString().Where((c, i) => i % 2 == 1).ToArray()));
                    rawPass.Remove(0, startLength);
                }
                else if (currCmd == "Cut")
                {
                    int index = int.Parse(cmdArgs[1]);
                    int length = int.Parse(cmdArgs[2]);
                    rawPass.Remove(index, length);
                }
                else if (currCmd == "Substitute")
                {
                    string substring = cmdArgs[1];
                    string substitute = cmdArgs[2];

                    if (!rawPass.ToString().Contains(substring))
                    {
                        Console.WriteLine("Nothing to replace!");
                        continue;
                        
                    }
                    rawPass.Replace(substring, substitute);
                }

                Console.WriteLine(rawPass.ToString());
            }

            Console.WriteLine($"Your password is: {rawPass.ToString()}");
        }
    }
}
