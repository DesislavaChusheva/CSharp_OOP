using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionHierarchy
{
    public interface IAdding
    {
        public List<string> Collection { get; }
        int Add(string element);
    }
}
