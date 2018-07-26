namespace P01_BillsPaymentSystem.Data.Models
{
    public class BankAccount
    {
        public int BankAccountId { get; set; }
        public decimal Balance { get;private set; }
        public string BankName { get; set; }
        public string SwiftCode { get; set; }

        public PaymentMethod PaymentMethod { get; set; }

        public void Deposit(decimal Amount)
        {
            if (Amount>0)
            {
                this.Balance += Amount;
            }
        }

        public void Withdraw(decimal Amount)
        {
            if (this.Balance-Amount>=0m)
            {
                this.Balance -= Amount;
            }
        }
    }
}