namespace Animals
{
    public class Dog : Animal
    {
        public Dog(string name, int age, string gender) : base(name, age, gender)
        {
            base.Sound = "Woof!";
        }
    }
}
