using System;

namespace Animals
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            while (true)
            {
                string type = Console.ReadLine();
                if (type == "Beast!")
                {
                    break;
                }

                string[] data = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries );
                string name = data[0];
                int age = int.Parse(data[1]);
                string gender = data[2];

                if (string.IsNullOrEmpty(name) || age < 0 || string.IsNullOrEmpty(gender))
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }

                if (type == "Dog")
                {
                    Dog dog = new Dog(name, age, gender);
                    Console.WriteLine(dog);
                    Console.WriteLine(dog.ProduceSound());
                }
                else if (type == "Cat")
                {
                    Cat cat = new Cat(name, age, gender);
                    Console.WriteLine(cat);
                    Console.WriteLine(cat.ProduceSound());
                }
                else if (type == "Frog")
                {
                    Frog frog = new Frog(name, age, gender);
                    Console.WriteLine(frog);
                    Console.WriteLine(frog.ProduceSound());
                }
                else if (type == "Kitten")
                {
                    Kitten kitten = new Kitten(name, age);
                    Console.WriteLine(kitten);
                    Console.WriteLine(kitten.ProduceSound());
                }
                else if (type == "Tomcat")
                {
                    Tomcat tomcat = new Tomcat(name, age);
                    Console.WriteLine(tomcat);
                    Console.WriteLine(tomcat.ProduceSound());
                }
            }
        }
    }
}
