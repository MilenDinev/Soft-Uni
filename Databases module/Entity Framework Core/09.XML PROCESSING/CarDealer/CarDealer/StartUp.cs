namespace CarDealer
{
    using CarDealer.Data;
    using CarDealer.DataTransferObjects.Import;
    using CarDealer.Models;
    using CarDealer.XMLHelper;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Xml.Serialization;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            var context = new CarDealerContext();
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            var suppliersXml = File.ReadAllText("./Datasets/suppliers.xml");
            var suppliersResult = ImportSuppliers(context, suppliersXml);

            var partsXml = File.ReadAllText("./Datasets/parts.xml");
            var partsResult = ImportParts(context, partsXml);

            var carsXml = File.ReadAllText("./Datasets/cars.xml");
            var carsResult = ImportCars(context, carsXml);

            Console.WriteLine(suppliersResult);
            Console.WriteLine(partsResult);
            Console.WriteLine(carsResult);
        }

        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(SupplierImportModel[]), new XmlRootAttribute("Suppliers"));
            var textRead = new StringReader(inputXml);

            var suppliersDto = xmlSerializer.Deserialize(textRead) as SupplierImportModel[];

            var suppliers = suppliersDto.Select(x => new Supplier
            {
                Name = x.Name,
                IsImporter = x.IsImporter
            });

            context.Suppliers.AddRange(suppliers);
            var result = context.SaveChanges();

            return $"Successfully imported {result}";
        }
        public static string ImportParts(CarDealerContext context, string inputXml)
        {
            var partsDto = XmlConverter.Deserializer<PartImportModel>(inputXml, "Parts");

            var supplierIds = context.Suppliers
                .Select(x => x.Id)
                .ToList();

            var parts = partsDto
                .Where(p => supplierIds.Contains(p.SupplierId))
                .Select(x => new Part
                {
                    Name = x.Name,
                    Price = x.Price,
                    Quantity = x.Quantity,
                    SupplierId = x.SupplierId
                })
                .ToList();

            context.Parts.AddRange(parts);
            var result = context.SaveChanges();

            return $"Successfully imported {result}";
        }
        //public static string ImportCars(CarDealerContext context, string inputXml)
        //{
        //    var cars = new List<Car>();
        //    var carsDto = XmlConverter.Deserializer<CarImportModel>(inputXml, "Cars");

        //    var allParts = context.Parts.Select(x => x.Id).ToList();

        //    foreach (var currentCar in carsDto)
        //    {
        //        var distinctedParts = currentCar.PartsIds.Select(x => x.Id).Distinct();
        //        var parts = distinctedParts.Intersect(allParts);

        //        var car = new Car
        //        {
        //            Make = currentCar.Make,
        //            Model = currentCar.Model,
        //            TravelledDistance = currentCar.TraveledDistance,
        //        };

        //        foreach (var part in parts)
        //        {
        //            var partCar = new PartCar
        //            {
        //                PartId = part
        //            };

        //            car.PartCars.Add(partCar);
        //        }

        //        cars.Add(car);
        //    }

        //    context.Cars.AddRange(cars);
        //    var result = context.SaveChanges();

        //    return $"Successfully imported {cars.Count()}";
        //}
        public static string ImportCars(CarDealerContext context, string inputXml)
        {
            var carsDto = XmlConverter.Deserializer<CarImportModel>(inputXml, "Cars");

            var allParts = context.Parts.Select(x => x.Id).ToList();

            var cars = carsDto
                .Select(x => new Car
                {
                    Make = x.Make,
                    Model = x.Model,
                    TravelledDistance = x.TraveledDistance,
                    PartCars = x.PartsIds.Select(x => x.Id).Distinct().Intersect(allParts).Select(pc => new PartCar
                    {
                        PartId = pc
                    })
                    .ToList()
                });


            context.Cars.AddRange(cars);
            var result = context.SaveChanges();

            return $"Successfully imported {cars.Count()}";
        }
    }
}