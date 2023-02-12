using System.Collections;

namespace P04.Froggy
{
    public class Lake : IEnumerable<int>
    {
        private readonly int[] stones;

        public Lake(int[] stones)
        {
            this.stones = stones;
        }

        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 0; i < stones.Length; i += 2)
            {
                yield return stones[i];
            }

            int startReverseIdx = stones.Length % 2 == 0 ? stones.Length - 1 : stones.Length - 2;

            for (int j = startReverseIdx; j >= 0; j -= 2)
            {
                yield return stones[j];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
