using System;
using System.Collections.Generic;
using System.Linq;

namespace FoodShortage
{
    class Program
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, IBuyer> buyers = new Dictionary<string, IBuyer>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string name = input[0];
                int age = int.Parse(input[1]);

                if (input.Length == 4)
                {
                    string id = input[2];
                    string birthdate = input[3];

                    Citizen citizen = new Citizen(name, age, id, birthdate);
                    buyers.Add(name, citizen);
                }
                else
                {
                    string group = input[2];

                    Rebel rebel = new Rebel(name, age, group);
                    buyers.Add(name, rebel);
                }
            }

            string nextInput = Console.ReadLine();

            while (nextInput != "End")
            {
                if (buyers.Any(b => b.Key == nextInput))
                {
                    buyers[nextInput].BuyFood();
                }

                nextInput = Console.ReadLine();
            }
            Console.WriteLine(buyers.Values.Sum(b => b.Food));
        }
    }
}
