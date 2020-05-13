namespace _05.BorderControl
{
    public class Human : IIdentifiable
    {
        public Human(string name, int age, string id)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
        }

        public string Name { get; private set; }
        public int Age { get; private set; }

        public string Id { get; private set; }
    }
}
