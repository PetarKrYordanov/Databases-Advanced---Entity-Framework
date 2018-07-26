namespace P01_BillsPaymentSystem.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using P01_BillsPaymentSystem.Data.Models.Attributes;
    public class PaymentMethod
    {
      
        public int Id { get; set; }
        public int? BankAccountId { get; set; }
        public BankAccount BankAccount { get; set; }
        
        [Xor(nameof(BankAccountId))]
        public int? CreditCardId { get; set; }
        public CreditCard CreditCard { get; set; }

        public PaymentMethodType Type { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }

    }
}