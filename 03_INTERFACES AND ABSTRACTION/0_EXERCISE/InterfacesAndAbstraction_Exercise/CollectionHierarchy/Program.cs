using System;
using System.Collections.Generic;

namespace CollectionHierarchy
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] firstLine = Console.ReadLine().Split();
            int n = int.Parse(Console.ReadLine());

            AddCollection addCollection = new AddCollection();
            AddRemoveCollection addRemoveCollection = new AddRemoveCollection();
            MyList myList = new MyList();
            Dictionary<IAdding, List<int>> addIndexes = new Dictionary<IAdding, List<int>>();
            addIndexes.Add(addCollection, new List<int>());
            addIndexes.Add(addRemoveCollection, new List<int>());
            addIndexes.Add(myList, new List<int>());
            Dictionary<IRemoving, List<string>> removedStrings = new Dictionary<IRemoving, List<string>>();
            removedStrings.Add(addRemoveCollection, new List<string>());
            removedStrings.Add(myList, new List<string>());

            for (int i = 0; i < firstLine.Length; i++)
            {
                addIndexes[addCollection].Add(addCollection.Add(firstLine[i]));
                addIndexes[addRemoveCollection].Add(addRemoveCollection.Add(firstLine[i]));
                addIndexes[myList].Add(myList.Add(firstLine[i]));
            }
            for (int i = 0; i < n; i++)
            {
                removedStrings[addRemoveCollection].Add(addRemoveCollection.Remove());
                removedStrings[myList].Add(myList.Remove());
            }
            foreach (var kvp in addIndexes)
            {
                Console.WriteLine(string.Join(" ", kvp.Value));
            }
            foreach (var kvp in removedStrings)
            {
                Console.WriteLine(string.Join(" ", kvp.Value));
            }
        }
    }
}
