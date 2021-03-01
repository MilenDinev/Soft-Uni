namespace P03_FootballBetting.Data.Models
{
    using System.ComponentModel.DataAnnotations;
   public class Position
    {
        public int PositionId { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
