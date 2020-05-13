namespace Animals
{
    public class Kitten : Cat
    {
        public const string KittenGender = "female";
        public Kitten(string name, int age) : base(name, age, KittenGender)
        {
            base.Sound = "Meow";
        }
    }
}
