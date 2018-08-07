using System;
using System.ComponentModel.DataAnnotations;

namespace PetClinic.DataProcessor.DtoImport
{
    public class PassportDto
    {
        [StringLength(10,MinimumLength =10)]
        [Required]
        [RegularExpression(@"[A-Za-z]{7}[0-9]{3}")]
        public string SerialNumber { get; set; }
        [Required]
        [StringLength(30, MinimumLength = 3)]
        public string OwnerName { get; set; }

        [Required]
        [RegularExpression(@"(?:(0[0-9]{9})|(\+359[0-9]{9}))")]
        public string OwnerPhoneNumber { get; set; }
      
        [Required]
        public string RegistrationDate { get; set; }
    }
}