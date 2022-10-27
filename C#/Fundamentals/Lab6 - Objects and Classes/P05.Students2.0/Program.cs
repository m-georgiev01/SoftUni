using System;
using System.Collections.Generic;
using System.Linq;

namespace P05.Students2._0
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>();

            string command;
            while ((command = Console.ReadLine()) != "end")
            {
                string[] cmdArgs = command.Split();
                string fName = cmdArgs[0];
                string lName = cmdArgs[1];
                int age = int.Parse(cmdArgs[2]);
                string homeTown = cmdArgs[3];

                var student = students.FirstOrDefault(m => m.FirstName == fName && m.LastName == lName);
                if (student != null)
                {
                    student.Age = age;
                    student.HomeTown = homeTown;
                }
                else
                {
                    student = new Student(fName, lName, age, homeTown);
                    students.Add(student);
                }          
            }
            string filter = Console.ReadLine();

            students = students.Where(x => x.HomeTown == filter).ToList();

            Console.WriteLine(string.Join(Environment.NewLine, students));
        }
    }

    class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string HomeTown { get; set; }

        public Student(string firstName, string lastName, int age, string homeTown)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            HomeTown = homeTown;
        }

        public override string ToString()
        {
            return $"{FirstName} {LastName} is {Age} years old.";
        }
    }
}
