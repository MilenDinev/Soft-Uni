namespace _05.BorderControl
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            string command = Console.ReadLine();
            List<IIdentifiable> allCitizens = new List<IIdentifiable>();

            while (command != "End")
            {
                string[] commandArgs = command.Split().ToArray();

                if (commandArgs.Length == 3)
                {
                    string name = commandArgs[0];
                    int age = int.Parse(commandArgs[1]);
                    string humanId = commandArgs[2];
                    Human human = new Human(name, age, humanId);
                    allCitizens.Add(human);
                }
                else if (commandArgs.Length == 2)
                {
                    string model = commandArgs[0];
                    string robotId = commandArgs[1];

                    Robot robot = new Robot(model,robotId);
                    allCitizens.Add(robot);
                }
                else
                {
                    return;
                }

                command = Console.ReadLine();
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
