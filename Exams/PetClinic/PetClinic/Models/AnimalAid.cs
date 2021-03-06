﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PetClinic.Models
{
   public class AnimalAid
    {
        public int Id { get; set; }
        [Required]
        [StringLength(30,MinimumLength =3)]
        public string Name { get; set; }
        [Range(typeof(Decimal),"0.01", "79228162514264337593543950335")]
        [Required]
        public decimal Price { get; set; }

        public ICollection<ProcedureAnimalAid> AnimalAidProcedures { get; set; } = new List<ProcedureAnimalAid>();

    }
}
