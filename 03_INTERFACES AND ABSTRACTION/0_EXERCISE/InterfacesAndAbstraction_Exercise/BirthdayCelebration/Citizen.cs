using System;
using System.Collections.Generic;
using System.Text;

namespace BirthdayCelebration
{
    public class Citizen : IIdentifiable, IBirthable
    {
        public Citizen(string name, int age, string id, string birthdate)
        {
            Name = name;
            Age = age;
            Id = id;
            Birthdate = birthdate;
        }
        public string Name { get; private set; }
        public int Age { get; set; }
        public string Id { get; private set; }
        public string Birthdate { get; private set; }
    }
}
