
using System.Xml.Serialization;

namespace ProductShop
{
    [XmlType("product")]
    public  class ProductDto
    {
        [XmlElement(ElementName ="name")]
        public string Name { get; set; }

        [XmlElement(ElementName ="price")]
        public decimal Price { get; set; }
    }
}
