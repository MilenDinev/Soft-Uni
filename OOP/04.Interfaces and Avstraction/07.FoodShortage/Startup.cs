using System;
using System.Collections.Generic;

namespace _07.FoodShortage
{
    public class Startup
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<IBuyer> buyers = new List<IBuyer>();

            for (int i = 0; i < n; i++)
            {
                string[] inputArgs = Console.ReadLine().Split();

                if (inputArgs.Length == 4)
                {
                    string name = inputArgs[0];
                    int age = int.Parse(inputArgs[1]);
                    string id = inputArgs[2];
                    string birthday = inputArgs[3];
                    Citizen human = new Citizen(name, age, id, birthday);

                    buyers.Add(human);
                }

                else if (inputArgs.Length == 3)
                {
                    string name = inputArgs[0];
                    int age = int.Parse(inputArgs[1]);
                    string group = inputArgs[2];

                    Rebel rebel = new Rebel(name, age, group);

                    buyers.Add(rebel);
                }
            }

            string command = Console.ReadLine();

            while (command !="End")
            {
                string currentName = command;

                foreach (var buyer in buyers)
                {
                    if (currentName == buyer.Name)
                    {
                        buyer.BuyFood();
                    }
                }

                command = Console.ReadLine();
            }

            int food = 0;

            foreach (var buyer in buyers)
            {
                food += buyer.Food;
            }

            Console.WriteLine(food);
        }
    }
}
