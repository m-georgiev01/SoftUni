using CollectionHierarchy.Models.Interfaces;

namespace CollectionHierarchy.Models
{
    public class MyList : GeneralCollection, IMyList
    {
        private const int AddIndex = 0;
        private const int RemoveIndex = 0;

        public int Add(string item)
        {
            _collection.Insert(AddIndex, item);

            return AddIndex;
        }

        public string Remove()
        {
            string item = _collection[RemoveIndex];

            _collection.RemoveAt(RemoveIndex);

            return item;
        }

        public int Used 
            => _collection.Count;
    }
}
