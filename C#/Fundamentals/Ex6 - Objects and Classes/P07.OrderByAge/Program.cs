using System;
using System.Collections.Generic;
using System.Linq;

namespace P07.OrderByAge
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();

            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] cmdArgs = command.Split();
                string name = cmdArgs[0];
                string id = cmdArgs[1];
                int age = int.Parse(cmdArgs[2]);

                var p = people.FirstOrDefault(x => x.Id == id);
                if (p != null)
                {
                    p.Name = name;
                    p.Age = age;
                }

                p = new Person(name, id, age);
                people.Add(p);
            }

            foreach (var p in people.OrderBy(x => x.Age))
            {
                Console.WriteLine(p);
            }
        }
    }
    
    class Person
    {
        public string Name { get; set; }
        public string Id { get; set; }
        public int Age { get; set; }

        public Person(string name, string id, int age)
        {
            Name = name;
            Id = id;
            Age = age;
        }

        public override string ToString()
        {
            return $"{Name} with ID: {Id} is {Age} years old.";
        }
    }
}
