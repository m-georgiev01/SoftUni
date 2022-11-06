using System;
using System.Collections.Generic;

namespace P05.Courses
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var courses = new Dictionary<string, List<string>>();

            string command;
            while ((command = Console.ReadLine()) != "end")
            {
                string[] cmdArgs = command.Split(" : ");
                string courseName = cmdArgs[0];
                string student = cmdArgs[1];

                if (!courses.ContainsKey(courseName))
                {
                    courses.Add(courseName, new List<string>());
                }

                courses[courseName].Add(student);
            }

            foreach (var (key, value) in courses)
            {
                Console.WriteLine($"{key}: {value.Count}");

                foreach (var student in value)
                {
                    Console.WriteLine($"-- {student}");
                }
            }
        }
    }
}
