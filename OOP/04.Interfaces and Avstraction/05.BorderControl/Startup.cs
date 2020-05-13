using System;
using System.Collections.Generic;

namespace _05.BorderControl
{
    public class Startup
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            List<IIdentifiable> allCitizens = new List<IIdentifiable>();


            while (input != "End")
            {
                string[] inputArgs = input.Split();

                if (inputArgs.Length == 3)
                {
                    string name = inputArgs[0];
                    int age = int.Parse(inputArgs[1]);
                    string id = inputArgs[2];

                    Human human = new Human(name, age, id);

                    allCitizens.Add(human);
                }

                else if (inputArgs.Length == 2)
                {
                    string name = inputArgs[0];
                    string id = inputArgs[1];

                    Robot robot = new Robot(name, id);

                    allCitizens.Add(robot);
                }

                input = Console.ReadLine();
            }
            string fakeId = Console.ReadLine();

            List<string> fakeIds = new List<string>();

            foreach (var citizen in allCitizens)
            {
                string lastSymbols = citizen.Id.Substring(citizen.Id.Length - fakeId.Length, fakeId.Length);

                if (lastSymbols == fakeId)
                {
                    fakeIds.Add(citizen.Id);
                }
            }

            
            foreach (var id in fakeIds)
            {
                Console.WriteLine(id.Trim());
            }
        }
    }
}
