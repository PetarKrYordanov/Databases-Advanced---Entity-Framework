using System.Collections.Generic;
using System.Xml.Serialization;

namespace ProductShop.Dtos
{
    [XmlType("sold-product")]
    public class SoldProductsCount
    {
        [XmlAttribute("count")]
        public int Count { get; set; }

        [XmlElement("product")]      
        public ProductAttributeDto Products { get; set; } 
    }
}