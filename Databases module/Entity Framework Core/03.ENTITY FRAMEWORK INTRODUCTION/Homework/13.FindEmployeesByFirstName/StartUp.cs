namespace SoftUni
{
    using Microsoft.EntityFrameworkCore;
    using SoftUni.Data;
    using SoftUni.Models;
    using System.Globalization;
    using System.Linq;
    using System.Text;

    public class StartUp
    {
        static void Main(string[] args)
        {
            var db = new SoftUniContext();

            System.Console.WriteLine(GetEmployeesByFirstNameStartingWithSa(db));
        }

        public static string GetEmployeesByFirstNameStartingWithSa(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();
            string[] deparments = { "Engineering", "Tool Design", "Marketing", "Information Services" };

            var employees = context.Employees
                .Select(x => new 
                {
                    x.FirstName,
                    x.LastName,
                    x.JobTitle,
                    x.Salary
                })
                .Where(x => x.FirstName.StartsWith("Sa"))
                .OrderBy(x => x.FirstName)
                .ThenBy(x => x.LastName)
                .ToList();


            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle} - (${employee.Salary:f2})");

            }

            return sb.ToString().Trim();
        }
    }
}
