using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _01.RawData
{
    public class Car
    {
        public string Model { get; private set; }

        public Engine Engine { get; set; }
        public Cargo Cargo { get; set; }
        public Tire[] Tires { get; private set; }

        public Car(string model, Engine engine, Cargo cargo, Tire[] tires)
        {
            this.Model = model;
            this.Engine = engine;
            this.Cargo = cargo;
            this.Tires = tires;
        }


        public void GetTires(Tire[] tires, string[] parameters)

        {
            int tiresCounter = 0;

            for (int startIndex = 5; startIndex < parameters.Length; startIndex += 2)
            {
                double tirePressure = double.Parse(parameters[startIndex]);
                int tireAge = int.Parse(parameters[startIndex + 1]);

                Tire tire = new Tire(tirePressure, tireAge);

                tires[tiresCounter] = tire;
                tiresCounter++;
            }
        }

    }
}
