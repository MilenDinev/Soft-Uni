using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using ProductShop.Data;
using ProductShop.DataTransferObjects;
using ProductShop.Models;

namespace ProductShop
{
    public class StartUp
    {
        static IMapper mapper;

        public static void Main(string[] args)
        {
            var productShopContex = new ProductShopContext();
            productShopContex.Database.EnsureDeleted();
            productShopContex.Database.EnsureCreated();


            string usersJson = File.ReadAllText("../../../Datasets/users.json");
            string usersResult = ImportUsers(productShopContex, usersJson);

            string productsJson = File.ReadAllText("../../../Datasets/products.json");
            string productsResult = ImportProducts(productShopContex, productsJson);

            string categoriesJson = File.ReadAllText("../../../Datasets/categories.json");
            string categoriesResult = ImportCategories(productShopContex, categoriesJson);

            string categoriesProductsJson = File.ReadAllText("../../../Datasets/categories-products.json");
            string categoriesProductsResult = ImportCategoryProducts(productShopContex, categoriesProductsJson);


            Console.WriteLine(usersResult);
            Console.WriteLine(productsResult);
            Console.WriteLine(categoriesResult);
            Console.WriteLine(categoriesProductsResult);
            Console.WriteLine(GetProductsInRange(productShopContex));
            Console.WriteLine(GetSoldProducts(productShopContex));
            Console.WriteLine(GetCategoriesByProductsCount(productShopContex));
            Console.WriteLine(GetUsersWithProducts(productShopContex));

        }

        public static string GetProductsInRange(ProductShopContext context)
        {
            var products = context.Products
                .Where(x => x.Price >= 500 && x.Price <= 1000)
                .Select(product => new
                {
                    name = product.Name,
                    price = product.Price,
                    seller = product.Seller.FirstName + " " + product.Seller.LastName

                })
                .OrderBy(x => x.price)
                .ToArray();
            var result = JsonConvert.SerializeObject(products, Formatting.Indented);

            return result;
        }
        public static string GetSoldProducts(ProductShopContext context)
        {
            var users = context.Users
                .Where(u => u.ProductsSold.Any(x => x.BuyerId != null))
                .Select(x => new
                {
                    firstName = x.FirstName,
                    lastName = x.LastName,
                    soldProducts = x.ProductsSold.Where(product => product.BuyerId != null)
                    .Select(p => new
                    {
                        name = p.Name,
                        price = p.Price,
                        buyerFirstName = p.Buyer.FirstName,
                        buyerLastName = p.Buyer.LastName
                    })
                })
                .OrderBy(x => x.lastName)
                .ThenBy(x => x.firstName)
                .ToList();

            var result = JsonConvert.SerializeObject(users, Formatting.Indented);

            return result;
        }
        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            StringBuilder sb = new StringBuilder();
            var products = context.Categories
                .Select(x => new
                {
                    category = x.Name,
                    productsCount = x.CategoryProducts.Count,
                    averagePrice = x.CategoryProducts.Average(ap => ap.Product.Price).ToString("F2"),
                    totalRevenue = x.CategoryProducts.Sum(p => p.Product.Price).ToString("F2")
                })
                .OrderByDescending(x => x.productsCount)
                .ToList();

            var result = JsonConvert.SerializeObject(products, Formatting.Indented);

            return result;
        }

        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var users = context.Users
                .Include(x => x.ProductsSold)
                .ToList()
                .Where(p => p.ProductsSold.Any(b => b.BuyerId != null))
                .Select(u => new
                {
                    firstName = u.FirstName,
                    lastName = u.LastName,
                    age = u.Age,
                    soldProducts = new
                    {
                        count = u.ProductsSold.Where(b => b.BuyerId != null).Count(),
                        products = u.ProductsSold.Where(b => b.BuyerId != null)
                            .Select(p => new
                            {
                                name = p.Name,
                                price = p.Price
                            }).ToList()
                    }
                })
                .OrderByDescending(x => x.soldProducts.count)
                .ToList();

            var resultObject = new
            {
                usersCount = users.Count(),
                users = users
            };


            var jsonSerializerSettings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            };

            var result = JsonConvert.SerializeObject(resultObject, Formatting.Indented, jsonSerializerSettings);

            return result;

        }

        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            InitializeAutoMapper();

            var dtoUsers = JsonConvert.DeserializeObject<IEnumerable<UserInputModel>>(inputJson);

            var users = mapper.Map<IEnumerable<User>>(dtoUsers);

            context.Users.AddRange(users);
            context.SaveChanges();
            return $"Successfully imported {users.Count()}";
        }

        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            InitializeAutoMapper();
            var dtoProducts = JsonConvert.DeserializeObject<IEnumerable<ProductInputModel>>(inputJson);
            var products = mapper.Map<IEnumerable<Product>>(dtoProducts);
            context.Products.AddRange(products);
            context.SaveChanges();


            return $"Successfully imported {products.Count()}";
        }

        public static string ImportCategories(ProductShopContext contex, string inputJson)
        {
            InitializeAutoMapper();
            var dtoCategories = JsonConvert.DeserializeObject<IEnumerable<CategoryInputModel>>(inputJson).Where(x => x.Name != null).ToList();
            var categories = mapper.Map<IEnumerable<Category>>(dtoCategories);

            contex.Categories.AddRange(categories);
            contex.SaveChanges();

            return $"Successfully imported {categories.Count()}";
        }

        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            InitializeAutoMapper();

            var dtoCategoryProduct = JsonConvert.DeserializeObject<IEnumerable<CategoryProductInputModel>>(inputJson);
            var categoriesProducts = mapper.Map<IEnumerable<CategoryProduct>>(dtoCategoryProduct);

            context.CategoryProducts.AddRange(categoriesProducts);
            context.SaveChanges();

            return $"Successfully imported {categoriesProducts.Count()}";
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
