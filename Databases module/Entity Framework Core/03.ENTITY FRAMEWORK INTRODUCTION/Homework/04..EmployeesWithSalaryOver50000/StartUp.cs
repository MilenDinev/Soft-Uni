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

            System.Console.WriteLine(GetEmployeesWithSalaryOver50000(db));
        }

        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();
            var employeesSalaryInfo = context.Employees
                .Select(x => new {x.FirstName,x.Salary })
                .Where(x => x.Salary > 50_000)
                .OrderBy(x => x.FirstName).ToList();

            foreach (var employee in employeesSalaryInfo)
            {
                sb.AppendLine($"{employee.FirstName} - {employee.Salary:f2}");
            }
            return sb.ToString().Trim();
        }
    }
}
