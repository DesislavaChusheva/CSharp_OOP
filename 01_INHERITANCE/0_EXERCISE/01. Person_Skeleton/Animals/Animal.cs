using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    public abstract class Animal
    {
        public Animal(string name, int age, string gender)
        {
            Name = name;
            Age = age;
            Gender = gender;
        }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }

        abstract public string ProduceSound();
        public override string ToString()
        {
            return this.GetType().Name + Environment.NewLine + $"{Name} {Age} {Gender}";
        }
    }
}
