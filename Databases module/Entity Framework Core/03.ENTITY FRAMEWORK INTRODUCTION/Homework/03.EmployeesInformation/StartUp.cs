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


            System.Console.WriteLine(GetEmployeesFullInformation(db));
        }

        public static string GetEmployeesFullInformation(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();
            var employeesInfo = context.Employees
                .Select(x => new { x.EmployeeId, x.FirstName, x.LastName, x.MiddleName, x.JobTitle, x.Salary })
                .OrderBy(x => x.EmployeeId).ToList();

            foreach (var employee in employeesInfo)
            {
                sb.Append($"{employee.FirstName} {employee.LastName}");
                if (!string.IsNullOrWhiteSpace(employee.MiddleName))
                {
                    sb.Append($" {employee.MiddleName} {employee.JobTitle} {employee.Salary:f2}");
                }

                else
                {
                    sb.Append($" {employee.JobTitle} {employee.Salary:f2}");
                }

                sb.AppendLine();
            }

            return sb.ToString().Trim();
        }
    }
}
