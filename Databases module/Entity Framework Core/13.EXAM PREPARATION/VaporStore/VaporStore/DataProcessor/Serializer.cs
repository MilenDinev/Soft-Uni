namespace VaporStore.DataProcessor
{
    using System;
    using System.Globalization;
    using System.Linq;
    using Data;
    using Newtonsoft.Json;
    using VaporStore.Data.Models;
    using VaporStore.DataProcessor.Dto.Export;
    using VaporStore.DataProcessor.XmlHelper;

    public static class Serializer
    {
        public static string ExportGamesByGenres(VaporStoreDbContext context, string[] genreNames)
        {
            var gernesGames = context.Genres
                .ToList()
                .Where(x => genreNames.Contains(x.Name) && x.Games.Select(x => x.Purchases).Any())
                .Select(x => new
                {
                    Id = x.Id,
                    Genre = x.Name,
                    Games = x.Games.Where(p => p.Purchases.Any())
                    .Select(g => new
                    {
                        Id = g.Id,
                        Title = g.Name,
                        @Developer = g.Developer.Name,
                        Tags = String.Join(", ", g.GameTags.Select(x => x.Tag.Name)),
                        Players = g.Purchases.Count()
                    })
                    .OrderByDescending(g => g.Players)
                    .ThenBy(g => g.Id)
                    .ToList(),
                    TotalPlayers = x.Games.Sum(x => x.Purchases.Count())
                })
                .OrderByDescending(x => x.TotalPlayers)
                .ThenBy(x => x.Id);

            var result = JsonConvert.SerializeObject(gernesGames, Formatting.Indented);
            return result;
        }

        public static string ExportUserPurchasesByType(VaporStoreDbContext context, string storeType)
        {
            var usersDto = context.Users
                .ToList()
                .Where(x => x.Cards.Any(c => c.Purchases.Any(s => s.Type.ToString() == storeType)))
                .Select(x => new UserExportModel
                {
                    Username = x.Username,
                    Purchases = x.Cards.SelectMany(c => c.Purchases.Where(p => p.Type.ToString() == storeType), (card, purchase) => new PurchaseExportModel
                    {
                        Card = card.Number,
                        Cvc = card.Cvc,
                        Date = purchase.Date.ToString("yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture),
                        Game = new GameExportModel()
                        {
                            Tittle = purchase.Game.Name,
                            Genre = purchase.Game.Genre.Name,
                            Price = purchase.Game.Price
                        }
                    })
                        .OrderBy(p => p.Date)
                        .ToArray(),
                    TotalSpent = x.Cards.Sum(c => c.Purchases.Where(p => p.Type.ToString() == storeType).Sum(p => p.Game.Price))

                })
                .OrderByDescending(x => x.TotalSpent)
                .ThenBy(x => x.Username)
                .ToList();

            var result = XmlConverter.Serialize(usersDto, "Users");

            return result;
        }
    }
}