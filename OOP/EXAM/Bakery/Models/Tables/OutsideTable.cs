namespace Bakery.Models.Tables
{
    using Bakery.Models.Tables.Contracts;
    public class OutsideTable : Table
    {
        private const decimal InitialPricePerPerson = 3.50m;
        public OutsideTable(int tableNumber, int capacity) : base(tableNumber, capacity, InitialPricePerPerson)
        {
        }
    }
}
