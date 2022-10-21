using System;
using System.Collections.Generic;
using System.Linq;

namespace P03.Inventory
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> inventory = Console.ReadLine().Split(", ").ToList();

            string command;
            while ((command = Console.ReadLine()) != "Craft!") 
            {
                string[] cmdArgs = command.Split(" - ");
                string currcommand = cmdArgs[0];
                string item = cmdArgs[1];

                if (currcommand == "Collect")
                {
                    if (!inventory.Contains(item))
                    {
                        inventory.Add(item);
                    }
                }
                else if (currcommand == "Drop")
                {
                    if (inventory.Contains(item))
                    {
                        inventory.Remove(item);
                    }
                }
                else if (currcommand == "Combine Items")
                {
                    string oldItem = item.Split(":")[0];
                    string newItem = item.Split(":")[1];

                    if (inventory.Contains(oldItem))
                    {
                        inventory.Insert(inventory.IndexOf(oldItem) + 1, newItem);
                    }
                }
                else if (currcommand == "Renew")
                {
                    if (inventory.Contains(item))
                    {
                        inventory.Add(item);
                        inventory.Remove(item);
                    }
                }
            }

            Console.WriteLine(string.Join(", ", inventory));
        }
    }
}
