using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComputerArchitecture
{
    public class Computer
    {
        public Computer(string model, int capacity)
        {
            Model = model;
            Capacity = capacity;
            Multiprocessor = new();
        }

        public string Model { get; set; }
        public int Capacity { get; set; }
        public List<CPU> Multiprocessor { get; private set; }
        public int Count => Multiprocessor.Count;

        public void Add(CPU cpu)
        {
            if (Count + 1 <= Capacity)
            {
                Multiprocessor.Add(cpu);
            }
        }

        public bool Remove(string brand)
        {
            CPU wantedCPU = Multiprocessor.FirstOrDefault(c => c.Brand == brand);

            if (wantedCPU != null)
            {
                Multiprocessor.Remove(wantedCPU);
                return true;
            }

            return false;
        }

        public CPU MostPowerful() => Multiprocessor.MaxBy(c => c.Frequency);

        public CPU GetCPU(string brand) => Multiprocessor.FirstOrDefault(c => c.Brand == brand);

        public string Report()
        {
            StringBuilder sb = new();
            sb.AppendLine($"CPUs in the Computer {Model}:");
            sb.AppendLine(string.Join(Environment.NewLine, Multiprocessor));

            return sb.ToString().TrimEnd();
        }
    }
}
