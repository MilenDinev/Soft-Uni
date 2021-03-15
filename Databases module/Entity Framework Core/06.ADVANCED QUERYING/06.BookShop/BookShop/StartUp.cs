namespace BookShop
{
    using BookShop.Models.Enums;
    using Data;
    using Initializer;
    using System;
    using System.Linq;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            using var db = new BookShopContext();
            DbInitializer.ResetDatabase(db);
            string command = Console.ReadLine();

            Console.WriteLine(GetBooksByAgeRestriction(db, command));

        }


        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            //var ageRestriction = Enum.Parse(typeof(AgeRestriction), command, true);
            //var ageRestriction = Enum.Parse<AgeRestriction>(command, true);
            StringBuilder sb = new StringBuilder();
            var books = context.Books
                .Select(x => new { x.Title, x.AgeRestriction })
                .ToList()
                .Where(x => x.AgeRestriction.ToString().ToLower() == command.ToLower())
                .OrderBy(x => x.Title);


            foreach (var book in books)
            {
                sb.AppendLine($"{book.Title}");

            }

            foreach (var book in books)
            {
                Console.WriteLine($"{book.AgeRestriction.ToString()}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
