﻿namespace VaporStore.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using Data;
    using Microsoft.EntityFrameworkCore.Internal;
    using Newtonsoft.Json;
    using VaporStore.Data.Models;
    using VaporStore.Data.Models.Enums;
    using VaporStore.DataProcessor.Dto.Import;
    using VaporStore.DataProcessor.XmlHelper;

    public static class Deserializer
    {
        public static string ImportGames(VaporStoreDbContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();
            var gamesDto = JsonConvert.DeserializeObject<IEnumerable<GameImportModel>>(jsonString);

            foreach (var currentGame in gamesDto)
            {
                var isValidDate = DateTime.TryParseExact(currentGame.ReleaseDate, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out var releaseDate);


                if (!IsValid(currentGame) || !currentGame.Tags.All(IsValid) || currentGame.Tags.Count == 0 || !isValidDate)
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }
                var developer = context.Developers.FirstOrDefault(x => x.Name == currentGame.Developer) ?? new Developer
                {
                    Name = currentGame.Developer
                };

                var genre = context.Genres.FirstOrDefault(x => x.Name == currentGame.Genre) ?? new Genre
                {
                    Name = currentGame.Genre
                };

                var game = new Game
                {
                    Name = currentGame.Name,
                    Price = currentGame.Price,
                    ReleaseDate = DateTime.ParseExact(currentGame.ReleaseDate.ToString(), "yyyy-MM-dd", CultureInfo.InvariantCulture),
                    Developer = developer,
                    Genre = genre,
                };

                foreach (var currentTag in currentGame.Tags)
                {
                    var tag = context.Tags.FirstOrDefault(x => x.Name == currentTag) ?? new Tag
                    {
                        Name = currentTag
                    };

                    game.GameTags.Add(new GameTag { Tag = tag });
                }
                context.Games.Add(game);
                context.SaveChanges();
                sb.AppendLine($"Added {game.Name} ({game.Genre.Name}) with {game.GameTags.Count} tags");
            }

            var result = sb.ToString().TrimEnd();
            return result;
        }

        public static string ImportUsers(VaporStoreDbContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();
            var usersDto = JsonConvert.DeserializeObject<IEnumerable<UserImportModel>>(jsonString);


            foreach (var currentUser in usersDto)
            {
                if (!IsValid(currentUser) || !currentUser.Cards.All(IsValid))
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                var user = new User
                {
                    FullName = currentUser.FullName,
                    Username = currentUser.Username,
                    Age = currentUser.Age,
                    Email = currentUser.Email,
                    Cards = currentUser.Cards.Select(x => new Card
                    {
                        Number = x.Number,
                        Cvc = x.Cvc,
                        Type = Enum.Parse<CardType>(x.Type)
                    }).ToList()
                };
                context.Users.Add(user);
                sb.AppendLine($"Imported {user.Username} with {user.Cards.Count} cards");
            }

            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportPurchases(VaporStoreDbContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();
            var purchasesDto = XmlConverter.Deserializer<PurchaseImportModel>(xmlString, "Purchases");

            foreach (var currentPurchase in purchasesDto)
            {
                var isValidDate = DateTime.TryParseExact(currentPurchase.Date, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime date);

                if (!IsValid(currentPurchase))
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                var card = context.Cards.FirstOrDefault(x => x.Number == currentPurchase.Card);
                if (card == null)
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                var game = context.Games.FirstOrDefault(x => x.Name == currentPurchase.GameTitle);
                if (game == null)
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                var purchase = new Purchase
                {
                    ProductKey = currentPurchase.Key,
                    Date = date,
                    Type = Enum.Parse<PurchaseType>(currentPurchase.Type),
                    Card = card,
                    Game = game
                };

                context.Purchases.Add(purchase);
                sb.AppendLine($"Imported {purchase.Game.Name} for {purchase.Card.User.Username}");
            }
            context.SaveChanges();

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