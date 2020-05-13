namespace _06.BirthdayCelebrations
{
    public class Pet : IBirthday
    {
        public Pet(string name, string birthday)
        {
            this.Name = name;
            this.Birthday = birthday;
        }

        public string Name { get; private set; }
        public string Birthday { get; private set; }
    }
}
