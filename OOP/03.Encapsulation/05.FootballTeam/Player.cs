namespace _05.FootballTeam
{
    using System;

    public class Player
    {
        private string name;
        private int endurance;
        private int sprint;
        private int dribble;
        private int passing;
        private int shooting;

        public Player(string name, int endurance, int sprint, int dribble, int passing, int shooting)
        {
            this.Name = name;
            this.Endurance = endurance;
            this.Sprint = sprint;
            this.Dribble = dribble;
            this.Passing = passing;
            this.Shooting = shooting;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("A name should not be empty.");
                }
                this.name = value;
            }
        }

        public int Endurance
        {
            get
            {
                return this.endurance;
            }
            private set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException($"{this.GetType().Name} should be between 0 and 100.");
                }
                this.endurance = value;
            }
        }

        public int Sprint
        {
            get
            {
                return this.sprint;
            }
            private set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException($"{this.GetType().Name} should be between 0 and 100.");
                }

                this.sprint = value;
            }
        }

        public int Dribble
        {
            get
            {
                return this.dribble;
            }
            private set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException($"{this.GetType().Name} should be between 0 and 100.");
                }

                this.dribble = value;
            }
        }

        public int Passing
        {
            get
            {
                return this.passing;
            }
            private set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException($"{this.GetType().Name} should be between 0 and 100.");
                }

                this.passing = value;
            }
        }

        public int Shooting
        {
            get
            {
                return this.shooting;
            }
            private set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException($"{this.GetType().Name} should be between 0 and 100.");
                }

                this.shooting = value;
            }
        }

        public int Skill()
        {
            return (this.Endurance + this.Sprint + this.Dribble + this.Passing + this.Shooting) / 5;
        }

    }
}
