namespace _03.ShoppingSpree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Person
    {
        private readonly List<Product> bagOfProducts;
        private string name;
        private decimal money;

        public Person(string name, decimal money)
        {
            this.Name = name;
            this.Money = money;
            this.bagOfProducts = new List<Product>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be empty");
                }

                this.name = value;
            }
        }

        public decimal Money
        {
            get
            {
                return this.money;
            }

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }

                this.money = value;
            }
        }

        public string AddProduct(Product product)
        {
            if (this.Money < product.Cost)
            {
                return $"{this.Name} can't afford {product.Name}";
            }

            this.Money -= product.Cost;
            this.bagOfProducts.Add(product);
            return $"{this.Name} bought {product.Name}";
        }

        public override string ToString()
        {
            if (this.bagOfProducts.Count == 0)
            {
                return $"{this.Name} - Nothing bought";
            }

            return $"{this.Name} - {string.Join(", ", this.bagOfProducts.Select(p => p.Name))}";
        }
    }
}
