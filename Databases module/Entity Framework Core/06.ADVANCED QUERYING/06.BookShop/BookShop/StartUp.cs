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
            //string command = Console.ReadLine();
            //Console.WriteLine(GetBooksByAgeRestriction(db, command));
            Console.WriteLine(GetGoldenBooks(db));

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

        public static string GetGoldenBooks(BookShopContext context)
        {
            StringBuilder sb = new StringBuilder();

            var goldenBooks = context.Books
                .Select(x => new { x.BookId, x.Title, x.EditionType, x.Copies })
                .ToList()
                .Where(x => x.EditionType.ToString().ToLower() == "gold" && x.Copies < 5000)
                .OrderBy(x => x.BookId);


            foreach (var goldenBook in goldenBooks)
            {
                sb.AppendLine($"{goldenBook.Title}");
            }
            return sb.ToString().TrimEnd();
        }
    }
}
