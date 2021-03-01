namespace P03_FootballBetting.Data.Models
{
    using System;

    public class Game
    {
        public int GameId { get; set; }
        public int HomeTeamId { get; set; }
        public int AwayTeamId { get; set; }
        public int HomeTeamGoals { get; set; }
        public int AwayTeamGoals { get; set; }
        public DateTime DateTime { get; set; }
        public decimal HomeTeamBetRate { get; set; }
        public decimal AwayTeamBetRate { get; set; }
        public decimal DrawBetRate { get; set; }
        public int Result { get; set; }
    }
}
