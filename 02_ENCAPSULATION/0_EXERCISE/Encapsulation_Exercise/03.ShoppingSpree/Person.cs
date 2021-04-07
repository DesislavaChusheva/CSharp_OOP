using System;
using System.Collections.Generic;
using System.Text;

namespace _03.ShoppingSpree
{
    public class Person
    {
        private string name;
        private int money;
        private List<Product> bagOfProducts;

        public Person(string name, int money)
        {
            Name = name;
            Money = money;
            bagOfProducts = new List<Product>();
        }
        public string Name
        {
            get => name;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be empty");
                }
                name = value;
            }
        }
        public int Money
        {
            get => money;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }
                money = value;
            }
        }

        public List<Product> BagOfProducts { get => bagOfProducts; }

        public void AddProductInBag (Product product)
        {
            if (product.Cost > money)
            {
                Console.WriteLine($"{Name} can't afford {product.Name}");
                return;
            }
            bagOfProducts.Add(product);
            money -= product.Cost;
            Console.WriteLine($"{Name} bought {product.Name}");
        }
    }
}
