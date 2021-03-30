namespace ProductShop.Dtos.Import
{
    using System.Xml.Serialization;

    [XmlType("Category")]
    public class CategoryImportModel
    {
        [XmlElement("name")]
        public string Name { get; set; }

    }
}
