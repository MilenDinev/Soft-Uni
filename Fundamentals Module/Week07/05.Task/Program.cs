//4.	Orders

using System;
using System.Collections.Generic;
using System.Linq;



namespace _05.Task
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, double[]> products = new Dictionary<string, double[]>();

            string input = Console.ReadLine();

            while (input != "buy")
            {
                string[] productInformation = input.Split();

                string product= productInformation[0];
                double price = double.Parse(productInformation[1]);
                double quality = double.Parse(productInformation[2]);


                if (!products.ContainsKey(product))
                {
                    products.Add(product, new double[2]); 
                }

                products[product][0] = price;
                products[product][1] += quality;

                input = Console.ReadLine();
            }

            foreach (var item in products)
            {
                Console.WriteLine($"{item.Key} -> {(item.Value[0] * item.Value[1]):f2}");
            }


        }
    }
}
