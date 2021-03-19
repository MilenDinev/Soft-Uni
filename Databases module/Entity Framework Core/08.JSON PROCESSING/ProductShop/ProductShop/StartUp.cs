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

            string categoriesProductsJson = File.ReadAllText("../../../Datasets/categories-products.json");
            string categoriesProductsResult = ImportCategoryProducts(productShopContex, categoriesProductsJson);


            Console.WriteLine(usersResult);
            Console.WriteLine(productsResult);
            Console.WriteLine(categoriesResult);
            Console.WriteLine(categoriesProductsResult);

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