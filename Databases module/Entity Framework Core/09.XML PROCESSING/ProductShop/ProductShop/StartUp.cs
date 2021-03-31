namespace ProductShop
{
    using AutoMapper;
    using CarDealer.XMLHelper;
    using ProductShop.Data;
    using ProductShop.Dtos.Export;
    using ProductShop.Dtos.Import;
    using ProductShop.Models;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class StartUp
    {
        static IMapper mapper;

        public static void Main(string[] args)
        {
            var context = new ProductShopContext();
            //context.Database.EnsureDeleted();
            //context.Database.EnsureCreated();

            //var usersXml = File.ReadAllText("../../../Datasets/users.xml");
            //Console.WriteLine(ImportUsers(context, usersXml));

            //var productsXml = File.ReadAllText("../../../Datasets/products.xml");
            //Console.WriteLine(ImportProducts(context, productsXml));

            //var categoriesXml = File.ReadAllText("../../../Datasets/categories.xml");
            //Console.WriteLine(ImportCategories(context, categoriesXml));

            //var categoriesProductsXml = File.ReadAllText("../../../Datasets/categories-products.xml");
            //Console.WriteLine(ImportCategoryProducts(context, categoriesProductsXml));

            Console.WriteLine(GetProductsInRange(context));

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
            var productsDto = XmlConverter.Deserializer<ProductImportModel>(inputXml,"Products");
            var products = mapper.Map<IEnumerable<Product>>(productsDto);
            context.Products.AddRange(products);
            var result = context.SaveChanges();

            return $"Successfully imported {result}";
        }

        public static string ImportCategories(ProductShopContext context, string inputXml)
        {
            InitializeAutoMapper();
            var categoriesDto = XmlConverter.Deserializer<CategoryImportModel>(inputXml, "Categories").Where(x => x.Name != null);
            var categories = mapper.Map<IEnumerable<Category>>(categoriesDto);
            context.Categories.AddRange(categories);
            var result = context.SaveChanges();

            return $"Successfully imported {result}";
        }

        public static string ImportCategoryProducts(ProductShopContext context, string inputXml)
        {
            InitializeAutoMapper();
            var categoryIds = context.Categories.Select(x => x.Id).ToList();
            var productIds = context.Products.Select(x => x.Id).ToList();

            var categoriesProductsDto = XmlConverter.Deserializer<CategoryProductImportModel>(inputXml, "CategoryProducts").Where(x => categoryIds.Contains(x.CategoryId) && productIds.Contains(x.ProductId));
            var categoriesProducts = mapper.Map<IEnumerable<CategoryProduct>>(categoriesProductsDto);

            context.CategoryProducts.AddRange(categoriesProducts);
            var result = context.SaveChanges();

            return $"Successfully imported {result}";
        }


        public static string GetProductsInRange(ProductShopContext context)
        {
            var products = context.Products
                .Where(x => x.Price >= 500 && x.Price <= 1000)
                .Select(x => new ProductExportModel
                {
                    Name = x.Name,
                    Price = x.Price,
                    BuyerFullName = x.Buyer.FirstName + " " + x.Buyer.LastName
                })
                .OrderBy(x => x.Price)
                .Take(10)
                .ToList();

            var result= XmlConverter.Serialize(products, "Products");

            return result;

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