namespace _01.RawData
{
   public class Engine
    {
        public Engine(int engineSpeed, int enginePower)
        {
            this.Speed = engineSpeed;
            this.Power = enginePower;
        }

        public int Speed { get; private set; }

        public int Power { get; private set; }
    }
}
