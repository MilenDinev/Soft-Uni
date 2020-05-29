using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace _08.Ranking
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();

            Dictionary<string, string> contests = new Dictionary<string, string>();

            while (command != "end of contests")
            {
                string[] commandArgs = command.Split(':').ToArray();
                string contest = commandArgs[0];
                string password = commandArgs[1];

                if (!contests.ContainsKey(contest))
                {
                    contests.Add(contest, password);
                }


                command = Console.ReadLine();
            }


            Dictionary<string, Dictionary<string, int>> submissions = new Dictionary<string, Dictionary<string, int>>();

            command = Console.ReadLine();

            while (command != "end of submissions")
            {
                string[] commandArgs = command.Split("=>").ToArray();
                string contest = commandArgs[0];
                string password = commandArgs[1];
                string user = commandArgs[2];
                int points = int.Parse(commandArgs[3]);


                if ((submissions.ContainsKey(user) && submissions[user].ContainsKey(contest)) && submissions[user][contest] < points)
                {

                    submissions[user][contest] = points;

                }

                if (!submissions.ContainsKey(user) && contests[contest] == password)
                {
                    submissions.Add(user, new Dictionary<string, int>());
                    submissions[user].Add(contest, points);
                }

                else if (submissions.ContainsKey(user) && !submissions[user].ContainsKey(contest) && contests[contest] == password)
                {
                    submissions[user].Add(contest, points);
                }

                command = Console.ReadLine();
            }





            int maxSum = int.MinValue;
            string bestUser = string.Empty;
            foreach (var user in submissions)
            {
                int usersTootalPoints = user.Value.Values.Sum();
                if (maxSum < usersTootalPoints)
                {
                    maxSum = usersTootalPoints;
                    bestUser = user.Key;
                }

            }

            Console.WriteLine($"Best candidate is {bestUser} with total {maxSum} points.");

            Console.WriteLine("Ranking:");

            foreach (var user in submissions.OrderBy(x => x.Key))
            {
                Console.WriteLine(user.Key);

                foreach (var contest in user.Value.OrderBy(x => x.Key))
                {
                    Console.WriteLine($"#  {contest.Key} -> {contest.Value}");
                }
            }

        }
    }
}
