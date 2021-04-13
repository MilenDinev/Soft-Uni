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
                .ToList()
                .Where(x => x.Rating >= rating && x.Projections.Any(p => p.Tickets.Any()))
                .OrderByDescending(x => x.Rating)
                .ThenByDescending(x => x.Projections.Sum(x => x.Tickets.Sum(x => x.Price)))
                .Select(x => new
                {
                    MovieName = x.Title,
                    Rating = x.Rating.ToString("f2"),
                    TotalIncomes = x.Projections.Sum(x => x.Tickets.Sum(x => x.Price)),
                    Customers = x.Projections.Where(x => x.Movie.Rating >= rating && x.Tickets.Select(x => x.Customer).Any())
                    .SelectMany(x => x.Tickets.Select(c => new
                    {
                        FirstName = c.Customer.FirstName,
                        LastName = c.Customer.LastName,
                        Balance = c.Customer.Balance.ToString("f2")

                    })
                    .OrderByDescending(x => x.Balance)
                    .ThenBy(x => x.FirstName)
                    .ThenBy(x => x.LastName)
                    )


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