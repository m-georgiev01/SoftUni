using System;
using System.Collections.Generic;
using System.Linq;

namespace P04.Students
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>();

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] studentStartState = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string firstName = studentStartState[0];
                string lastName = studentStartState[1];
                double grade = double.Parse(studentStartState[2]);

                var student = new Student(firstName, lastName, grade);
                students.Add(student);
            }

            foreach (var st in students.OrderByDescending(x => x.Grade))
            {
                Console.WriteLine(st);
            }
        }
    }

    class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double Grade { get; set; }

        public Student(string firstName, string lastName, double grade)
        {
            FirstName = firstName;
            LastName = lastName;
            Grade = grade;
        }

        public override string ToString()
        {
            return $"{FirstName} {LastName}: {Grade:F2}";
        }
    }
}
