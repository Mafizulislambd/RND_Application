using System;
using System.Collections.Generic;

namespace BankApp
{
    // TASK 1: Define the AccountType enum
    public enum AccountType
    {
        // TASK 1: Step 1 - Add enum values like Checking, Savings, and Business to categorize accounts.
        Checking,
        Savings,
        Business
    }

    // TASK 2: Define the Transaction struct
    public struct Transaction
    {
        // TASK 2: Step 1 - Add properties for Amount, Date, and Description to store transaction details.
        public double Amount { get; }
        public DateTime Date { get; }
        public string Description { get; }

        // TASK 2: Step 2 - Add a constructor to initialize the properties for a transaction.
        public Transaction(double amount, DateTime date, string description)
        {
            Amount = amount;
            Date = date;
            Description = description;
        }

        // TASK 2: Step 3 - Override the ToString method to format transaction details for display.
        public override string ToString()
        {
            return $"{Date.ToShortDateString()}: {Description} - {Amount:C}";
        }
    }

    // TASK 3: Define the Customer record
    public record Customer
    {
        // TASK 3: Step 1 - Add properties for Name, CustomerId, and Address to represent customer details.
        public string Name { get; init; }
        public string CustomerId { get; init; }
        public string Address { get; init; }
    }

    // TASK 4: Implement the BankAccount class
    public class BankAccount
    {
        // TASK 4: Step 1 - Add properties for AccountNumber, Balance, AccountHolder, and Type to represent account details.
        public int AccountNumber { get; }
        public double Balance { get; private set; }
        public Customer AccountHolder { get; }
        public AccountType Type { get; }

        // TASK 4: Step 6 - Add a list to track transactions for the account.
        private List<Transaction> _transactions = new();

        // TASK 4: Step 2 - Add a constructor to initialize the properties for a bank account.
        public BankAccount(int accountNumber, double initialBalance, Customer accountHolder, AccountType type)
        {
            AccountNumber = accountNumber;
            Balance = initialBalance;
            AccountHolder = accountHolder;
            Type = type;
        }

        // TASK 4: Step 3 - Add a method to deposit money into the account and update the balance.
        public void Deposit(double amount, string description)
        {
            if (amount > 0)
            {
                Balance += amount;
                _transactions.Add(new Transaction(amount, DateTime.Now, description));
            }
        }

        // TASK 4: Step 4 - Add a method to withdraw money from the account and update the balance.
        public bool Withdraw(double amount, string description)
        {
            if (amount > 0 && Balance >= amount)
            {
                Balance -= amount;
                _transactions.Add(new Transaction(-amount, DateTime.Now, description));
                return true;
            }
            return false;
        }

        // TASK 4: Step 5 - Add a method to display account information, including AccountHolder and Type.
        public string DisplayAccountInfo()
        {
            return $"Account Number: {AccountNumber}, Balance: {Balance:C}, Account Holder: {AccountHolder.Name}, Type: {Type}";
        }

        // TASK 4: Step 7 - Add a method to display all transactions for the account.
        public void DisplayTransactions()
        {
            Console.WriteLine("Transaction History:");
            foreach (var transaction in _transactions)
            {
                Console.WriteLine(transaction);
            }
        }
    }
}