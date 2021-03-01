namespace P01_StudentSystem 
{
    using P01_StudentSystem.Data;
    using System;

    public class Startup
    {
       public static void Main(string[] args)
        {
            var context = new StudentSystemContext();
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
        }
    }
}
