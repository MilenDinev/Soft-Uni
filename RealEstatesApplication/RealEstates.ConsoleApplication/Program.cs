namespace RealEstates.ConsoleApplication
{
    using Microsoft.EntityFrameworkCore;
    using RealEstates.Data;
    using RealEstates.Models;
    public class Program
    {
        static void Main(string[] args)
        {
            var db = new ApplicationDbContext();
            db.Database.Migrate();

            db.Districts.Add(new District
            {
                Name = "Дианабад"

            });

            db.SaveChanges();

        }
    }
}
