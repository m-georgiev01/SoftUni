 using System;
using System.Text;

namespace Person
{
    public class Person
    {
        private int _age;

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public string Name { get; set; }

        public virtual int Age
        {
            get => _age;
            protected set
            {
                if (value >= 0)
                {
                    _age = value;
                }
            }
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(String.Format("Name: {0}, Age: {1}",
                this.Name,
                this.Age));

            return stringBuilder.ToString();
        }
    }
}
