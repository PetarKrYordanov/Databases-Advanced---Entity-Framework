using System.Xml.Serialization;

namespace ProductShop.Dtos
{
    [XmlType("product")]
    public class ProductAttributeDto
    {
        [XmlAttribute("name")]
        public string Name { get; set; }
        [XmlAttribute("price")]
        public decimal? Price { get; set; }
    }
}