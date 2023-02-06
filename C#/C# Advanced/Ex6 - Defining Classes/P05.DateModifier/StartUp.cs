namespace Date_Modifier
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            DateModifier dm = new();

            string dateOne = Console.ReadLine();
            string dateTwo = Console.ReadLine();

            Console.WriteLine(dm.GetDaysDiffBetweenTwoDates(dateOne, dateTwo));
        }
    }
}
