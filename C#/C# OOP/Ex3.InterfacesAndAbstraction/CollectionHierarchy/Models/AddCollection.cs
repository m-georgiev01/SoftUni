using CollectionHierarchy.Models.Interfaces;

namespace CollectionHierarchy.Models
{
    public class AddCollection : GeneralCollection, IAddCollection
    {
        public int Add(string item)
        {
            _collection.Add(item);

            return _collection.Count - 1;
        }
    }
}
