﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ValidationAttributes
{
    public class Person
    {
        private const int minAge = 12;
        private const int maxAge = 90;

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }
        [MyRequired]
        public string Name { get; set; }
        [MyRange(minAge, maxAge)]
        public int Age { get; set; }
    }
}
