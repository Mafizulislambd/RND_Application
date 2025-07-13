using System;

namespace BankApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Bank App!");

            // TASK 5: Display Basic Bank Account Information
            // placeholder - Create a BankAccount object and display its information.

            BankAccount account = new BankAccount(12345678, 500);
            Console.WriteLine(account.DisplayAccountInfo());

            // TASK 6: Perform Transactions
            // placeholder - Add a deposit and a withdrawal, then display updated account information.

            account.Deposit(200);
            Console.WriteLine("After deposit:");
            Console.WriteLine(account.DisplayAccountInfo());

            bool success = account.Withdraw(100);
            Console.WriteLine(success ? "Withdrawal successful." : "Withdrawal failed.");
            Console.WriteLine("After withdrawal:");
            Console.WriteLine(account.DisplayAccountInfo());

            // TASK 7: Display Transaction History
            // placeholder - Add and display transactions using the Transaction struct.

            Console.WriteLine("Features to be implemented...");
        }
    }
}