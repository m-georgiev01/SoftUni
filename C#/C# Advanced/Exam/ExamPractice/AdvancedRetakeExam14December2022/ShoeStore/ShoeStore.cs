using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoeStore
{
    public class ShoeStore
    {
        public ShoeStore(string name, int storageCapacity)
        {
            Name = name;
            StorageCapacity = storageCapacity;
            Shoes = new();
        }

        public string Name { get; set; }
        public int StorageCapacity { get; set; }
        public List<Shoe> Shoes { get; private set; }
        public int Count => Shoes.Count;

        public string AddShoe(Shoe shoe)
        {
            if (Shoes.Count == StorageCapacity)
            {
                return "No more space in the storage room.";
            }

            Shoes.Add(shoe);
            return $"Successfully added {shoe.Type} {shoe.Material} pair of shoes to the store.";
        }

        public int RemoveShoes(string material) => Shoes.RemoveAll(s => s.Material == material);

        public List<Shoe> GetShoesByType(string type)
        {
            List<Shoe> shoes = new();
            foreach (var shoe in Shoes)
            {
                if (shoe.Type.ToLower() == type.ToLower())
                {
                    shoes.Add(shoe);
                }
            }

            return shoes;
        }

        public Shoe GetShoeBySize(double size) => Shoes.FirstOrDefault(s => s.Size == size);

        public string StockList(double size, string type)
        {
            StringBuilder sb = new();

            foreach (var shoe in Shoes)
            {
                if (shoe.Size == size && shoe.Type == type)
                {
                    if (sb.Length == 0)
                    {
                        sb.AppendLine($"Stock list for size {size} - {type} shoes:");
                    }

                    sb.AppendLine(shoe.ToString());
                }
            }

            if (sb.Length == 0)
            {
                sb.AppendLine("No matches found!");
            }

            return sb.ToString().TrimEnd();
        }

    }
}
