using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace PetClinic.DataProcessor.DtoExport
{
    [XmlType("Procedure")]
    public class AllProcedureDto
    {
        [XmlElement("Passport")]
        public string Passport { get; set; }
        [XmlElement("OwnerNumber")]
        public string OwnerNumber { get; set; }
        [XmlElement("DateTime")]
        public string DateTime { get; set; }
        [XmlArray("AnimalAids"), XmlArrayItem("AnimalAid")]
        public List<AnimaAidsDto> AnimalAids { get; set; } = new List<AnimaAidsDto>();

        [XmlElement("TotalPrice")]
        public decimal TotalPrice { get; set; }
    }
}
