using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace CarDealership.DataProcessor.ExportDtos
{
    [XmlType("sale")]
   public class SalesWithAppliedDiscount
    {
        [XmlElement("car")]
        public CarAttributeDto Car { get; set; } = new CarAttributeDto();
        [XmlElement("customer-name")]
        public string CustomerName { get; set; }
        [XmlElement("discount")]
        public double Discount { get; set; }
        [XmlElement("price")]
        public decimal Price { get; set; }
        [XmlElement("price-with-discount")]
        public decimal DiscountPrice { get; set; }

        [XmlIgnore]
        public bool IsYoungDriver { get; set; }
    }
}
