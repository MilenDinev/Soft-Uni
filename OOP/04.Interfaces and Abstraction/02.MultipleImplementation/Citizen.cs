namespace PersonInfo
{
    public class Citizen : IPerson
    {
        public Citizen(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public Citizen(string name, int age, string id, string birthdate) : this(name, age)
        {
            this.Id = id;
            this.Birthdate = birthdate;
        }

        public string Name { get; private set; }

        public int Age { get; private set;}

        public string Id { get; private set; }

        public string Birthdate { get; private set; }
    }
}
