namespace P06.GenericCountMethodDouble
{
    public class Program
    {
        static void Main(string[] args)
        {
            Box<double> box = new();

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                double input = double.Parse(Console.ReadLine());
                box.Add(input);
            }

            double elementToCompare = double.Parse(Console.ReadLine());

            Console.WriteLine(box.Count(elementToCompare));
        }
    }
}