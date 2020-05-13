using _03.WildFarm.Foods;

namespace _03.WildFarm.Factories
{
    public static class FoodFactory
    {
        public static Food Create(params string[] foodParams)
        {
            string type = foodParams[0];
            int quantity = int.Parse(foodParams[1]);


            if (type == nameof(Vegetable))
            {

                return new Vegetable(quantity);
            }

            else if (type == nameof(Meat))
            {

                return new Meat(quantity);
            }

            else if (type == nameof(Fruit))
            {

                return new Fruit(quantity);
            }

            else if (type == nameof(Seeds))
            {

                return new Seeds(quantity);
            }

            return null;
        }
    }
}
