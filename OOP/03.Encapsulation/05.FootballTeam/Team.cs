namespace _05.FootballTeam
{
    using System.Collections.Generic;
    using System.Linq;

    public class Team
    {
        readonly List<Player> players;

        public Team(string name)
        {
            this.Name = name;
            this.players = new List<Player>();
        }

        public string Name { get; private set; }

        public double Rating()
        {
            return (int)this.players.Select(x => x.Skill()).Sum() / this.players.Count();
        }
    }
}
