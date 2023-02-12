using System.Collections;
using System.Xml.Linq;

namespace P03.Stack
{
    public class CustomStack<T> : IEnumerable<T>
    {
        private List<T> items;

        public CustomStack(List<T> items)
        {
            this.items = items;
        }

        public void Push(params T[] elements)
        {
            items.AddRange(elements);
        }

        public T Pop()
        {
            var element = items.LastOrDefault();

            if (element == null)
            {
                throw new InvalidOperationException("No elements");
            }

            items.RemoveAt(items.Count - 1);
            return element;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = items.Count - 1; i >= 0; i--)
            {
                yield return items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
