namespace Bakery.Core
{
    using Bakery.Core.Contracts;
    using Bakery.Models.BakedFoods;
    using Bakery.Models.BakedFoods.Contracts;
    using Bakery.Models.Drinks;
    using Bakery.Models.Drinks.Contracts;
    using Bakery.Models.Tables;
    using Bakery.Models.Tables.Contracts;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Runtime.InteropServices;
    using System.Text;

    public class Controller : IController
    {
        private List<IBakedFood> listOfFood;
        private List<IDrink> listOfDrinks;
        private List<ITable> tables;
        private decimal totalBill = 0;


        public Controller()
        {
            listOfFood = new List<IBakedFood>();
            listOfDrinks = new List<IDrink>();
            tables = new List<ITable>();
        }
        public string AddDrink(string type, string name, int portion, string brand)
        {
            if (type == "Tea")
            {
                listOfDrinks.Add(new Tea(name, portion, brand));
                return $"Added {name} ({brand}) to the drink menu";
            }

            if (type == "Water")
            {
                listOfDrinks.Add(new Water(name, portion, brand));
                return $"Added {name} ({brand}) to the drink menu";
            }

            return $"Something horrible happen";
        }

        public string AddFood(string type, string name, decimal price)
        {
            if (type == "Bread")
            {
                listOfFood.Add(new Bread(name, price));
                return $"Added {name} ({type}) to the menu";
            }

            if (type == "Cake")
            {
                listOfFood.Add(new Cake(name, price));
                return $"Added {name} ({type}) to the menu";
            }

            return $"Something horrible happen";
        }

        public string AddTable(string type, int tableNumber, int capacity)
        {
            if (type == "InsideTable")
            {
                tables.Add(new InsideTable(tableNumber, capacity));
                return $"Added table number {tableNumber} in the bakery";
            }

            if (type == "OutsideTable")
            {
                tables.Add(new OutsideTable(tableNumber, capacity));
                return $"Added table number {tableNumber} in the bakery";
            }

            return $"Something horrible happen";
        }

        public string GetFreeTablesInfo()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var table in tables)
            {
                if (table.IsReserved == false)
                {
                    sb.AppendLine(table.GetFreeTableInfo());
                }
            }

            return sb.ToString().TrimEnd();
        }

        public string GetTotalIncome()
        {

            return $"Total income: {totalBill:f2}";
        }

        public string LeaveTable(int tableNumber)
        {
            var table = tables.FirstOrDefault(x => x.TableNumber == tableNumber);
            if (table == null)
            {
                return "Something really bad happen";
            }
            decimal bill = table.GetBill();
            totalBill += bill;
            table.Clear();

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Table: {tableNumber}");
            sb.AppendLine($"Bill: {bill:f2}");

            return sb.ToString().TrimEnd();

        }

        public string OrderDrink(int tableNumber, string drinkName, string drinkBrand)
        {
            var table = tables.FirstOrDefault(x => x.TableNumber == tableNumber);

            if (table == null)
            {
                return $"Could not find table {tableNumber}";
            }

            var drink = listOfDrinks.FirstOrDefault(x => x.Name == drinkName && x.Brand == drinkBrand);

            if (drink == null)
            {
                return $"There is no {drinkName} {drinkBrand} available";
            }

            table.OrderDrink(drink);

            return $"Table {tableNumber} ordered {drinkName} {drinkBrand}";
        }

        public string OrderFood(int tableNumber, string foodName)
        {
            var table = tables.FirstOrDefault(x => x.TableNumber == tableNumber);

            if (table == null)
            {
                return $"Could not find table {tableNumber}";
            }

            var food = listOfFood.FirstOrDefault(x => x.Name == foodName);

            if (food == null)
            {
                return $"No {foodName} in the menu";
            }

            table.OrderFood(food);

            return $"Table {tableNumber} ordered {foodName}";
        }

        public string ReserveTable(int numberOfPeople)
        {
            var table = tables.FirstOrDefault(x => x.IsReserved == false && x.Capacity >= numberOfPeople);
            if (table == null)
            {
                return $"No available table for {numberOfPeople} people";
            }

            else if (table != null)
            {
                table.Reserve(numberOfPeople);
                return $"Table {table.TableNumber} has been reserved for {numberOfPeople} people";
            }

            return "Something horrible happen";
        }
    }
}
