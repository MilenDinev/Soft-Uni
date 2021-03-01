namespace P03_FootballBetting.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    public class Country
    {
        public int CountryId { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
