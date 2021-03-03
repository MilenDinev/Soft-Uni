namespace Bakery.Models.Tables.Contracts
{
    using Bakery.Models.BakedFoods;
    using Bakery.Models.BakedFoods.Contracts;
    using Bakery.Models.Drinks;
    using Bakery.Models.Drinks.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public abstract class Table : ITable
    {
        private List<IBakedFood> foodOrders;
        private List<IDrink> drinkOrders;
        private int capacity;
        private int numberOfPeople;

        public Table(int tableNumber, int capacity, decimal pricePerPerson)
        {
            foodOrders = new List<IBakedFood>();
            drinkOrders = new List<IDrink>();

            this.TableNumber = tableNumber;
            this.Capacity = capacity;
            this.PricePerPerson = pricePerPerson;
        }


        //public IReadOnlyCollection<IBakedFood> FoodOrders
        //{
        //    get
        //    {
        //        return this.foodOrders.AsReadOnly();
        //    }
        //}

        //public IReadOnlyCollection<IDrink> DrinkOrders
        //{
        //    get
        //    {
        //        return this.drinkOrders.AsReadOnly();
        //    }
        //}

        public int TableNumber { get; set; }

        public int Capacity
        {
            get
            {
                return this.capacity;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Capacity has to be greater than 0");
                }

                this.capacity = value;
            }


        }

        public int NumberOfPeople
        {
            get
            {
                return this.numberOfPeople;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Cannot place zero or less people!");
                }

                this.numberOfPeople = value;
            }
        }

        public decimal PricePerPerson { get; private set; }

        public bool IsReserved { get; private set; }

        public decimal Price
        {
            get
            {
                return GetBill();
            }
        }

        public void Clear()
        {

            this.foodOrders = new List<IBakedFood>();

            this.drinkOrders = new List<IDrink>();


            this.NumberOfPeople = 0;
            this.IsReserved = false;
        }

        public decimal GetBill()
        {
            decimal totalBill = 0;

            for (int i = 0; i < this.NumberOfPeople; i++)
            {
                totalBill += this.PricePerPerson;
            }
            foreach (var food in this.foodOrders)
            {
                totalBill += food.Price;
            }
            foreach (var drink in drinkOrders)
            {
                totalBill += drink.Price;
            }


            return totalBill;
        }

        public string GetFreeTableInfo()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Table: {this.TableNumber}");
            sb.AppendLine($"Type: {this.GetType().Name}");
            sb.AppendLine($"Capacity: {this.Capacity}");
            sb.AppendLine($"Price per Person: {this.PricePerPerson}");

            return sb.ToString().TrimEnd();
        }

        public void OrderDrink(IDrink drink)
        {
            drinkOrders.Add(drink);
        }

        public void OrderFood(IBakedFood food)
        {
            foodOrders.Add(food);
        }

        public void Reserve(int numberOfPeople)
        {
            this.NumberOfPeople = numberOfPeople;

            if (this.Capacity >= numberOfPeople)
            {
                this.IsReserved = true;
            }
        }

    }
}
