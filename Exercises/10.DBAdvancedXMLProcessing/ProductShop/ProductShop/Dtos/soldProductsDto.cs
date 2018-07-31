using System.Xml.Serialization;

namespace ProductShop.Dtos
{
    [XmlRoot("sellerDto")]

    public class SoldProductsDto
    {
        [XmlElement("name")]
        public string Name { get; set; }
        [XmlElement("price")]
        public decimal? Price { get; set; }
    }
}