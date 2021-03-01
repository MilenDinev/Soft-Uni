﻿namespace P03_FootballBetting.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Player
    {
        public int PlayerId { get; set; }

        [Required]
        public string Name { get; set; }
        public int SquadNumber { get; set; }
        public int TeamId { get; set; }
        public int PositionId { get; set; }
        public bool IsInjured { get; set; }
    }
}
