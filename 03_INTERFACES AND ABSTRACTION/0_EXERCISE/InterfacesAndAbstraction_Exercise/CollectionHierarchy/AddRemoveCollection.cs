using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace CollectionHierarchy
{
    public class AddRemoveCollection : IAdding, IRemoving
    {
        public AddRemoveCollection()
        {
            Collection = new List<string>();
        }
        public List<string> Collection { get; set; }

        public int Add(string element)
        {
            Collection.Insert(0, element);
            return Collection.IndexOf(element);
        }

        public string Remove()
        {
            string removed = Collection[Collection.Count - 1];
            Collection.RemoveAt(Collection.Count - 1);
            return removed;
        }
    }
}
