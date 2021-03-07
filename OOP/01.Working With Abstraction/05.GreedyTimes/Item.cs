namespace _05.GreedyTimes
{
    public class Item
    {
        public Item(string type, long amount)
        {
            this.Type = type;
            this.Amount = amount;
        }
        public string Type { get; set; }
        public long Amount { get; set; }

        public void IncreaseAmount(long amount)
        {
            this.Amount += amount;
        }
    }
}
