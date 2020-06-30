namespace _03.ShoppingSpree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        static void Main()
        {
            try
            {
                List<Person> people = new List<Person>();
                string consumers = Console.ReadLine();
                string[] consumersArgs = consumers.Split(';', StringSplitOptions.RemoveEmptyEntries);


                for (int i = 0; i < consumersArgs.Length; i++)
                {
                    string[] peopleInfo = consumersArgs[i].Split('=');
                    string name = peopleInfo[0];
                    decimal money = decimal.Parse(peopleInfo[1]);
                    Person person = new Person(name, money);
                    people.Add(person);
                }

                List<Product> products = new List<Product>();
                string productsInput = Console.ReadLine();
                string[] productssArgs = productsInput.Split(';', StringSplitOptions.RemoveEmptyEntries);

                for (int i = 0; i < productssArgs.Length; i++)
                {
                    string[] productInfo = productssArgs[i].Split('=');
                    string name = productInfo[0];
                    decimal cost = decimal.Parse(productInfo[1]);
                    Product product = new Product(name, cost);
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
