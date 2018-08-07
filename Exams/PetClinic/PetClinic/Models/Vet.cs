using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PetClinic.Models
{
  public  class Vet
    {
        [Key]
        public int Id { get; set; }
        [Required]
    //    [Column("text")]
        [StringLength(40,MinimumLength =3)]
        public string Name { get; set; }

        [Required]
    //    [Column("text")]
        [StringLength(40, MinimumLength = 3)]
        public string Profession  { get; set; }
        [Range(22,65)]
        [Required]
        public int Age { get; set; }

        [Required]
        [RegularExpression(@"(0[0-9]{9})|(\+359[0-9]{9})")]
        public string PhoneNumber { get; set; }

        public ICollection<Procedure> Procedures { get; set; }
    }
}
