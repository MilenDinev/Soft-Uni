namespace Cinema.DataProcessor
{
    using System;
    using System.Globalization;
    using System.Linq;
    using Cinema.DataProcessor.ExportDto;
    using Cinema.DataProcessor.XmlHelper;
    using Data;
    using Microsoft.EntityFrameworkCore;
    using Newtonsoft.Json;

    public class Serializer
    {
        public static string ExportTopMovies(CinemaContext context, int rating)
        {
            var movies = context.Movies
                .Where(x => x.Rating >= rating && x.Projections.Any(p => p.Tickets.Any()))
                .ToList()
                .OrderByDescending(x => x.Rating)
                .ThenByDescending(x => x.Projections
                    .Sum(p => p.Tickets
                        .Sum(t => t.Price)))
                .Select(x => new
                {
                    MovieName = x.Title,
                    Rating = x.Rating.ToString("F2"),
                    TotalIncomes = x.Projections.Sum(p => p.Tickets.Sum(t => t.Price)).ToString("F2"),
                    Customers = x.Projections
                        .SelectMany(p => p.Tickets)
                        .Select(t => new
                        {
                            FirstName = t.Customer.FirstName,
                            LastName = t.Customer.LastName,
                            Balance = t.Customer.Balance.ToString("F2"),
                        })
                        .OrderByDescending(c => c.Balance)
                        .ThenBy(c => c.FirstName)
                        .ThenBy(c => c.LastName)
                        .ToList(),
                })
                .Take(10)
                .ToList();


            var result = JsonConvert.SerializeObject(movies, Formatting.Indented);
            return result;

        }

        public static string ExportTopCustomers(CinemaContext context, int age)
        {
            var customers = context.Customers
                .Where(x => x.Age >= age)
                .ToList()
                .Select(x => new CustomerExportModel
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    SpentMoney = decimal.Parse(x.Tickets.Sum(t => t.Price).ToString("F2")),
                    SpentTime = TimeSpan.FromMilliseconds(x.Tickets.Sum(t => t.Projection.Movie.Duration.TotalMilliseconds))
                    .ToString(@"hh\:mm\:ss", CultureInfo.InvariantCulture),
                })
                .OrderByDescending(x => x.SpentMoney)
                .Take(10)
                .ToList();

            var result = XmlConverter.Serialize(customers, "Customers");
            return result;
        }
    }
}