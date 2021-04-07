using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionHierarchy
{
    public interface IRemoving
    {
        public List<string> Collection { get; }
        string Remove();
    }
}
