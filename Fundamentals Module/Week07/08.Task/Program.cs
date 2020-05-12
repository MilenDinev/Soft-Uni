using System;
using System.Collections.Generic;
using System.Linq;


namespace _08.Task
{
    class Program
    {
        static void Main(string[] args)
        {

            Dictionary<string, List<string>> companyInfo = new Dictionary<string, List<string>>();

            string input = Console.ReadLine();

            while (input != "End")
            {
                string[] companyArgs = input.Split("->");

                string companyName = companyArgs[0];
                string employeeId = companyArgs[1];

                if (!companyInfo.ContainsKey(companyName))
                {
                    companyInfo.Add(companyName, new List<string>());

                    companyInfo[companyName].Add(employeeId);
                }

                if (!companyInfo[companyName].Contains(employeeId))
                {
                    companyInfo[companyName].Add(employeeId);
                }



                input = Console.ReadLine();
            }

            companyInfo = companyInfo.OrderBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);

            foreach (var company in companyInfo)
            {
                Console.WriteLine($"{company.Key}");
                foreach (var employee in company.Value)
                {
                    Console.WriteLine($"--{employee}");
                }
            }
        }
    }
}
