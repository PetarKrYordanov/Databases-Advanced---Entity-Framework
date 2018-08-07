using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace PetClinic.DataProcessor.DtoImport
{
    [XmlType("Procedure")]
  public  class ProcedureDto
    {
        [XmlElement("Vet")]
        public string VetName { get; set; }
        [XmlElement("Animal")]
        public string AnimalSerialNumber { get; set; }
        [XmlElement("DateTime")]
        public string DateTime { get; set; }
        [XmlArray("AnimalAids"),XmlArrayItem("AnimalAid")]
        public List<AnimalAidDto> AnimalAids { get; set; } = new List<AnimalAidDto>();
    }
}
