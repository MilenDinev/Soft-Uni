﻿namespace BookShop
{
    using BookShop.Models;
    using BookShop.Models.Enums;
    using Data;
    using Initializer;
    using Microsoft.EntityFrameworkCore;
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

            string command = Console.ReadLine();
            Console.WriteLine(GetBooksByAgeRestriction(db, command));
            Console.WriteLine(GetGoldenBooks(db));
            string input = Console.ReadLine();
            Console.WriteLine(GetBooksByCategory(db, input));
            Console.WriteLine(GetBooksByPrice(db));
            int year = int.Parse(Console.ReadLine());
            Console.WriteLine(GetBooksNotReleasedIn(db, year));
            string date = Console.ReadLine();
            Console.WriteLine(GetBooksReleasedBefore(db, date));
            Console.WriteLine(GetAuthorNamesEndingIn(db, input));
            Console.WriteLine(GetBookTitlesContaining(db, input));
            Console.WriteLine(GetBooksByAuthor(db, input));
            int lenghtCheck = int.Parse(Console.ReadLine());
            Console.WriteLine(CountBooks(db, lenghtCheck));
            Console.WriteLine(CountCopiesByAuthor(db));
            Console.WriteLine(GetTotalProfitByCategory(db));
            Console.WriteLine(GetMostRecentBooks(db));
            //IncreasePrices(db);
            Console.WriteLine(RemoveBooks(db));


        }

        //1
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

        //2
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

        //3
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
                sb.AppendLine($"{book.Title} - ${book.Price:F2}");
            }
            return sb.ToString().TrimEnd();
        }

        //4
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

        //5
        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            StringBuilder sb = new StringBuilder();
            var categories = input.Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(x => x.ToLower())
                .ToArray();
            var books = context.Books
                .Include(x => x.BookCategories)
                .ThenInclude(x => x.Category)
                .ToList()
                .Where(x => x.BookCategories.Any(x => categories.Contains(x.Category.Name.ToLower())))
                .Select(x => x.Title)
                .OrderBy(x => x);

            foreach (var book in books)
            {
                sb.AppendLine($"{book}");
            }

            return sb.ToString().TrimEnd();
        }

        //6
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
                sb.AppendLine($"{book.Title} - {book.EditionType} - ${book.Price:F2}");
            }

            return sb.ToString().TrimEnd();
        }

        //7
        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            StringBuilder sb = new StringBuilder();

            var authors = context.Authors
                .Select(x => new
                {
                    x.FirstName,
                    Fullname = x.FirstName + ' ' + x.LastName
                })
                .Where(x => x.FirstName.ToLower().EndsWith(input.ToLower()))
                .OrderBy(x => x.Fullname)
                .ToList();


            foreach (var author in authors)
            {
                sb.AppendLine($"{author.Fullname}");
            }

            return sb.ToString().TrimEnd();
        }

        //8
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

        //9
        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            StringBuilder sb = new StringBuilder();

            var books = context.Books
                .Select(x => new
                {
                    x.BookId,
                    x.Title,
                    x.Author.LastName,
                    AuthorFullname = x.Author.FirstName + ' ' + x.Author.LastName
                })
                .Where(x => x.LastName.ToLower().StartsWith(input.ToLower()))
                .OrderBy(x => x.BookId)
                .ToList();


            foreach (var book in books)
            {
                sb.AppendLine($"{book.Title} ({book.AuthorFullname})");
            }

            return sb.ToString().TrimEnd();
        }

        //10
        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            int counter = context.Books
                .Where(x => x.Title.Length > lengthCheck).Count();

            return counter;
        }

        //11
        public static string CountCopiesByAuthor(BookShopContext context)
        {
            StringBuilder sb = new StringBuilder();

            var authors = context.Authors
                .Select(x => new
                {
                    FullName = x.FirstName + ' ' + x.LastName,
                    BookCopies = x.Books.Select(x => x.Copies).Sum()
                })
                .OrderByDescending(x => x.BookCopies)
                .ToList();

            foreach (var author in authors)
            {
                sb.AppendLine($"{author.FullName} - {author.BookCopies}");
            }

            return sb.ToString().TrimEnd();

        }

        //12

        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            StringBuilder sb = new StringBuilder();

            var books = context.Categories
                .Select(x => new
                {
                    x.Name,
                   TotalProfit= x.CategoryBooks.Select(x => x.Book.Price * x.Book.Copies).Sum()
                })
                 .OrderByDescending(x => x.TotalProfit)
                .ToList();

            foreach (var category in books)
            {
                sb.AppendLine($"{category.Name} ${category.TotalProfit:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        //13

        public static string GetMostRecentBooks(BookShopContext context)
        {
            StringBuilder sb = new StringBuilder();

            var categories = context.Categories
                .Select(x => new
                {
                    x.Name,
                    Books = x.CategoryBooks.Select(x => new { 
                    BookTitle = x.Book.Title,
                    BookReleaseDate = x.Book.ReleaseDate
                    })
                    .OrderByDescending(x => x.BookReleaseDate)
                    .Take(3)
                    .ToList()
                })
                .OrderBy(x => x.Name)
                .ToList();

            foreach (var category in categories)
            {
                sb.AppendLine($"--{category.Name}");

                foreach (var book in category.Books)
                {
                    sb.AppendLine($"{book.BookTitle} ({book.BookReleaseDate.Value.Year})");
                }

            }

            return sb.ToString().TrimEnd();

        }

        //14

        public static void IncreasePrices(BookShopContext context)
        {
            var books = context.Books;

            foreach (var book in books)
            {
                book.Price += 5;
            }

            context.SaveChanges();
        }

        //15
        public static int RemoveBooks(BookShopContext context)
        {
            var books = context.Books
                .Where(x => x.Copies < 4200)
                .ToList();

            context.Books.RemoveRange(books);

            var result = context.SaveChanges();

            return result / 2;
        }
    }
}
