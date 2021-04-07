using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.ShoppingSpree
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] people = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);
            string[] products = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);

            Dictionary<string, Person> thePeople = new Dictionary<string, Person>();
            Dictionary<string, Product> theProducts = new Dictionary<string, Product>();

            try
            {
                for (int i = 0; i < people.Length; i++)
                {
                    string[] arg = people[i].Split('=', StringSplitOptions.RemoveEmptyEntries);
                    string name = arg[0];
                    int money = int.Parse(arg[1]);
                    Person currPerson = new Person(name, money);

                    thePeople.Add(name, currPerson);
                }
                for (int i = 0; i < products.Length; i++)
                {
                    string[] arg = products[i].Split('=', StringSplitOptions.RemoveEmptyEntries);
                    string name = arg[0];
                    int cost = int.Parse(arg[1]);
                    Product currProduct = new Product(name, cost);

                    theProducts.Add(name, currProduct);
                }

            string command = Console.ReadLine();

            while (command != "END")
            {
                string[] arg = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string person = arg[0];
                string product = arg[1];

                thePeople[person].AddProductInBag(theProducts[product]);
                command = Console.ReadLine();
            }

            foreach (var kvp in thePeople)
            {
                if (kvp.Value.BagOfProducts.Count == 0)
                {
                    Console.WriteLine($"{kvp.Value.Name} - Nothing bought");
                    continue;
                }
                List<string> productsOffCurrPerson = new List<string>();
                foreach (var item in kvp.Value.BagOfProducts)
                {
                    productsOffCurrPerson.Add(item.Name);
                }

                Console.WriteLine($"{kvp.Value.Name} - {string.Join(", ", productsOffCurrPerson)}");
            }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}
