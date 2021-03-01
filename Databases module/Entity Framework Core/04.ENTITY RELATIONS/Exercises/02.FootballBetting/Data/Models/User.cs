namespace P03_FootballBetting.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class User
    {
        public int UserId { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Name { get; set; }
        public decimal Balance { get; set; }
    }
}
