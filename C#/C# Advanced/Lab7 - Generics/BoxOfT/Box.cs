namespace BoxOfT
{
    public class Box<T>
    {
        private readonly Stack<T> _internalStack;

        public Box()
        {
            _internalStack = new();
        }

        public int Count => _internalStack.Count;

        public void Add(T element)
        {
            _internalStack.Push(element);
        }

        public T Remove()
        {
            return _internalStack.Pop();
        }

    }
}
