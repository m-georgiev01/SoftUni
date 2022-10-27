using System;
using System.Collections.Generic;
using System.Linq;

namespace P06.StoreBoxes
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Box> boxes = new List<Box>();

            string command;
            while ((command = Console.ReadLine()) != "end")
            {
                string[] cmdArgs = command.Split();
                string serialNumber = cmdArgs[0];
                string itemName = cmdArgs[1];
                int itemQuantity = int.Parse(cmdArgs[2]);
                double itemPrice = double.Parse(cmdArgs[3]);

                var item = new Item(itemName, itemPrice);
                var box = new Box(serialNumber, item, itemQuantity);

                boxes.Add(box);
            }

            foreach (var box in boxes.OrderByDescending(x => x.PricePerBox))
            {
                Console.WriteLine(box.SerialNumber);
                Console.WriteLine($"-- {box.item.Name} - ${box.item.Price:F2}: {box.ItemQuantity}");
                Console.WriteLine($"-- ${box.PricePerBox:F2}");
            }
        }
    }
    class Item
    {
        public string Name { get; set; }
        public double Price { get; set; }

        public Item(string name, double price)
        {
            Name = name;
            Price = price;
        }
    }

    class Box
    {
        public string SerialNumber { get; set; }
        public Item item { get; set; }
        public int ItemQuantity { get; set; }
        public double PricePerBox
        {
            get
            {
                return ItemQuantity * item.Price;
            }
        }

        public Box(string serialNumber, Item item, int itemQuantity)
        {
            SerialNumber = serialNumber;
            this.item = item;
            ItemQuantity = itemQuantity;
        }
    }
}
