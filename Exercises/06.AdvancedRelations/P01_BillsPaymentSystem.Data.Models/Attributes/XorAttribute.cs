namespace P01_BillsPaymentSystem.Data.Models.Attributes
{
    using System;

    using System.ComponentModel.DataAnnotations;

    [AttributeUsage(AttributeTargets.Property)]
    public class XorAttribute:ValidationAttribute
    {
        private string xorTargetAttribute;

        public XorAttribute(string xorAttribute)
        {
            this.xorTargetAttribute = xorAttribute;
        }

        protected override ValidationResult IsValid(object value,ValidationContext validationContext)
        {
            var targetAttribute = validationContext.ObjectType
                                .GetProperty(xorTargetAttribute)
                                .GetValue(validationContext.ObjectInstance);

            if ((targetAttribute== null && value != null) ||(targetAttribute!=null && value==null))
            {
                return ValidationResult.Success;
            }
            string errorMsg = "One of two properties must be null";

            return new ValidationResult(errorMsg);
        }
    }
}
