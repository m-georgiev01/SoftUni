using CollectionHierarchy.Models.Interfaces;

namespace CollectionHierarchy.Models
{
    public abstract class GeneralCollection
    {
        protected List<string> _collection;

        protected GeneralCollection()
        {
            _collection = new();
        }
    }
}
