namespace GenericScale
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            EqualityScale<int> eq = new(5, 5);
            Console.WriteLine(eq.AreEqual());
        }
    }
}
