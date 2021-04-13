namespace Cinema.DataProcessor
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using Cinema.Data.Models;
    using Cinema.Data.Models.Enums;
    using Cinema.DataProcessor.ImportDto;
    using Cinema.DataProcessor.XmlHelper;
    using Data;
    using Newtonsoft.Json;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfulImportMovie 
            = "Successfully imported {0} with genre {1} and rating {2}!";

        private const string SuccessfulImportProjection 
            = "Successfully imported projection {0} on {1}!";

        private const string SuccessfulImportCustomerTicket 
            = "Successfully imported customer {0} {1} with bought tickets: {2}!";

        public static string ImportMovies(CinemaContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();
            var movies = new List<Movie>();

            var moviesDto = JsonConvert.DeserializeObject<IEnumerable<MovieImportModel>>(jsonString);
            foreach (var currentMovie in moviesDto)
            {
                if (!IsValid(currentMovie))
                {
                    sb.AppendLine("Invalid data!");
                    continue;
                }

                var movie = new Movie
                {
                    Title = currentMovie.Title,
                    Genre = Enum.Parse<Genre>(currentMovie.Genre),
                    Duration = TimeSpan.ParseExact(currentMovie.Duration, "c", CultureInfo.InvariantCulture),
                    Rating = currentMovie.Rating,
                    Director = currentMovie.Director

                };

                var isExistingMovie = movies.FirstOrDefault(x => x.Title == currentMovie.Title);
                if (isExistingMovie != null)
                {
                    sb.AppendLine("Invalid data!");
                    continue;
                }
                movies.Add(movie);
                context.Movies.Add(movie);
                context.SaveChanges();
                sb.AppendLine($"Successfully imported {movie.Title} with genre {movie.Genre} and rating {movie.Rating:f2}!");

            }
            return sb.ToString().TrimEnd();
        }

        public static string ImportProjections(CinemaContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();
            var projectionsDto = XmlConverter.Deserializer<ProjectionImportModel>(xmlString, "Projections");

            foreach (var currentProjection in projectionsDto)
            {
                if (!IsValid(currentProjection) || !context.Movies.Select(x => x.Id).Contains(currentProjection.MovieId))
                {
                    sb.AppendLine("Invalid data!");
                    continue;
                }

                var projection = new Projection
                {
                    MovieId = currentProjection.MovieId,
                    DateTime = DateTime.ParseExact(currentProjection.DateTime, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture)
                };

                context.Projections.Add(projection);
                context.SaveChanges();
                sb.AppendLine($"Successfully imported projection {projection.Movie.Title} on {projection.DateTime.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture)}!");
            }
            return sb.ToString().TrimEnd();
        }

        public static string ImportCustomerTickets(CinemaContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();
            var customersDto = XmlConverter.Deserializer<CustomerTicketsImportModel>(xmlString, "Customers");

            foreach (var currentCustomer in customersDto)
            {
                if (!IsValid(currentCustomer))
                {
                    sb.AppendLine("Invalid data!");
                    continue;
                }

                var customer = new Customer
                {
                    FirstName = currentCustomer.FirstName,
                    LastName = currentCustomer.LastName,
                    Age = currentCustomer.Age,
                    Balance = currentCustomer.Balance
                };

                foreach (var currentTicket in currentCustomer.Tickets)
                {
                    if (!IsValid(currentTicket) || !context.Projections.Select(x => x.Id).Contains(currentTicket.ProjectionId))
                    {
                        sb.AppendLine("Invalid data!");
                        continue;
                    }

                    var ticket = new Ticket
                    {
                        ProjectionId = currentTicket.ProjectionId,
                        Price = currentTicket.Price
                    };

                    customer.Tickets.Add(ticket);
                }
                context.Customers.Add(customer);
                context.SaveChanges();
                sb.AppendLine($"Successfully imported customer {customer.FirstName} {customer.LastName} with bought tickets: {customer.Tickets.Count}!");

            }

            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}