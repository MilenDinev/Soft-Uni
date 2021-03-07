namespace _05.GreedyTimes
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Bag
    {
        private readonly List<Item> items;
        private long currentAmount = 0;
        public Bag(long capacity)
        {
            this.items = new List<Item>();
            this.Capacity = capacity;
        }

        public long Capacity { get; set; }

        public IReadOnlyList<Item> Items
        {
            get
            {
                return this.items.AsReadOnly();
            }
        }


        public void AddItem(Item item)
        {
            if ((currentAmount + item.Amount) <= this.Capacity)
            {

                if (item.Type.Length == 3)
                {
                    Item currentItem = new Currency(item.Type, item.Amount);
                    if (items.Any(x => x.Type == item.Type))
                    {
                        items.Single(x => x.Type == item.Type).IncreaseAmount(item.Amount);
                    }

                    else
                    {
                        items.Add(currentItem);
                    }
                    currentAmount += item.Amount;

                }
                else if (item.Type.ToLower().EndsWith("gem"))
                {
                    Item currentItem = new Gem(item.Type, item.Amount);
                    if (items.Any(x => x.Type == item.Type))
                    {
                        items.Single(x => x.Type == item.Type).IncreaseAmount(item.Amount);
                    }

                    else
                    {
                        items.Add(currentItem);
                    }
                    currentAmount += item.Amount;
                }
                else if (item.Type.ToLower() == "gold")
                {
                    Item currentItem = new Gold(item.Type, item.Amount);

                    if (items.Any(x => x.Type == item.Type))
                    {
                        items.Single(x => x.Type == item.Type).IncreaseAmount(item.Amount);
                    }

                    else
                    {
                        items.Add(currentItem);
                    }
                    currentAmount += item.Amount;
                }
     
            }
        }

        public override string ToString()
        {
            var itemsDictionary = items.GroupBy(x => x.GetType().Name).ToDictionary(i => i.Key, a => a.ToList());
            StringBuilder sb = new StringBuilder();
            foreach (var item in itemsDictionary.OrderByDescending(x => x.Value.Sum(i => i.Amount)))
            {
                if (item.Key == "Currency")
                {
                    sb.AppendLine($"<Cash> ${item.Value.Sum(i => i.Amount)}");
                }
                else if (item.Key == "Gem")
                {
                    sb.AppendLine($"<Gem> ${item.Value.Sum(i => i.Amount)}");
                }
                else if (item.Key == "GoldItem")
                {
                    sb.AppendLine($"<Gold> ${item.Value.Sum(i => i.Amount)}");
                }

                foreach (var x in item.Value.OrderByDescending(i => i.Type).ThenBy(i => i.Amount))
                {
                    sb.AppendLine($"##{x.Type} - {x.Amount}");
                }
            }

            return sb.ToString().TrimEnd();
        }
        
    }
}
