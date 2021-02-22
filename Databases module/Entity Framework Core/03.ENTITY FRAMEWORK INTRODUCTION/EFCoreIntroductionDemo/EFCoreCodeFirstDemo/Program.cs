using EFCoreCodeFirstDemo.Models;
using System;

namespace EFCoreCodeFirstDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var db = new SliDoDbContext();
            db.Database.EnsureCreated();
        }
    }
}
