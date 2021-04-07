using System;
using System.Collections.Generic;
using System.Linq;

namespace BorderControl
{
    class Program
    {
        public static void Main(string[] args)
        {
            List<IIdentifiable> visitors = new List<IIdentifiable>();
            string command = Console.ReadLine();

            while (command != "End")
            {
                string[] visitorInfo = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                if (visitorInfo.Length == 3)
                {
                    string name = visitorInfo[0];
                    int age = int.Parse(visitorInfo[1]);
                    string id = visitorInfo[2];

                    Citizen citizen = new Citizen(name, age, id);
                    visitors.Add(citizen);
                }
                else
                {
                    string model = visitorInfo[0];
                    string id = visitorInfo[1];

                    Robot robot = new Robot(model, id);
                    visitors.Add(robot);
                }

                command = Console.ReadLine();
            }
            string fakeEnd = Console.ReadLine();

            foreach (var item in visitors.Where(v => v.Id.EndsWith(fakeEnd)))
            {
                Console.WriteLine(item.Id);
            }
        }
    }
}
