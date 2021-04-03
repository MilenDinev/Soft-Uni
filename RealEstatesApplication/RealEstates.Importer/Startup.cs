namespace RealEstates.Importer
{
    using RealEstates.Data;
    using RealEstates.Services;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text.Json;

    public class Startup
    {
        static void Main(string[] args)
        {
            var dbContext = new ApplicationDbContext();
            IPropertiesService propertiesService = new PropertiesService(dbContext);
            var propertiesJsonFirstPart = File.ReadAllText("imot.bg-houses-Sofia-raw-data-2021-03-18.json");
            var propertiesJsonSecondPart = File.ReadAllText("imot.bg-raw-data-2021-03-18.json");

            ImportJsonFile(propertiesJsonFirstPart, propertiesService);
            ImportJsonFile(propertiesJsonSecondPart, propertiesService);
        }

        public static void ImportJsonFile(string json, IPropertiesService service)
        {
            var propertiesDto = JsonSerializer.Deserialize<IEnumerable<PropertyAsJson>>(json);

            foreach (var prop in propertiesDto)
            {
                service.Add(prop.District, prop.Price, prop.Floor, prop.TotalFloors, prop.Size, prop.YardSize, prop.Year, prop.Type, prop.BuildingType);
                Console.Write(".");
            }
        }
    }
}
