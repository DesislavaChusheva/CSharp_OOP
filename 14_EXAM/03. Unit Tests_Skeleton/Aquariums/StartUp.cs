namespace Aquariums
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            string name = "myAquarium";
            int capacity = 20;
            Aquarium aquarium = new Aquarium(name, capacity);
            for (int i = 1; i <= 20; i++)
            {
                aquarium.Add(new Fish($"{i}"));
            }
            Console.WriteLine(aquarium.Report());
        }
    }
}
