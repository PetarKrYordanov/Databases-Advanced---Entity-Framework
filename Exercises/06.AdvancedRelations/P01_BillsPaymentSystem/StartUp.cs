namespace P01_BillsPaymentSystem
{
    using System;
    using System.Linq;

    using P01_BillsPaymentSystem.Data;
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var context = new BillsPaymentSystemContext();
            using (context)
            {
                //context.Database.EnsureDeleted();
                //context.Database.Migrate();
                // Database.Seed(context);
                Console.WriteLine("Get User Payment method information");
                var user = Database.GetUser(context);
                Database.PrintUserInfo(user);

                Console.WriteLine("Pay bills");
                var userToPay = Database.GetUser(context);
                context.Users.Attach(userToPay);
                decimal amountToWithdraw;
                while (true)
                {
                    Console.Write("Please input sum of bills: ");
                    amountToWithdraw = decimal.Parse(Console.ReadLine());
                    if (amountToWithdraw > 0)
                    {
                        break;
                    }
                    Console.WriteLine("The sum of bill must be a positive");
                }
                Database.PayBills(userToPay, amountToWithdraw);
                context.SaveChanges();
            }

        }


    }
}