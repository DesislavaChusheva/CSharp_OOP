using System;
using System.Collections.Generic;

namespace ExplicitInterfaces
{
    public class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            while (input != "End")
            {
                string[] data = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string name = data[0];
                string country = data[1];
                int age = int.Parse(data[2]);

                IPerson person = new Citizen(name, age);
                IResident resident = new Citizen(name, country);

                Console.WriteLine(person.GetName());
                Console.WriteLine(resident.GetName());

                input = Console.ReadLine();
            }
        }
    }
}
