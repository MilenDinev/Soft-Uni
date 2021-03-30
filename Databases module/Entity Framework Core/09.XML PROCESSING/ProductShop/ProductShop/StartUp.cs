namespace ProductShop
{
    using AutoMapper;
    using CarDealer.XMLHelper;
    using ProductShop.Data;
    using ProductShop.Dtos.Import;
    using ProductShop.Models;
    using System;
    using System.Collections.Generic;
    using System.IO;

    public class StartUp
    {
        static IMapper mapper;

        public static void Main(string[] args)
        {
            var context = new ProductShopContext();
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            var usersXML = File.ReadAllText("../../../Datasets/users.xml");
            Console.WriteLine(ImportUsers(context, usersXML));

            var productsXML = File.ReadAllText("../../../Datasets/products.xml");
            Console.WriteLine(ImportUsers(context, productsXML));

        }

        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            InitializeAutoMapper();
            var usersDto = XmlConverter.Deserializer<UserImportModel>(inputXml, "Users");
            var users = mapper.Map<IEnumerable<User>>(usersDto);
            context.Users.AddRange(users);
            var result = context.SaveChanges();

            return $"Successfully imported {result}";
        }

        public static string ImportProducts(ProductShopContext context, string inputXml)
        {
            InitializeAutoMapper();
            var productsDto = XmlConverter.Deserializer<ProductImportModel>(inputXml, "Products");
            var products = mapper.Map<IEnumerable<Product>>(productsDto);
            context.Products.AddRange(products);
            var result = context.SaveChanges();

            return $"Successfully imported {result}";
        }

        private static void InitializeAutoMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ProductShopProfile>();
            });

            mapper = config.CreateMapper();
        }
    }


}