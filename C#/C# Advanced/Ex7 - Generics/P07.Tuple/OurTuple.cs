namespace P07.Tuple
{
    public class OurTuple<T, TU>
    {
        public OurTuple(T item1, TU item2)
        {
            Item1 = item1;
            Item2 = item2;
        }

        public T Item1 { get; set; }
        public TU Item2 { get; set; }

        public override string ToString()
        {
            return $"{Item1} -> {Item2}";
        }
    }
}
