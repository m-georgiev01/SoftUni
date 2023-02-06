namespace DefiningClasses
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<Person> peopleOver30 = new();

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (int.Parse(tokens[1]) > 30)
                {
                    peopleOver30.Add(new Person(tokens[0], int.Parse(tokens[1])));
                }
            }

            peopleOver30
                .OrderBy(p => p.Name)
                .ToList()
                .ForEach(p => Console.WriteLine($"{p.Name} - {p.Age}"));
        }
    }
}
