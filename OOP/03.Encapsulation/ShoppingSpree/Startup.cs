using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace ShoppingSpree
{
    public class Startup
    {
        public static void Main(string[] args)
        {

            try
            {
                List<Person> people = new List<Person>();

                string[] peopleArgs = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);


                for (int i = 0; i < peopleArgs.Length; i++)
                {
                    string[] currentPersonInfo = peopleArgs[i].Split("=");
                    string personName = currentPersonInfo[0];
                    decimal personMoney = decimal.Parse(currentPersonInfo[1]);

                    Person person = new Person(personName, personMoney);
                    people.Add(person);

                }

                List<Product> products = new List<Product>();
                string[] productsArgs = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);


                for (int i = 0; i < productsArgs.Length; i++)
                {
                    string[] currentProductInfo = productsArgs[i].Split("=");
                    string productName = currentProductInfo[0];
                    decimal productCost = decimal.Parse(currentProductInfo[1]);

                    Product product = new Product(productName, productCost);
                    products.Add(product);
                }



                string command = Console.ReadLine();

                while (command != "END")
                {
                    string[] commandArgs = command.Split();
                    string name = commandArgs[0];
                    string productName = commandArgs[1];

                    Person person = people.FirstOrDefault(x => x.Name == name);
                    Product product = products.FirstOrDefault(x => x.Name == productName);

                    Console.WriteLine(person.AddProduct(product));
                    command = Console.ReadLine();
                }

                //people.ForEach(p => Console.WriteLine(p));

                foreach (var person in people)
                {
                    Console.WriteLine(person);
                }

            }
            catch (ArgumentException ae)
            {

                Console.WriteLine(ae.Message);
            }

        }
    }
}
