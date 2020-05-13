using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Hospital
{
    public class Startup
    {
        public static void Main()
        {
            string[] command = Console.ReadLine().Split();
            string departmentName = command[0];
            Patient patient = new Patient(command[1]);
            Patient patient1 = new Patient(command[2]);
            Patient patient2 = new Patient(command[3]);

            Department department = new Department(departmentName);

            department.AddPatient(patient);
            department.AddPatient(patient1);
            department.AddPatient(patient2);

            Console.WriteLine(department.ToString());
        }
    }
}







//Dictionary<string, List<string>> doktori = new Dictionary<string, List<string>>();
//Dictionary<string, List<List<string>>> departments = new Dictionary<string, List<List<string>>>();


//string command = Console.ReadLine();
//while (command != "Output")
//{
//    string[] jetoni = command.Split();
//    var departament = jetoni[0];
//    var purvoIme = jetoni[1];
//    var vtoroIme = jetoni[2];
//    var pacient = jetoni[3];
//    var cqloIme = purvoIme + vtoroIme;

//    if (!doktori.ContainsKey(purvoIme + vtoroIme))
//    {
//        doktori[cqloIme] = new List<string>();
//    }
//    if (!departments.ContainsKey(departament))
//    {
//        departments[departament] = new List<List<string>>();
//        for (int stai = 0; stai < 20; stai++)
//        {
//            departments[departament].Add(new List<string>());
//        }
//    }

//    bool imaMqsto = departments[departament].SelectMany(x => x).Count() < 60;
//    if (imaMqsto)
//    {
//        int staq = 0;
//        doktori[cqloIme].Add(pacient);
//        for (int st = 0; st < departments[departament].Count; st++)
//        {
//            if (departments[departament][st].Count < 3)
//            {
//                staq = st;
//                break;
//            }
//        }
//        departments[departament][staq].Add(pacient);
//    }

//    command = Console.ReadLine();
//}

//command = Console.ReadLine();

//while (command != "End")
//{
//    string[] args = command.Split();

//    if (args.Length == 1)
//    {
//        Console.WriteLine(string.Join("\n", departments[args[0]].Where(x => x.Count > 0).SelectMany(x => x)));
//    }
//    else if (args.Length == 2 && int.TryParse(args[1], out int staq))
//    {
//        Console.WriteLine(string.Join("\n", departments[args[0]][staq - 1].OrderBy(x => x)));
//    }
//    else
//    {
//        Console.WriteLine(string.Join("\n", doktori[args[0] + args[1]].OrderBy(x => x)));
//    }
//    command = Console.ReadLine();
//}