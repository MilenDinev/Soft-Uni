namespace NewtonJsonDemo
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;
    using System;
    using System.Collections.Generic;
    using System.IO;

    class Program
    {
        static void Main(string[] args)
        {
            Car car = new Car
            {
                Extras = new List<string> { "Klimatronik", "4x4", "Farove" },
                ManufacturedOn = DateTime.Now,
                Model = "Golf",
                Vendor = "VW",
                Price = 12.323m,
                Engine = new Engine
                {
                    HorsePower = 200,
                    Volume = 1.6f
                }
            };

 
            File.WriteAllText("myCar.json", JsonConvert.SerializeObject(car));
            var json = File.ReadAllText("myCar.json");
            JsonConvert.DeserializeObject<Car>(json);
            JsonConvert.SerializeObject(json);

            var options = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                ContractResolver = new DefaultContractResolver
                {
                    NamingStrategy = new CamelCaseNamingStrategy()
                }
            };

            Console.WriteLine(JsonConvert.SerializeObject(car, options));


            var a = new
            {
                Model = "",
                Price = 00.00m
            };


            Console.WriteLine(JsonConvert.DeserializeAnonymousType(json, a, options));
        }
    }
}
