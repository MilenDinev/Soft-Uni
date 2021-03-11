using System;
using System.Collections.Generic;
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
                Extras = new List<string> { "klimatronik", "4x4", "Farove" },
                ManufacturedOn = DateTime.Now,
                Model = "Golf",
                Vendor = "VW",
                Price = 12.323m,
                Engine = new Engine { 
                    HorsePower = 200, 
                    Volume = 1.6f 
                }
            };

            JsonSerializer.Serialize(car);
        }
    }
}
