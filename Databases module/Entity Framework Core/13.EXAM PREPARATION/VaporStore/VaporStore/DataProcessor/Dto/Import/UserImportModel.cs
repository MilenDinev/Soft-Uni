using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VaporStore.DataProcessor.Dto.Import
{
    public class UserImportModel
    {
        public UserImportModel()
        {
            this.Cards = new HashSet<CardImportModel>();
        }


        [RegularExpression("([A-Z]{1}[a-z]+ [A-Z]{1}[a-z]+)")]
        [Required]
        public string FullName { get; set; }
        [Required]
        public string Username { get; set; }
        [EmailAddress]
        [Required]
        public string Email { get; set; }

        [Range(3, 103)]
        public int Age { get; set; }
        public ICollection<CardImportModel> Cards { get; set; }
    }
}
