//05.	SoftUni Parking


using System;
using System.Collections.Generic;


namespace _04.Task
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            

            Dictionary<string, string> registrations = new Dictionary<string, string>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();

                string status = input[0];
                string user = input[1];

                if (status == "register")
                {
                    
                    
                    string licensePlate = input[2];

                    if (!registrations.ContainsKey(user))
                    {
                        registrations.Add(user, licensePlate);
                        Console.WriteLine($"{user} registered {licensePlate} successfully");
                    }
                    else
                    {
                        Console.WriteLine($"ERROR: already registered with plate number {licensePlate}");
                    }

                }

                else if (status == "unregister")
                {
                    if (registrations.ContainsKey(user))
                    {
                        registrations.Remove(user);
                        Console.WriteLine($"{user} unregistered successfully");
                    }
                    else
                    {
                        Console.WriteLine($"ERROR: user { user} not found");
                    }
                }

            }

            foreach (var user in registrations)
            {
                Console.WriteLine($"{user.Key} => {user.Value}");
            }
        }
    }
}
