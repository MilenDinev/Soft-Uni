namespace VaporStore.DataProcessor
{
	using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using Data;
    using Microsoft.EntityFrameworkCore.Internal;
    using Newtonsoft.Json;
    using VaporStore.Data.Models;
    using VaporStore.DataProcessor.Dto.Import;

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
				var developer =  context.Developers.FirstOrDefault(x => x.Name == currentGame.Developer) ?? new Developer
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
			throw new NotImplementedException();
		}

		public static string ImportPurchases(VaporStoreDbContext context, string xmlString)
		{
			throw new NotImplementedException();
		}

		private static bool IsValid(object dto)
		{
			var validationContext = new ValidationContext(dto);
			var validationResult = new List<ValidationResult>();

			return Validator.TryValidateObject(dto, validationContext, validationResult, true);
		}
	}
}