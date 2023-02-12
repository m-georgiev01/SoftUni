namespace P01.ListyIterator
{
    public class ListyIterator<T>
    {
        private readonly List<T> list;
        private int currentIndex;

        public ListyIterator(params T[] elements)
        {
            this.list = elements.ToList();
        }

        public bool Move()
        {
            if (!HasNext())
            {
                return false;
            }

            currentIndex++;
            return true;
        }

        public bool HasNext()
        {
            int nextIndex = currentIndex + 1;

            return nextIndex < list.Count;
        }

        public void Print()
        {
            if (list.Count == 0)
            {
                throw new InvalidOperationException("Invalid Operation!");
            }

            Console.WriteLine(list[currentIndex]);
        }
    }
}
