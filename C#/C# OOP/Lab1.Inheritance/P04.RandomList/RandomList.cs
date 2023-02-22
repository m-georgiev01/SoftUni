namespace CustomRandomList
{
    public class RandomList : List<string>
    {
        private readonly Random _random;

        public RandomList()
        {
            _random = new();
        }

        public string RandomString()
        {
            string randomString = _random.Next(0, this.Count).ToString();
            this.Remove(randomString);
            return randomString;
        }
    }
}
