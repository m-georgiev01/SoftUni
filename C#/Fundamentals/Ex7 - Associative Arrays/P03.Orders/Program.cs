using System;
using System.Collections;
using System.Collections.Generic;

namespace P03.Orders
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var orders = new Dictionary<string, List<double>>();

            string command;
            while ((command = Console.ReadLine()) != "buy")
            {
                string[] cmdArgs = command.Split();

                string product = cmdArgs[0];
                double price = double.Parse(cmdArgs[1]);
                double quanity = double.Parse(cmdArgs[2]);

                if (!orders.ContainsKey(product))
                {
                    orders.Add(product, new List<double>() { price, quanity });
                }
                else
                {
                    orders[product][0] = price;
                    orders[product][1] += quanity;
                }

            }

            foreach (var (product, info) in orders)
            {
                Console.WriteLine($"{product} -> {info[0] * info[1]:f2}");
            }
        }
    }
}
