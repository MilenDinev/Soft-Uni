namespace CarDealer
{
    using AutoMapper;
    using CarDealer.Data;
    using CarDealer.DataTransferObjects.Export;
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
        static IMapper mapper;
        public static void Main(string[] args)
        {
            var context = new CarDealerContext();
            //context.Database.EnsureDeleted();
            //context.Database.EnsureCreated();

            //var suppliersXml = File.ReadAllText("./Datasets/suppliers.xml");
            //var suppliersResult = ImportSuppliers(context, suppliersXml);

            //var partsXml = File.ReadAllText("./Datasets/parts.xml");
            //var partsResult = ImportParts(context, partsXml);

            //var carsXml = File.ReadAllText("./Datasets/cars.xml");
            //var carsResult = ImportCars(context, carsXml);

            //var customersXml = File.ReadAllText("./Datasets/customers.xml");
            //var customersResult = ImportCustomers(context, customersXml);

            //var salesXml = File.ReadAllText("./Datasets/sales.xml");
            //var salesResult = ImportSales(context, salesXml);

            //Console.WriteLine(suppliersResult);
            //Console.WriteLine(partsResult);
            //Console.WriteLine(carsResult);
            //Console.WriteLine(customersResult);
            //Console.WriteLine(salesResult);

            Console.WriteLine(GetCarsWithDistance(context)); 
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
                    TravelledDistance = x.TravelledDistance,
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
        public static string ImportCustomers(CarDealerContext context, string inputXml)
        {
            InitializeAutoMapper();

            var customersDto = XmlConverter.Deserializer<CustomerImportModel>(inputXml, "Customers");
            var customers = mapper.Map<IEnumerable<Customer>>(customersDto);

            context.Customers.AddRange(customers);
            var result = context.SaveChanges();

            return $"Successfully imported {result}";
        }
        public static string ImportSales(CarDealerContext context, string inputXml)
        {
            InitializeAutoMapper();

            var carIds = context.Cars.Select(x => x.Id).ToList();
            var salesDto = XmlConverter.Deserializer<SaleImportModel>(inputXml, "Sales").Where(x => carIds.Contains(x.CarId));


            var sales = mapper.Map<IEnumerable<Sale>>(salesDto);
            context.Sales.AddRange(sales);
            var result = context.SaveChanges();

            return $"Successfully imported {result}";
        }

        public static string GetCarsWithDistance(CarDealerContext context)
        {
            InitializeAutoMapper();
            var cars = context.Cars.Where(x => x.TravelledDistance > 2_000_000);

            var carsDto = mapper.Map<IEnumerable<CarsExportModel>>(cars).OrderBy(x => x.Make).ThenBy(x=> x.Model).Take(10).ToArray();

            //XmlSerializer xmlSerializer = new XmlSerializer(typeof(CarsExportModel[]), new XmlRootAttribute("cars"));

            //var textWriter = new StringWriter();

            //var ns = new XmlSerializerNamespaces();
            //ns.Add("", "");

            //xmlSerializer.Serialize(textWriter, carsDto, ns);
            //var result = textWriter.ToString();

            var result = XmlConverter.Serialize(carsDto, "cars");

            return result;
        }

        private static void InitializeAutoMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CarDealerProfile>();
            });

            mapper = config.CreateMapper();
        }
    }
}