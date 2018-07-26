namespace P01_BillsPaymentSystem.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;

    public class CreditCard
    {
        public int CreditCardId { get; set; }
        public DateTime ExpirationDate { get; set; }
        public decimal Limit { get; set; }
        public decimal MoneyOwed { get;private set; }
        [NotMapped]
        public decimal LimitLeft => Limit - MoneyOwed;

        public PaymentMethod PaymentMethod { get; set; }

        public void Deposit(decimal Amount)
        {
            if (Amount > 0m)
            {
                this.MoneyOwed -= Amount;
            }
        }

        public void Withdraw(decimal Amount)
        {
            if (this.LimitLeft-Amount>=0)
            {
                this.MoneyOwed += Amount;
            }
        }
    }
}