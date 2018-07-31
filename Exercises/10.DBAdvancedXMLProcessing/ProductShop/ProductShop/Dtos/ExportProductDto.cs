using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace ProductShop.Dtos
{
    [XmlType("product")]
   public class ExportProductDto
    {

        [XmlAttribute("name")]
        public string Name{ get; set; }
        [XmlAttribute("price")]
        public string Price { get; set; }
        [XmlAttribute("buyer")]
        public string Buyer { get; set; }
    }
}
