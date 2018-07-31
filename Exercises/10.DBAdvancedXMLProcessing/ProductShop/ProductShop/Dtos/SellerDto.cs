using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace ProductShop.Dtos
{
    [XmlType("user")]
    public class SellerDto
    {
        [XmlAttribute("first-name")]
        public string FirstName { get; set; }
        [XmlAttribute("last-name")]
        public string LastName { get; set; }
        [XmlArray("sold_products"), XmlArrayItem("product")]
        public List<SoldProductsDto> SoldProducts { get; set; } = new List<SoldProductsDto>();
    }
}
