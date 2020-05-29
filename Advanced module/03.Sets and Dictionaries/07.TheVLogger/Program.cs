using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.TheVLogger
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            Dictionary<string, Dictionary<string, HashSet<string>>> vloggers = new Dictionary<string, Dictionary<string, HashSet<string>>>();

            while (command != "Statistics")
            {
                string[] commandArgs = command.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
                string user = commandArgs[0];
                string action = commandArgs[1];

                if (action == "joined")
                {
                    if (!vloggers.ContainsKey(user))
                    {
                        vloggers.Add(user, new Dictionary<string, HashSet<string>>());
                        vloggers[user].Add("followed", new HashSet<string>());
                        vloggers[user].Add("followers", new HashSet<string>());
                    }

                }

                else if (action == "followed" && user != commandArgs[2] && vloggers.ContainsKey(user) && vloggers.ContainsKey(commandArgs[2]))
                {
                    string mainUser = commandArgs[2];

                    vloggers[user]["followed"].Add(mainUser);
                    vloggers[mainUser]["followers"].Add(user);


                }

                command = Console.ReadLine();
            }


            Console.WriteLine($"The V-Logger has a total of {vloggers.Count} vloggers in its logs.");

            var sortedVloggers = vloggers
                .OrderByDescending(x => x.Value["followers"].Count)
                .ThenBy(x => x.Value["followed"].Count)
                .ToDictionary(x => x.Key, v => v.Value);

            int counter = 1;
            foreach (var (vlogger, collectionOfPeople) in sortedVloggers)
            {
                Console.WriteLine($"{counter}. {vlogger} : {collectionOfPeople["followers"].Count} followers, {collectionOfPeople["followed"].Count} following");
                if (counter == 1)
                {
                    foreach (var username in collectionOfPeople["followers"].OrderBy(x => x))
                    {
                        Console.WriteLine($"*  {username}");
                    }
                }

                counter++;
            }

        }
    }
}
