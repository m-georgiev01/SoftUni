namespace P05.GenericCountMethodString
{
    public class Box<T> where T : IComparable
    {
        private List<T> items;

        public Box()
        {
            this.items = new();
        }

        public void Add (T element)
        {
            items.Add(element);
        }

        public int Count(T itemToCompare)
        {
            int count = 0;
            foreach (T item in items)
            {
                if (item.CompareTo(itemToCompare) > 0)
                {
                    count++;
                }
            }

            return count;
        }
    }
}
