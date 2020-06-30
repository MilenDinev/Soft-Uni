namespace _04.Hospital
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            Dictionary<string, List<string>> doctors = new Dictionary<string, List<string>>();
            Dictionary<string, List<List<string>>> departments = new Dictionary<string, List<List<string>>>();


            string command = Console.ReadLine();
            while (command != "Output")
            {
                string[] inputArgs = command.Split();
                string departament = inputArgs[0];
                string doctorsFirstName = inputArgs[1];
                string doctorsSecondName = inputArgs[2];
                string pacient = inputArgs[3];
                string doctorSFullName = doctorsFirstName + doctorsSecondName;

                if (!doctors.ContainsKey(doctorsFirstName + doctorsSecondName))
                {
                    doctors[doctorSFullName] = new List<string>();
                }

                if (!departments.ContainsKey(departament))
                {
                    departments[departament] = new List<List<string>>();
                    for (int rooms = 0; rooms < 20; rooms++)
                    {
                        departments[departament].Add(new List<string>());
                    }
                }

                bool isFull = departments[departament].SelectMany(x => x).Count() < 60;
                if (isFull)
                {
                    int room = 0;
                    doctors[doctorSFullName].Add(pacient);
                    for (int counter = 0; counter < departments[departament].Count; counter++)
                    {
                        if (departments[departament][counter].Count < 3)
                        {
                            room = counter;
                            break;
                        }

                    }

                    departments[departament][room].Add(pacient);
                }

                command = Console.ReadLine();
            }

            command = Console.ReadLine();

            while (command != "End")
            {
                string[] args = command.Split();

                if (args.Length == 1)
                {
                    Console.WriteLine(string.Join("\n", departments[args[0]].Where(x => x.Count > 0).SelectMany(x => x)));
                }
                else if (args.Length == 2 && int.TryParse(args[1], out int staq))
                {
                    Console.WriteLine(string.Join("\n", departments[args[0]][staq - 1].OrderBy(x => x)));
                }
                else
                {
                    Console.WriteLine(string.Join("\n", doctors[args[0] + args[1]].OrderBy(x => x)));
                }

                command = Console.ReadLine(); 
            }
        }
    }
}
