namespace P03_FootballBetting.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    public class Color
    {
        public Color()
        {
            Teams = new HashSet<Team>();
        }

        public int ColorId { get; set; }

        [Required]
        public string Name { get; set; }

        public ICollection<Team> Teams { get; set; }
    }
}
