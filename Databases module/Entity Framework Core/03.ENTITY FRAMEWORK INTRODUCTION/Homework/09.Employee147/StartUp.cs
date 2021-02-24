namespace SoftUni
{
    using SoftUni.Data;
    using System.Linq;
    using System.Text;

    public class StartUp
    {
        static void Main(string[] args)
        {
            var db = new SoftUniContext();

            System.Console.WriteLine(GetEmployee147(db));
        }

        public static string GetEmployee147(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();
            var employee147 = context.Employees
                .Select(x => new 
                { 
                    x.EmployeeId,
                    x.FirstName, 
                    x.LastName, 
                    x.JobTitle,
                    Projects = x.EmployeesProjects.Select(p => p.Project.Name)
                })
                .Where(x => x.EmployeeId == 147)
                .ToList();

            foreach (var employee in employee147)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle}");
                foreach (var empProject in employee.Projects.OrderBy(x => x))
                {
                    sb.AppendLine($"{empProject}");
                }
            }

            return sb.ToString().TrimEnd();
        }
    }
}
