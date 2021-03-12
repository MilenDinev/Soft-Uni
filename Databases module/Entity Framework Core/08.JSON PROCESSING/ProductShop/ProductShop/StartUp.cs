using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using ProductShop.Data;
using ProductShop.DataTransferObjects;
using ProductShop.Models;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var productShopContex = new ProductShopContext();
            productShopContex.Database.EnsureDeleted();
            productShopContex.Database.EnsureCreated();

            string inputJson = File.ReadAllText("../../../Datasets/users.json");
            var result = ImportUsers(productShopContex, inputJson);

        }

        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            var users = JsonConvert.DeserializeObject<IEnumerable<UserInputModel>>(inputJson);



            context.Users.AddRange(users);
            context.SaveChanges();
            return $"Seccessfully imported{0}";
        }
    }
}