using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace ProductShop.Dtos
{
    [XmlRoot("users")]
    public class UsersDto
    {
        [XmlAttribute("count")]
        public int Count { get; set; }
        [XmlElement("user")]
        public SoldProductsCount UserSoldProducts { get; set; } 
    }
}
