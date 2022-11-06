using System;
using System.Collections.Generic;
using System.Linq;

namespace P06.StudentAcademy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var studentsAcademy = new Dictionary<string, List<double>>();
            
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string name = Console.ReadLine();
                double grade = double.Parse(Console.ReadLine());

                if (!studentsAcademy.ContainsKey(name))
                {
                    studentsAcademy.Add(name, new List<double>());
                }

                studentsAcademy[name].Add(grade);
            }

            foreach (var (key, value) in studentsAcademy.Where(x => x.Value.Average() >= 4.5))
            {
                Console.WriteLine($"{key} -> {value.Average():F2}");
            }
        }
    }
}
