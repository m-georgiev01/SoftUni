using System;
using System.Collections.Generic;

namespace P04.SoftUniParking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var system = new Dictionary<string, string>();

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] cmdArgs = Console.ReadLine().Split();
                string currCmd = cmdArgs[0];
                string username = cmdArgs[1];

                if (currCmd == "register")
                {
                    string licensePlateNumber = cmdArgs[2];

                    if (system.ContainsKey(username))
                    {
                        Console.WriteLine($"ERROR: already registered with plate number {licensePlateNumber}");
                        continue;
                    }
                    else
                    {
                        system.Add(username, licensePlateNumber);
                        Console.WriteLine($"{username} registered {licensePlateNumber} successfully");
                    }
                }
                else if (currCmd == "unregister")
                {
                    if (!system.ContainsKey(username))
                    {
                        Console.WriteLine($"ERROR: user {username} not found");
                        continue;
                    }
                    else
                    {
                        system.Remove(username);
                        Console.WriteLine($"{username} unregistered successfully");
                    }
                }
            }

            foreach (var (key, value) in system)
            {
                Console.WriteLine($"{key} => {value}");
            }
        }
    }
}
