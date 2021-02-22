namespace EFCoreCodeFirstDemo
{
    using EFCoreCodeFirstDemo.Models;
    using Microsoft.EntityFrameworkCore;
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            var db = new SliDoDbContext();
            db.Database.Migrate();
        }
    }
}
