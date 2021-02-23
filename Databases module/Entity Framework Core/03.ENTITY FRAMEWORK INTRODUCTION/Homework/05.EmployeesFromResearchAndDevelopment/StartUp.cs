namespace SoftUni
{
    using SoftUni.Data;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;

    public class StartUp
    {
        static void Main(string[] args)
        {
            var db = new SoftUniContext();

            System.Console.WriteLine(GetEmployeesFromResearchAndDevelopment(db));
        }

        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();
            var employeesSalaryInfo = context.Employees
                .Select(x => new {x.FirstName, x.LastName, x.Department, x.Salary })
                .Where(x => x.Department.Name == "Research and Development")
                .OrderBy(x => x.Salary).ThenByDescending(x => x.FirstName).ToList();

            foreach (var employee in employeesSalaryInfo)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} from {employee.Department.Name} - ${employee.Salary:f2}");
            }
            return sb.ToString().TrimEnd();
        }
    }
}
