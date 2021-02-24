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

            System.Console.WriteLine(GetEmployeesInPeriod(db));
        }

        public static string GetEmployeesInPeriod(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();
            var employees = context.Employees
                .Include(x => x.EmployeesProjects)
                .ThenInclude(x => x.Project)
                .Select(x => new { 
                    EmplooyeFirstName = x.FirstName, 
                    EmplooyeLastName = x.LastName, 
                    ManagerFirstName = x.Manager.FirstName, 
                    ManagerLastName = x.Manager.LastName, 
                    Projects = x.EmployeesProjects
                    .Select(p => new { 
                        ProjectName = p.Project.Name,
                        p.Project.StartDate,
                        p.Project.EndDate })})
                .Where(x => x.Projects.Any(p => p.StartDate.Year >= 2001 &&
                                                        p.StartDate.Year <= 2003))
                .Take(10).ToList();

            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.EmplooyeFirstName} {employee.EmplooyeLastName} - Manager: {employee.ManagerFirstName} {employee.ManagerLastName}");

                foreach (var empProject in employee.Projects)
                {
                    var endDate = empProject.EndDate.HasValue ? empProject.EndDate.Value.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture) : "not finished";
                    sb.AppendLine($"--{empProject.ProjectName} - {empProject.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture)} - {endDate}");

                }
            }
            return sb.ToString().TrimEnd();
        }
    }
}
