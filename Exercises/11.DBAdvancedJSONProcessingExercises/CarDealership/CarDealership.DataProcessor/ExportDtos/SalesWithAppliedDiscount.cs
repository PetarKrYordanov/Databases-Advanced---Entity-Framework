using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace CarDealership.DataProcessor.ExportDtos
{
   public class SalesWithAppliedDiscount
    {
        public CarAttributeDto Car { get; set; } = new CarAttributeDto();
        public string customerName { get; set; }
        public decimal discount { get; set; }
        public decimal price { get; set; }
        public decimal priceWithDiscount { get; set; }

    }
}
