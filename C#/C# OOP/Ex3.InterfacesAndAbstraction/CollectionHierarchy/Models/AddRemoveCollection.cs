using CollectionHierarchy.Models.Interfaces;

namespace CollectionHierarchy.Models
{
    public class AddRemoveCollection : GeneralCollection, IAddRemoveCollection
    {
        private const int AddIndex = 0;

        public int Add(string item)
        {
            _collection.Insert(0, item);

            return AddIndex;
        }

        public string Remove()
        {
            string item = null;

            if (_collection.Count > 0)
            {
                item = _collection[_collection.Count - 1];

                _collection.RemoveAt(_collection.Count - 1);
            }

            return item;
        }
    }
}
