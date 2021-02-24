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

            System.Console.WriteLine(IncreaseSalaries(db));
        }

        public static string IncreaseSalaries(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();
            string[] deparments = { "Engineering", "Tool Design", "Marketing", "Information Services" };

            var employees = context.Employees
                .Include(x => x.Department)
                .Where(x => deparments.Contains(x.Department.Name))
                .ToList();

            foreach (var employee in employees)
            {
                employee.Salary *= 1.12m;
            }

            context.SaveChanges();

            foreach (var employee in employees.OrderBy(e => e.FirstName).ThenBy(e => e.LastName))
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} (${employee.Salary:f2})");

            }

            return sb.ToString().Trim();
        }
    }
}
