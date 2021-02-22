namespace EFCoreIntroductionDemo
{
    using EFCoreIntroductionDemo.Models;
    using System;
    using System.Linq;
    using System.Security.Cryptography.X509Certificates;

    class Program
    {
        static void Main()
        {
            var db = new SoftUniContext();
            Console.WriteLine(db.Employees.Count());
            Console.WriteLine(db.Employees.Where(x => x.Salary < 100000).Count());
            foreach (var employee in db.Employees)
            {
               // Console.WriteLine(employee.Salary);
            }
            
        }
    }
}
