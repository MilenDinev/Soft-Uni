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

            System.Console.WriteLine(RemoveTown(db));
        }

        public static string RemoveTown(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();
            int count = 0;

            var town = context.Towns
                .Include(x => x.Addresses)
                 .FirstOrDefault(x => x.Name == "Seattle");
            var allAddressIds = town.Addresses.Select(x => x.AddressId).ToList();
            var employees = context.Employees
                .Where(x => x.AddressId.HasValue && allAddressIds.Contains(x.AddressId.Value));

            foreach (var employee in employees)
            {
                employee.AddressId = null;
            }


            foreach (var adress in town.Addresses)
            {
                context.Addresses.Remove(adress);
                count++;
            }

            context.Towns.Remove(town);


            context.SaveChanges();

            sb.AppendLine($"{count} addresses in {town.Name} were deleted");

            return sb.ToString().Trim();
        }
    }
}
