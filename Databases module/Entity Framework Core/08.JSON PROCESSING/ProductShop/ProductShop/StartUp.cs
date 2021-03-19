using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AutoMapper;
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

            Console.WriteLine(usersResult);
            Console.WriteLine(productsResult);
            Console.WriteLine(categoriesResult);

        }

        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            InitializeAutoMapper();

            var dtoUsers = JsonConvert.DeserializeObject<IEnumerable<UserInputModel>>(inputJson);

            var users = mapper.Map<IEnumerable<User>>(dtoUsers);

            context.Users.AddRange(users);
            context.SaveChanges();
            return $"Seccessfully imported {users.Count()}";
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
            var dtoCategories = JsonConvert.DeserializeObject<IEnumerable<CategoryInputModel>>(inputJson);
            var categories = mapper.Map<IEnumerable<Category>>(dtoCategories);

            contex.AddRange(categories);
            contex.SaveChanges();

            return $"Successfully imported {categories.Count()}";
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