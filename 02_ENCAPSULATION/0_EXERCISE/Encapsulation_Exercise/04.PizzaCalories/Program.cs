using System;

namespace _04.PizzaCalories
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string[] firstLine = Console.ReadLine().Split();
                string pizzaName = firstLine[1];

                string[] secondLine = Console.ReadLine().Split();
                string flourType = secondLine[1];
                string bakingTechnique = secondLine[2];
                int doughWeight = int.Parse(secondLine[3]);

                Dough dough = new Dough(flourType, bakingTechnique, doughWeight);
                Pizza pizza = new Pizza(pizzaName, dough);

                string thirdLine = Console.ReadLine();

                while (thirdLine != "END")
                {
                    string[] arg = thirdLine.Split();
                    string toppingName = arg[1];
                    int toppingWeight = int.Parse(arg[2]);

                    Topping topping = new Topping(toppingName, toppingWeight);
                    pizza.AddToppings(topping);

                    thirdLine = Console.ReadLine();
                }
                Console.WriteLine($"{pizza.Name} - {pizza.PizzaCalories():f2} Calories.");
            }
            catch (Exception ex)
            when (ex is ArgumentException || ex is InvalidOperationException)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
