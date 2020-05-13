namespace _03.WildFarm.Factories
{
    using Animals;
    using Animals.Birds;
    using Animals.Mammals;
    using Animals.Mammals.Felines;
    public static class AnimalFactory
    {
        public static Animal Create(params string[] animalParams)
        {
            string animalType = animalParams[0];
            string animalName = animalParams[1];
            double animalWeight = double.Parse(animalParams[2]);

            if (animalType == nameof(Cat))
            {
                string livingRegion = animalParams[3];
                string breed = animalParams[4];

                Animal cat = new Cat(animalName, animalWeight, livingRegion, breed);

                return cat;
            }

            else if (animalType == nameof(Tiger))
            {
                string livingRegion = animalParams[3];
                string breed = animalParams[4];

                Animal tiger = new Tiger(animalName, animalWeight, livingRegion, breed);

                return tiger;
            }

            else if (animalType == nameof(Owl))
            {
                double wingSize = double.Parse(animalParams[3]);

                Animal owl = new Owl(animalName, animalWeight, wingSize);

                return owl;
            }

            else if (animalType == nameof(Hen))
            {
                double wingSize = double.Parse(animalParams[3]);

                Animal hen = new Hen(animalName, animalWeight, wingSize);

                return hen;
            }

            else if (animalType == nameof(Dog))
            {
                string livingRegion = animalParams[3];

                Animal dog = new Dog(animalName, animalWeight, livingRegion);

                return dog;
            }

            else if (animalType == nameof(Mouse))
            {
                string livingRegion = animalParams[3];

                Animal mouse = new Mouse(animalName, animalWeight, livingRegion);

                return mouse;
            }

            return null;
        }
    }
}
