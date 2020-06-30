﻿namespace _02.CarSalesman
{
    using System.Text;

    public class Car
    {
        public Car(string model, Engine engine)
        {
            this.Model = model;
            this.Engine = engine;
            this.Weight = -1;
            this.Color = "n/a";
        }

        public Car(string model, Engine engine, int weight) : this(model, engine)
        {
            this.Weight = weight;
            this.Color = "n/a";
        }

        public Car(string model, Engine engine, string color) : this(model, engine)
        {
            this.Weight = -1;
            this.Color = color;
        }

        public Car(string model, Engine engine, int weight, string color)
        {
            this.Model = model;
            this.Engine = engine;
            this.Weight = weight;
            this.Color = color;
        }

        private const string Offset = "  ";

        public string Model { get; private set; }

        public Engine Engine { get; private set; }

        public int Weight { get; private set; }

        public string Color { get; private set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("{0}:\n", this.Model);
            sb.Append(this.Engine.ToString());
            sb.AppendFormat("{0}Weight: {1}\n", Offset, this.Weight == -1 ? "n/a" : this.Weight.ToString());
            sb.AppendFormat("{0}Color: {1}", Offset, this.Color);

            return sb.ToString();
        }
    }
}
