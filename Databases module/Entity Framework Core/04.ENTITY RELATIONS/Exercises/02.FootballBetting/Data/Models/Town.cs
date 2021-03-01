namespace P03_FootballBetting.Data.Models
{
    using System.ComponentModel.DataAnnotations;
   public class Town
    {
        public int TownId { get; set; }

        [Required]
        public string Name { get; set; }
        public int CountryId { get; set; }
    }
}
