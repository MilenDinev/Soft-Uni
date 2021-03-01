namespace P03_FootballBetting.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Team
    {
        public int TeamId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string LogoUrl { get; set; }

        [Required]
        public string Initials { get; set; }
        public decimal Budget { get; set; }
        public int PrimaryKitColorId { get; set; }
        public Color PrimaryKitColor { get; set; }
        public int SecondaryKitColorId { get; set; }
        public Color SecondaryKitColor { get; set; }
        public int TownId { get; set; }

    }
}
