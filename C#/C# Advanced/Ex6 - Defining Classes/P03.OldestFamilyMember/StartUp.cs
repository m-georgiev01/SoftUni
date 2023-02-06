namespace DefiningClasses
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Family fm = new();

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                Person p = new(tokens[0], int.Parse(tokens[1]));
                fm.AddMember(p);
            }

            Person oldestMember = fm.GetOldestMember();
            Console.WriteLine($"{oldestMember.Name} {oldestMember.Age}");
        }
    }
}
