
using System.ComponentModel.DataAnnotations;


namespace SoftJail.DataProcessor.ImportDto
{
   public class MailImportModel
    {
        [Required]
        public string Description { get; set; }
        [Required]
        public string Sender { get; set; }
        [RegularExpression("^([A-Za-z0-9\\s]+?)(\\sstr\\.)$")]
        public string Address { get; set; }
    }
}
