namespace DefiningClasses
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Person p1 = new();
            Person p2 = new(5);
            Person p3 = new("Pesho", 10);
        }
    }
}
