
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using VaporStore.Data.Models.Enums;
namespace VaporStore.Data.Models
{
    public class Card
    {
        public Card()
        {
            this.Purchases = new HashSet<Purchase>();
        }
        public int Id { get; set; }

        //[RegularExpression(@"^[\d]{4} [\d]{4} [\d]{4} [\d]{4}$")]
        [Required]
        public string Number { get; set; }

        //[RegularExpression(@"^[\d]{3}$")]

        [Required]
        public string Cvc { get; set; }

        public CardType Type { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public ICollection<Purchase> Purchases { get; set; }
    }
}

