namespace ProductShop.Dtos.Import
{
    using System.Xml.Serialization;

    [XmlType("CategoryProduct")]
    public class CategoryProductImportModel
    {
        [XmlElement("CategoryId")]
        public int CategoryId { get; set; }
        [XmlElement("ProductId")]
        public int ProductId { get; set; }
    }
}
