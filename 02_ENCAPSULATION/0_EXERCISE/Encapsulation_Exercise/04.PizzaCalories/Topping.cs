using System;
using System.Collections.Generic;
using System.Text;

namespace _04.PizzaCalories
{
    public class Topping
    {
        private double meatMod = 1.2;
        private double veggiesMod = 0.8;
        private double cheeseMod = 1.1;
        private double sauceMod = 0.9;

        private HashSet<string> validToppings = new HashSet<string> { "meat", "veggies", "cheese", "sauce" };
        private double toppingMod;

        private string name;
        private int weight;

        public Topping(string name, int weight)
        {
            Name = name;
            Weight = weight;
        }
        public string Name
        {
            get => name;
            private set
            {
                string valueToLower = value.ToLower();
                if (!validToppings.Contains(valueToLower))
                {
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");
                }
                name = value;
                switch (valueToLower)
                {
                    case "meat":
                        toppingMod = meatMod;
                        break;
                    case "veggies":
                        toppingMod = veggiesMod;
                        break;
                    case "cheese":
                        toppingMod = cheeseMod;
                        break;
                    case "sauce":
                        toppingMod = sauceMod;
                        break;
                    default:
                        break;
                }
            }
        }
        public int Weight
        {
            get => weight;
            private set
            {
                if (value < 1 || value > 50)
                {
                    throw new ArgumentException($"{name} weight should be in the range [1..50].");
                }
                weight = value;
            }
        }
        public double ToppingCalories()
        {
            return 2 * weight * toppingMod;
        }
    }
}
