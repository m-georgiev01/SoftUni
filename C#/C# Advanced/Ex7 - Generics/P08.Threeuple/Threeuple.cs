namespace P08.Threeuple
{
    public class Threeuple<T, TU, TV>
    {
        public Threeuple(T item1, TU item2, TV item3)
        {
            Item1 = item1;
            Item2 = item2;
            Item3 = item3;
        }

        public T Item1 { get; set; }
        public TU Item2 { get; set; }
        public TV Item3 { get; set; }

        public override string ToString()
        {
            return $"{Item1} -> {Item2} -> {Item3}";
        }
    }
}
