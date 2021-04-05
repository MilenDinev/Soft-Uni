using System.ComponentModel.DataAnnotations;
using VaporStore.Data.Models.Enums;

namespace VaporStore.DataProcessor.Dto.Import
{
    public class CardImportModel
    {
        [RegularExpression(@"^[\d]{4} [\d]{4} [\d]{4} [\d]{4}$")]
        [Required]
        public string Number { get; set; }
        [RegularExpression(@"^[\d]{3}$")]
        [Required]
        public string Cvc { get; set; }

        [EnumDataType(typeof(CardType))]
        [Required]
        public string Type { get; set; }
    }
}