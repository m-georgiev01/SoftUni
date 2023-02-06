namespace Date_Modifier
{
    public class DateModifier
    {
        public int GetDaysDiffBetweenTwoDates(string dateOne, string dateTwo)
        {
            DateTime d1 = DateTime.Parse(dateOne);
            DateTime d2 = DateTime.Parse(dateTwo);

            return Math.Abs((d1.Subtract(d2)).Days);
        }
    }
}
