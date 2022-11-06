using System;
using System.Collections.Generic;

namespace P02.AMinerTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var items = new Dictionary<string, ulong>();

            string command;
            while ((command = Console.ReadLine()) != "stop")
            {
                string resource = command;
                ulong quantitty = ulong.Parse(Console.ReadLine());

                if (!items.ContainsKey(resource))
                {
                    items.Add(resource, 0);
                }
                items[resource] += quantitty;
            }

            foreach (var (resourse, quantity) in items)
            {
                Console.WriteLine($"{resourse} -> {quantity}");
            }
        }
    }
}
