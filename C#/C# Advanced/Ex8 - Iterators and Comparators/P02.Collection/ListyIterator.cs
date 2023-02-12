using System.Collections;

namespace P02.Collection
{
    public class ListyIterator<T> : IEnumerable<T>
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

        public void PrintAll()
        {
            Console.WriteLine(string.Join(" ", list));
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < list.Count; i++)
            {
                yield return list[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
