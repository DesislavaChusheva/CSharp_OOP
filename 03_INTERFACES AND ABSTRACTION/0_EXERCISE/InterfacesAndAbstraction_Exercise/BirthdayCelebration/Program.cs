using System;
using System.Collections.Generic;
using System.Linq;

namespace BirthdayCelebration
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<IBirthable> birthables = new List<IBirthable>();

            string input = Console.ReadLine();
            while (input != "End")
            {
                string[] arg = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string type = arg[0];

                if (type == "Citizen")
                {
                    string name = arg[1];
                    int age = int.Parse(arg[2]);
                    string id = arg[3];
                    string birthdate = arg[4];

                    Citizen citizen = new Citizen(name, age, id, birthdate);

                    birthables.Add(citizen);
                }
                else if (type == "Pet")
                {
                    string name = arg[1];
                    string birthdate = arg[2];

                    Pet pet = new Pet(name, birthdate);

                    birthables.Add(pet);
                }


                input = Console.ReadLine();
            }

            string year = Console.ReadLine();

            foreach (var item in birthables.Where(b => b.Birthdate.EndsWith(year)))
            {
                Console.WriteLine(item.Birthdate);
            }
        }
    }
}
