namespace CarDealer
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using AutoMapper;
    using CarDealer.Data;
    using CarDealer.DTO;
    using CarDealer.Models;
    using Newtonsoft.Json;

    public class StartUp
    {
        static IMapper mapper;

        public static void Main(string[] args)
        {
            var carDealerContext = new CarDealerContext();

            //carDealerContext.Database.EnsureDeleted();
            //carDealerContext.Database.EnsureCreated();

            //string inputSuppliers = File.ReadAllText("../../../Datasets/suppliers.json");
            //string suppliersResult = ImportSuppliers(carDealerContext, inputSuppliers);

            //string inputParts = File.ReadAllText("../../../Datasets/parts.json");
            //string partsResult = ImportParts(carDealerContext, inputParts);

            //string inputCars = File.ReadAllText("../../../Datasets/cars.json");
            //string carsResult = ImportCars(carDealerContext, inputCars);

            //string inputCustomers = File.ReadAllText("../../../Datasets/customers.json");
            //string customersResult = ImportCustomers(carDealerContext, inputCustomers);


            //string inputSales = File.ReadAllText("../../../Datasets/sales.json");
            //string salesResult = ImportCustomers(carDealerContext, inputSales);


            //Console.WriteLine(suppliersResult);
            //Console.WriteLine(partsResult);
            //Console.WriteLine(carsResult);
            //Console.WriteLine(customersResult);
            //Console.WriteLine(salesResult);

            Console.WriteLine(GetOrderedCustomers(carDealerContext));
        }


        public static string GetOrderedCustomers(CarDealerContext context)
        {
            var customers = context.Customers
                .Where(x => x.Name != null)
                .Select(x => new CustomerInputModel
                {
                    Name = x.Name,
                    BirthDate = x.BirthDate,
                    IsYoungDriver = x.IsYoungDriver
                })
                .OrderBy(x => x.BirthDate)
                .ThenBy(x => Convert.ToInt32(x.IsYoungDriver))
                .ToList();


            var settings = new JsonSerializerSettings { DateFormatString = "dd/MM/yyyy" };

            var result = JsonConvert.SerializeObject(customers, Formatting.Indented, settings);

            return result;
        }


        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
            InitializeAutoMapper();

            var dtoSuppliers = JsonConvert.DeserializeObject<IEnumerable<SupplierInputModel>>(inputJson);
            var suppliers = mapper.Map<IEnumerable<Supplier>>(dtoSuppliers);

            context.Suppliers.AddRange(suppliers);
            var result = context.SaveChanges();

            return $"Successfully imported {result}.";
        }

        public static string ImportParts(CarDealerContext context, string inputJson)
        {
            InitializeAutoMapper();
            var supplierIds = context.Suppliers.Select(x => x.Id).ToList();

            var dtoParts = JsonConvert.DeserializeObject<IEnumerable<PartInputModel>>(inputJson).Where(s => supplierIds.Contains(s.SupplierId)).ToList();
            var parts = mapper.Map<IEnumerable<Part>>(dtoParts);

            context.Parts.AddRange(parts);
            var result = context.SaveChanges();

            return $"Successfully imported {result}.";
        }

        public static string ImportCars(CarDealerContext context, string inputJson)
        {

            var dtoCars = JsonConvert.DeserializeObject<IEnumerable<CarInputModel>>(inputJson);

            var listOfCars = new List<Car>();
            foreach (var car in dtoCars)
            {
                var currentCar = new Car
                {
                    Make = car.Make,
                    Model = car.Model,
                    TravelledDistance = car.TravelledDistance
                };

                foreach (var partId in car?.PartsId.Distinct())
                {
                    currentCar.PartCars.Add(new PartCar
                    {
                        PartId = partId
                    });
                }

                listOfCars.Add(currentCar);
            }

            context.Cars.AddRange(listOfCars);
            context.SaveChanges();

            return $"Successfully imported {listOfCars.Count}.";
        }

        public static string ImportCustomers(CarDealerContext context, string inputJson)
        {
            InitializeAutoMapper();
            var customersDto = JsonConvert.DeserializeObject<IEnumerable<CustomerInputModel>>(inputJson);
            var customers = mapper.Map<IEnumerable<Customer>>(customersDto);
            context.Customers.AddRange(customers);
            var result = context.SaveChanges();

            return $"Successfully imported {result}.";
        }

        public static string ImportSales(CarDealerContext context, string inputJson)
        {
            InitializeAutoMapper();
            var salesDto = JsonConvert.DeserializeObject<IEnumerable<SaleInputModel>>(inputJson);
            var sales = mapper.Map<IEnumerable<Sale>>(salesDto);
            context.Sales.AddRange(sales);
            var result = context.SaveChanges();

            return $"Successfully imported {result}.";
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