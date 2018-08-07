using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetClinic.Models
{
    public class Animal
    {
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "text")]
        [StringLength(20,MinimumLength =3)]
        public string Name { get; set; }

        [Required]
        [Column(TypeName = "text")]
        [StringLength(20, MinimumLength = 3)]
        public string Type { get; set; }
        [Range( 1,int.MaxValue)]
        public int Age { get; set; }


        public string PassportSerialNumber  { get; set; }

        public Passport Passport { get; set; }

        public ICollection<Procedure> Procedures { get; set; } = new List<Procedure>();
    }
}
