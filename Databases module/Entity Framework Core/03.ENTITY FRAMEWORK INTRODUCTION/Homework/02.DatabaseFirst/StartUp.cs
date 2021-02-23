namespace _02.DatabaseFirst
{
    using Data.Models;
    using System.Linq;
    using System.Security.Cryptography.X509Certificates;

    public class StartUp
    {
        static void Main(string[] args)
        {
            var db = new SoftUniContext();
            GetEmployeesFullInformation(db);
        }

        public static string GetEmployeesFullInformation(SoftUniContext context)
        {
            var employeesInfo = context.Employees
                .Select(x => new { x.EmployeeId, x.FirstName, x.LastName, x.MiddleName, x.JobTitle, x.Salary})
                .OrderBy(x => x.EmployeeId).ToList();

            foreach (var employee in employeesInfo)
            {
                System.Console.WriteLine($"{employee.FirstName} {employee.LastName} {employee.MiddleName} {employee.Salary:f2} ");
            }

            return "";
        }
    }
}
