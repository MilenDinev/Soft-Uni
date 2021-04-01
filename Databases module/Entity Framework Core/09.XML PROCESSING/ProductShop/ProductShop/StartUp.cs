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

            //Console.WriteLine(GetProductsInRange(context));
            //Console.WriteLine(GetSoldProducts(context));
            Console.WriteLine(GetCategoriesByProductsCount(context));

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

        public static string GetSoldProducts(ProductShopContext context)
        {
            var users = context.Users
                .Where(x => x.ProductsSold.Any())
                .Select(x => new UserExportModel
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    SoldProducts = x.ProductsSold.Select(p => new SoldProductExportModel
                    {
                        Name = p.Name,
                        Price = p.Price
                    }).ToArray()
                })
                .OrderBy(x => x.LastName)
                .ThenBy(x => x.FirstName)
                .Take(5)
                .ToArray();

            var result = XmlConverter.Serialize(users, "Users");

            return result;
        }

        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categories = context.Categories
                .Select(x => new CategoryProductExportModel
                {
                    Name = x.Name,
                    Count = x.CategoryProducts.Count,
                    AveragePrice = x.CategoryProducts.Average(ap => ap.Product.Price),
                    TotalRevenue = x.CategoryProducts.Sum(p => p.Product.Price)
                })
                .OrderByDescending(x => x.Count)
                .ThenBy(x => x.TotalRevenue)
                .ToList();

            var result = XmlConverter.Serialize(categories, "Categories");

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