namespace _07.FoodShortage
{
    public class Robot : IIdentifiable
    {
        public Robot(string name, string id)
        {
            this.Name = name;
            this.Id = id;
        }

        public string Name { get; private set; }
        public string Id { get; private set; }
    }
}
