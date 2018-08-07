using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetClinic.Models
{
    public class Passport
    {
    
        [RegularExpression(@"[0-9]{7}[a-zA-Z]{3}")]
        public string SerialNumber { get; set; }

        [Required]
        public Animal Animal { get; set; }
        [Required]
        [RegularExpression(@"([0-9]{10})|(\+359[0-9]{9})")]
        public string OwnerPhoneNumber { get; set; }
        [Required]
[Column("text")]
        [StringLength(30,MinimumLength =3)]
        public string OwnerName { get; set; }
        [Required]
        public DateTime RegistrationDate { get; set; }
    }
}