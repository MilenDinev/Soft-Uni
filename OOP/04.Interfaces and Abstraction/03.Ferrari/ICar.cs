namespace _03.Ferrari
{
    public interface ICar
    {
        public string Driver { get;}
        public string Model { get;}

        string UseBrakes();
        string PushGasPedal();
    }
}
