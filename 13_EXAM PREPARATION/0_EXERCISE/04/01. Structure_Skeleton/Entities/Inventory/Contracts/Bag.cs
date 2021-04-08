using System;
using System.Collections.Generic;
using System.Text;
using WarCroft.Entities.Items;
using WarCroft.Constants;
using System.Linq;

namespace WarCroft.Entities.Inventory.Contracts
{
    public abstract class Bag : IBag
    {
        private int capacity;
        private List<Item> items;
        public Bag(int capacity)
        {
            Capacity = capacity;
            items = new List<Item>();
        }
        public int Capacity
        {
            get { return capacity; }
            set
            {
                if (value > 100)
                {
                    capacity = 100;
                    return;
                }
                if (value < 0)
                {
                    capacity = 0;
                    return;
                }
                capacity = value;
            }
        }

        public int Load
        {
            get
            {
                int sum = 0;
                foreach (Item item in items)
                {
                    sum += item.Weight;
                }
                return sum;
            }
        }

        public IReadOnlyCollection<Item> Items => items.AsReadOnly();

        public void AddItem(Item item)
        {
            if (Load + item.Weight > Capacity)
            {
                throw new InvalidOperationException(ExceptionMessages.ExceedMaximumBagCapacity);
            }
            items.Add(item);
        }

        public Item GetItem(string name)
        {
            if (items.Count == 0)
            {
                throw new InvalidOperationException(ExceptionMessages.EmptyBag);
            }
            Item currItem = items.FirstOrDefault(i => i.GetType().Name == name);
            if (currItem == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.ItemNotFoundInBag, name));
            }
            items.Remove(currItem);
            return currItem;
        }
    }
}
