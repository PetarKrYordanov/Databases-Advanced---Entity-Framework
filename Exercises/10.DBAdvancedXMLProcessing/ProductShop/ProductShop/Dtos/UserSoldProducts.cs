using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace ProductShop.Dtos
{
    [XmlType("user")]
   public class UserSoldProducts
    {

        [XmlAttribute(AttributeName = "firstName", Namespace = null)]

        public string FirstName { get; set; }

        [XmlAttribute(AttributeName = "lastName")]
        public string LastName { get; set; }

        [XmlAttribute(AttributeName = "age")]
        public int? Age { get; set; }

        [XmlArray("sold-products")]
        public List<SoldProductsCount> SoldProducts { get; set; } = new List<SoldProductsCount>();

    }
}
