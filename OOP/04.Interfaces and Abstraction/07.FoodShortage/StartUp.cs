namespace _07.FoodShortage
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
       public static void Main()
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
                    Human human = new Human(name, age, id, birthday);
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

            while (command != "End")
            {
                string currentName = command;
                var buyer = buyers.Where(x => x.Name == currentName).FirstOrDefault();

                if (buyer != null)
                {
                    buyer.BuyFood();
                }

                command = Console.ReadLine();
            }

            int food = buyers.Where(x => x.Food > 0).Sum(x => x.Food);
            Console.WriteLine(food);
        }
    }
    
}
