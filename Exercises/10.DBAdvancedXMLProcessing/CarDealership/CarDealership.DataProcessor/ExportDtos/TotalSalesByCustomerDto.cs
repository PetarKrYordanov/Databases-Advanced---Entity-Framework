using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace CarDealership.DataProcessor.ExportDtos
{
    [XmlType("customer")]
   public class TotalSalesByCustomerDto
    {
        [XmlAttribute("full-name")]
        public string FullName { get; set; }
        [XmlAttribute("bought-cars")]
        public int BoughtCars { get; set; }
        [XmlAttribute("spent-money")]
        public decimal MoneySpent { get; set; }


       
    }
}
