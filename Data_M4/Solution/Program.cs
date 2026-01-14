using System;

namespace BankApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Bank App!");

            // TASK 5: Display Basic Bank Account Information
            Customer customer = new Customer
            {
                Name = "John Doe",
                CustomerId = "C12345",
                Address = "123 Main St"
            };

            BankAccount account = new BankAccount(12345678, 500, customer, AccountType.Checking);
            Console.WriteLine(account.DisplayAccountInfo());

            // TASK 6: Perform Transactions
            account.Deposit(200, "Paycheck");
            Console.WriteLine("After deposit:");
            Console.WriteLine(account.DisplayAccountInfo());

            bool success = account.Withdraw(100, "Groceries");
            Console.WriteLine(success ? "Withdrawal successful." : "Withdrawal failed.");
            Console.WriteLine("After withdrawal:");
            Console.WriteLine(account.DisplayAccountInfo());

            // TASK 7: Display Transaction History
            account.DisplayTransactions();
        }
    }
}