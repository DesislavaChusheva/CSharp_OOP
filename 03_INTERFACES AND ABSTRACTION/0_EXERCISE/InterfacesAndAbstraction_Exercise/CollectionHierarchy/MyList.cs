using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionHierarchy
{
    public class MyList : IAdding, IRemoving, IUsing
    {
        public MyList()
        {
            Collection = new List<string>();
        }
        public List<string> Collection { get; set; }
        public int Used { get => Collection.Count; }

        public int Add(string element)
        {
            Collection.Insert(0, element);
            return Collection.IndexOf(element);
        }

        public string Remove()
        {
            string removed = Collection[0];
            Collection.RemoveAt(0);
            return removed;
        }

    }
}
