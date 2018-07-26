namespace P01_BillsPaymentSystem
{
    using System;
    using System.Linq;

    using P01_BillsPaymentSystem.Data;
    using P01_BillsPaymentSystem.Data.Models;

    using Microsoft.EntityFrameworkCore;
    public class Database
    {
        public static void PayBills(User user, decimal amount)
        {
            var bankAccountTotals = user.PaymentMethods
                      .Where(x => x.BankAccount != null)
                      .Sum(x => x.BankAccount.Balance);

            var creditCardTotals = user.PaymentMethods
                 .Where(x => x.CreditCard != null)
                 .Sum(x => x.CreditCard.LimitLeft);
            var totalMoney = bankAccountTotals + creditCardTotals;

            if (totalMoney >= amount)
            {
                amount = WithdrawFromBankAccount(user, amount);
                if (amount ==0m)
                {
                    return;
                }
                amount = WithdrawFromCreditCards(user, amount);
                Console.WriteLine($"Successfully paid sum from user: {user.FirstName} {user.LastName}");
            }
            else
            {
                Console.WriteLine("Insufficient funds!!!");
            }
        }

        private static decimal WithdrawFromCreditCards(User user, decimal amount)
        {
            var creditCards = user.PaymentMethods
                     .Where(x => x.CreditCard != null)
                     .Select(x => x.CreditCard).OrderBy(x => x.CreditCardId)
                     .ToArray();

            foreach (var cc in creditCards)
            {
                if (amount>cc.LimitLeft)
                {
                    cc.Withdraw(cc.LimitLeft);
                    amount -= cc.LimitLeft;
                }
                else
                {
                    cc.Withdraw(amount);
                    amount = 0m;
                   
                }
                if (amount==0)
                {
                    return 0m;
                }
            }
            return 0m;

        }

        private static decimal WithdrawFromBankAccount(User user, decimal amount)
        {
            var bankAccounts = user.PaymentMethods
                      .Where(x => x.BankAccount != null)
                      .Select(x => x.BankAccount)
                      .OrderBy(x => x.BankAccountId)
                      .ToArray();

            foreach (var bankAccount in bankAccounts)
            {
                if (bankAccount.Balance >= amount)
                {
                    bankAccount.Withdraw(amount);
                    return 0m;
                }
                else
                {
                    decimal money = bankAccount.Balance;
                    bankAccount.Withdraw(money);
                    amount -= money;
                }
                if (amount == 0)
                {
                    return 0m;
                }
            }
            return amount;
        }
        public static User GetUser(BillsPaymentSystemContext context)
        {
            Console.Write("Enter user ID: ");
            var userId = int.Parse(Console.ReadLine());

            User user = null;

            while (true)
            {
                user = context.Users
                .Where(x => x.UserId == userId)
                          .Include(e => e.PaymentMethods)
                          .ThenInclude(e => e.BankAccount)
                          .Include(x => x.PaymentMethods)
                          .ThenInclude(x => x.CreditCard)
                          .FirstOrDefault();

                if (user == null)
                {
                    Console.Write($"User with id {userId} not found!");
                    Console.Write("Enter user ID: ");
                    userId = int.Parse(Console.ReadLine());
                    continue;
                }
                break;
            }
            return user;

        }

        internal static void PrintUserInfo(User user)
        {
            Console.WriteLine($"User: {user.FirstName} {user.LastName}");

            var bankAcounts = user.PaymentMethods
                      .Where(x => x.BankAccount != null)
                      .Select(x => x.BankAccount)
                      .ToArray();

            Console.WriteLine("Bank Accounts:");
            foreach (var ba in bankAcounts)
            {
                Console.WriteLine($"-- ID: {ba.BankAccountId}");
                Console.WriteLine($"--- Balance: {ba.Balance:f2}");
                Console.WriteLine($"--- Bank: {ba.BankName}");
                Console.WriteLine($"--- SWIFT: {ba.SwiftCode}");
            }

            var creditCards = user.PaymentMethods
                             .Where(x => x.CreditCard != null)
                             .Select(x => x.CreditCard)
                             .ToArray();

            Console.WriteLine("Credit Cards:");
            foreach (var cc in creditCards)
            {
                Console.WriteLine($"-- ID: {cc.CreditCardId}");
                Console.WriteLine($"--- Limit: {cc.Limit:f2}");
                Console.WriteLine($"--- Money Owed: {cc.MoneyOwed:f2}");
                Console.WriteLine($"--- Limit Left: {cc.LimitLeft:f2}");
                Console.WriteLine($"--- Expiration Date: {cc.ExpirationDate.Year}/{cc.ExpirationDate.Month:d2}");
            }
        }

      //  public static void Seed(BillsPaymentSystemContext context)
      //  {
      //      var user = new User()
      //      {
      //          FirstName = "guy",
      //          LastName = "gilbert",
      //          Email = "guygilbert",
      //          Password = "123"
      //      };

      //      var creditcard = new CreditCard()
      //      {
      //          ExpirationDate = new DateTime(2020, 03, 1),
      //          Limit = 800m,
      //          MoneyOwed = 100m
      //      };

      //      var bankAccounts = new[] {
      //                new BankAccount()
      //            {
      //                Balance = 2000m,
      //                BankName = "Unicredit Bulbank",
      //                SwiftCode = "UNCRBGSF",
      //            },
      //                new BankAccount()
      //            {
      //                    Balance =1000m,
      //                    BankName = "First Investment Bank",
      //                    SwiftCode="FINVBGSF"
      //            }}
      //      .ToList();

      //      var paymentMethods = new[]
      //{
      //                      new PaymentMethod
      //                      {
      //                          User=user,
      //                          BankAccount=bankAccounts[0],
      //                          Type=PaymentMethodType.BankAccount
      //                      },
      //                       new PaymentMethod
      //                      {
      //                         User = user,
      //                         BankAccount=bankAccounts[1],
      //                         Type = PaymentMethodType.BankAccount
      //                      },
      //                      new PaymentMethod
      //                      {
      //                          User=user,
      //                          CreditCard=creditcard,
      //                          BankAccount = bankAccounts[1],
      //                          Type=PaymentMethodType.CreditCard
      //                      }
      //                  }
      //.ToList();


      //      //context.Users.Add(user);
      //      //context.CreditCards.Add(creditcard);
      //      //context.BankAccounts.AddRange(bankAccounts);
      //      context.PaymentMethods.AddRange(paymentMethods);
      //      context.SaveChanges();
      //  }
    }

}