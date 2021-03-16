namespace BookShop
{
    using BookShop.Models.Enums;
    using Data;
    using Initializer;
    using System;
    using System.Globalization;
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
            //Console.WriteLine(GetGoldenBooks(db));
            //Console.WriteLine(GetBooksByPrice(db));
            //int year = int.Parse(Console.ReadLine());
            //Console.WriteLine(GetBooksNotReleasedIn(db,year));
            //string date = Console.ReadLine();
            //Console.WriteLine(GetBooksReleasedBefore(db, date));
            //string input = Console.ReadLine();
            //Console.WriteLine(GetAuthorNamesEndingIn(db, input));
            string input = Console.ReadLine();
            Console.WriteLine(GetBookTitlesContaining(db, input));
        }

        //2
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

        //3
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


        //4
        public static string GetBooksByPrice(BookShopContext context)
        {
            StringBuilder sb = new StringBuilder();

            var books = context.Books
                .Select(x => new
                {
                    x.Title,
                    x.Price
                })
                .Where(x => x.Price > 40)
                .OrderByDescending(x => x.Price)
                .ToList();

            foreach (var book in books)
            {
                sb.AppendLine($"{book.Title} - ${book.Price}");
            }
            return sb.ToString().TrimEnd();
        }

        //5
        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            StringBuilder sb = new StringBuilder();
            var books = context.Books
                .Select(x => new
                {
                    x.BookId,
                    x.Title,
                    x.ReleaseDate
                })
                .Where(x => x.ReleaseDate.Value.Year != year)
                .OrderBy(x => x.BookId)
                .ToList();

            foreach (var book in books)
            {
                sb.AppendLine($"{book.Title}");
            }

            return sb.ToString().TrimEnd();
        }

        //6
        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            StringBuilder sb = new StringBuilder();


            return sb.ToString().TrimEnd();
        }

        //7
        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            StringBuilder sb = new StringBuilder();

            var books = context.Books
                .Select(x => new
                {
                    x.ReleaseDate,
                    x.Title,
                    x.EditionType,
                    x.Price
                })
                .Where(x => x.ReleaseDate.Value < DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture))
                .OrderByDescending(x => x.ReleaseDate)
                .ToList();


            foreach (var book in books)
            {
                sb.AppendLine($"{book.Title} - {book.EditionType} - ${book.Price}");
            }

            return sb.ToString().TrimEnd();
        }

        //8
        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            StringBuilder sb = new StringBuilder();

            var authors = context.Authors
                .Select(x => new
                {
                    x.FirstName,
                    Fullname = x.FirstName + ' ' + x.LastName
                })
                .Where(x => x.FirstName.EndsWith(input))
                .OrderBy(x => x.Fullname)
                .ToList();


            foreach (var author in authors)
            {
                sb.AppendLine($"{author.Fullname}");
            }

            return sb.ToString().TrimEnd();
        }

        //9
        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            StringBuilder sb = new StringBuilder();

            var books = context.Books
                .Select(x => new
                {
                    x.Title
                })
                .Where(x => x.Title.ToLower().Contains(input.ToLower()))
                .OrderBy(x => x.Title)
                .ToList();


            foreach (var book in books)
            {
                sb.AppendLine($"{book.Title}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
