using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftUniKindergarten
{
    public class Kindergarten
    {
        public Kindergarten(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            Registry = new();
        }

        public string Name { get; set; }
        public int Capacity { get; set; }
        public List<Child> Registry { get; private set; }
        public int ChildrenCount => Registry.Count;

        public bool AddChild(Child child)
        {
            if (ChildrenCount + 1 > Capacity)
            {
                return false;
            }

            Registry.Add(child);
            return true;
        }

        public Child GetChild(string childFullName) => Registry.FirstOrDefault(c => c.FullName == childFullName);

        public bool RemoveChild(string childFullName) => Registry.Remove(GetChild(childFullName));

        public string RegistryReport()
        {
            StringBuilder sb = new();
            sb.AppendLine($"Registered children in {Name}:");

            var fillteredRegistry = Registry
                .OrderByDescending(c => c.Age)
                .ThenBy(c => c.LastName)
                .ThenBy(c => c.FirstName);

            sb.AppendLine(string.Join(Environment.NewLine, fillteredRegistry));

            return sb.ToString().TrimEnd();
        }
    }
}
