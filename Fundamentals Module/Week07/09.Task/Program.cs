using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;


namespace _09.Task
{
    class Program
    {
        static void Main(string[] args)
        {

            Dictionary<string, List<string>> forces = new Dictionary<string, List<string>>();

            string input = Console.ReadLine();
            string user = "";
            string forceSide = "";
            string changedForceSide = " ";

            while (input != "Lumpawaroo")
            {


                if (input.Contains(" | "))
                {
                    
                    string[] forcesArgs = input.Split(" | ");

                    user = forcesArgs[0];
                    forceSide = forcesArgs[1];                    

                    if (!forces.ContainsKey(forceSide))
                    {
                        forces.Add(forceSide, new List<string>());

                        forces[forceSide].Add(user);
                    }

                    if (!forces[forceSide].Contains(user))
                    {
                        forces[forceSide].Add(user);
                    }
                }


               else if (input.Contains(" -> "))
                {
                    string[] forcesArgs = input.Split(" -> ");

                    user = forcesArgs[0];
                    changedForceSide= forcesArgs[1];

                    if (forces[forceSide].Contains(user) && !forces[changedForceSide].Contains(user))
                    {
                        forces[changedForceSide].Add(user);
                        forces[forceSide].Remove(user);
                    }
                    else if (!forces[forceSide].Contains(user) && !forces[changedForceSide].Contains(user))
                    {
                        forces[changedForceSide].Add(user);
                    }

                }

                input = Console.ReadLine();
            }
        }
    }
}
