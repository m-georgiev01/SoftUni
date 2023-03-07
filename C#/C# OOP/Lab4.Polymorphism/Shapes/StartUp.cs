using Shapes.Models;

namespace Shapes
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Rectangle rect = new(10, 4);
            Circle circle = new(4);

            Console.WriteLine(rect.CalculateArea());
            Console.WriteLine(circle.CalculateArea());
        }
    }
}
