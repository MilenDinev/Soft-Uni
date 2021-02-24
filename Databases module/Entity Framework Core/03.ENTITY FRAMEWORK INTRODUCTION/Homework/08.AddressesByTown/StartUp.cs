namespace SoftUni
{
    using Microsoft.EntityFrameworkCore;
    using SoftUni.Data;
    using SoftUni.Models;
    using System.Globalization;
    using System.Linq;
    using System.Security.Cryptography.X509Certificates;
    using System.Text;

    public class StartUp
    {
        static void Main(string[] args)
        {
            var db = new SoftUniContext();

            System.Console.WriteLine(GetAddressesByTown(db));
        }

        public static string GetAddressesByTown(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();
            var adresses = context.Addresses
                .Select(x => new 
                { 
                    x.AddressText, 
                    TownName = x.Town.Name, 
                    EmployeesCount = x.Employees.Count
                })
                .Where(x => x.EmployeesCount > 0)
                .OrderByDescending(x => x.EmployeesCount)
                .ThenBy(x => x.TownName)
                .ThenBy(x => x.AddressText)
                .Take(10)
                .ToList();

            foreach (var adress in adresses)
            {
                sb.AppendLine($"{adress.AddressText}, {adress.TownName} - {adress.EmployeesCount} employees");
            }

            return sb.ToString().TrimEnd();

        }
    }
}
