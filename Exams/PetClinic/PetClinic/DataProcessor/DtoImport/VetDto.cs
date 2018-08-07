﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Serialization;

namespace PetClinic.DataProcessor.DtoImport
{
    [XmlType("Vet")]
   public class VetDto
    {
        [XmlElement("Name")]
        [Required]
        [StringLength(40, MinimumLength = 3)]
        public string Name { get; set; }

        [XmlElement("Profession")]
        [Required]
        [StringLength(40, MinimumLength = 3)]
        public string Profession { get; set; }

        [XmlElement("Age")]
        [Required]
        [Range(22, 65)]
        public int Age { get; set; }

        [XmlElement("PhoneNumber")]
        [Required]
        [RegularExpression(@"(0[0-9]{9})|(\+359[0-9]{9})")]
        public string PhoneNumber { get; set; }


    }
}
