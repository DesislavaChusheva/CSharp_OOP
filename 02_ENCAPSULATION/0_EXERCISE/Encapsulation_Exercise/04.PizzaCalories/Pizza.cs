using System;
using System.Collections.Generic;
using System.Text;

namespace _04.PizzaCalories
{
    public class Pizza
    {
        private string name;
        private Dough doughI;
        private List<Topping> toppingsI;

        public Pizza(string name, Dough doughI)
        {
            Name = name;
            DoughI = doughI;
            toppingsI = new List<Topping>();
        }

        public string Name
        {
            get => name;
            private set
            {
                if (value.Length == 0 || value.Length > 15)
                {
                    throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
                }
                name = value;
            }
        }
        public Dough DoughI
        {
            get => doughI;
            private set { doughI = value; }
        }
        public List<Topping> ToppingsI
        {
            get => toppingsI;
            private set { }
        }

        public void AddToppings(Topping topping)
        {
            if (toppingsI.Count == 10)
            {
                throw new InvalidOperationException("Number of toppings should be in range [0..10].");
            }
            toppingsI.Add(topping);
        }
        public double PizzaCalories()
        {
            double toppingscalories = 0;

            if (toppingsI.Count > 0)
            {
                foreach (Topping topping in toppingsI)
                {
                    toppingscalories += topping.ToppingCalories();
                }
            }
            double doughCalories = doughI.DoughCalories();

            return doughCalories + toppingscalories;
        }
    }
}
