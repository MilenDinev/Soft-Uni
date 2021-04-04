using SoftJail.Data.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace SoftJail.DataProcessor.ImportDto
{
    [XmlType("Officer")]
   public class OfficerPrisonerImportModel
    {
        [XmlElement("Name")]
        public string Name { get; set; }
        [XmlElement("Money")]
        public decimal Money { get; set; }
        [EnumDataType(typeof(Position))]
        [XmlElement("Position")]
        public string Position { get; set; }
        [EnumDataType(typeof(Weapon))]
        [XmlElement("Weapon")]
        public string Weapon { get; set; }
        [XmlElement("DepartmentId")]
        public int DepartmentId { get; set; }
        [XmlArray("Prisoners")]
        public PrisonerOfficerImportModel[] Prisoners { get; set; }
    }
}