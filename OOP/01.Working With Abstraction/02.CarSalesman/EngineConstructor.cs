namespace _02.CarSalesman
{
    using System;
    using System.Collections.Generic;

    public class EngineConstructor
    {
        readonly List<Engine> engines = new List<Engine>();

        public List<Engine> Build(int engineCount)
        {
            for (int i = 0; i < engineCount; i++)
            {
                string[] inputArgs = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string model = inputArgs[0];
                int power = int.Parse(inputArgs[1]);

                if (inputArgs.Length == 3 && int.TryParse(inputArgs[2], out int displacement))
                {
                    this.engines.Add(new Engine(model, power, displacement));
                }
                else if (inputArgs.Length == 3)
                {
                    string efficiency = inputArgs[2];
                    this.engines.Add(new Engine(model, power, efficiency));
                }
                else if (inputArgs.Length == 4)
                {
                    string efficiency = inputArgs[3];
                    this.engines.Add(new Engine(model, power, int.Parse(inputArgs[2]), efficiency));
                }
                else
                {
                    this.engines.Add(new Engine(model, power));
                }
            }

            return this.engines;
        }
    }
}
