using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
namespace JSONDemo
{

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
                Engine = new Engine { 
                    HorsePower = 200, 
                    Volume = 1.6f 
                }
            };

            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };

            File.WriteAllText("myCar.json", JsonSerializer.Serialize(car));
            var json = File.ReadAllText("myCar.json");

            Car carJ = JsonSerializer.Deserialize<Car>(json);

            Console.WriteLine(json);

            Console.WriteLine(JsonSerializer.Serialize(car));

            //Newton JSon library
            //JsonConvert.DeserializeObject<Car>(json);
            //JsonConvert.SerializeObject(json);

        }
    }
}
