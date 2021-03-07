namespace Animals
{
    using System;
    using System.Text;

    public class Animal
    {
        private string name;
        private int age;
        private string gender;
        private string sound;

        public Animal(string name, int age, string gender)
        {
            this.Name = name;
            this.Age = age;
            this.Gender = gender;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (value != null)
                {
                    this.name = value;
                }

                else
                {
                    throw new Exception("Invalid input!");
                }
            }
        }
        public int Age
        {
            get
            {
                return this.age;
            }
            set
            {
                if (value > 0)
                {
                    this.age = value;
                }
                else
                {
                    throw new Exception("Invalid input!");
                }
            }
        }
        public string Gender
        {
            get
            {
                return this.gender;
            }
            set
            {
                if (value != null)
                {
                    this.gender = value;
                }
                else
                {
                    throw new Exception("Invalid input!");
                }
            }
        }

        protected virtual string Sound
        {
            get
            {
                return this.sound;
            }

            set
            {
                if (value != null)
                {
                    this.sound = value;
                }

                else
                {
                    throw new Exception("Invalid input!");
                }
            }
        }

        public string ProduceSound()
        {

            return this.sound;
        }


        public override string ToString()
        {
            StringBuilder animalInfo = new StringBuilder();
            animalInfo.AppendLine($"{this.GetType().Name}");
            animalInfo.AppendLine($"{this.Name} {this.Age} {this.Gender}");
            animalInfo.AppendLine($"{ProduceSound()}");

            return animalInfo.ToString().TrimEnd();
        }

    }
}
