namespace Person
{
    public class Child : Person
    {
        public override int Age
        {
            get => base.Age;
            protected set
            {
                if (value <= 15)
                {
                    base.Age = value;
                }
            }
        }

        public Child(string name, int age) : base(name, age)
        {
        }
    }
}
