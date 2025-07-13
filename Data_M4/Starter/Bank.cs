using System;
using System.Collections.Generic;

namespace BankApp
{
    // TASK 1: Define the AccountType enum
    public enum AccountType
    {
        // TASK 1: Step 1 - Add enum values like Checking, Savings, and Business.
        // placeholder
    }

    // TASK 2: Define the Transaction struct
    public struct Transaction
    {
        // TASK 2: Step 1 - Add properties for Amount, Date, and Description to store transaction details.
        // placeholder

        // TASK 2: Step 2 - Add a constructor to initialize the properties.
        // placeholder

        // TASK 2: Step 3 - Override the ToString method to format transaction details.
        // placeholder
    }

    // TASK 3: Define the Customer record
    public record Customer
    {
        // TASK 3: Step 1 - Add properties for Name, CustomerId, and Address.
        // placeholder
    }

    // TASK 4: Implement the BankAccount class
    public class BankAccount
    {
        // TASK 4: Step 1 - Add properties for AccountNumber, Balance, AccountHolder, and Type.
        public int AccountNumber { get; }
        public double Balance { get; private set; }
        // placeholder - Add properties for AccountHolder and Type.

        // TASK 4: Step 2 - Add a constructor to initialize the properties.
        public BankAccount(int accountNumber, double initialBalance = 0)
        {
            AccountNumber = accountNumber;
            Balance = initialBalance;
            // placeholder - Initialize AccountHolder and Type.
        }

        // TASK 4: Step 3 - Add a method to deposit money into the account.
        public void Deposit(double amount)
        {
            if (amount > 0)
            {
                Balance += amount;
                // placeholder - Add transaction to the transaction list.
            }
        }

        // TASK 4: Step 4 - Add a method to withdraw money from the account.
        public bool Withdraw(double amount)
        {
            if (amount > 0 && Balance >= amount)
            {
                Balance -= amount;
                // placeholder - Add transaction to the transaction list.
                return true;
            }
            return false;
        }

        // TASK 4: Step 5 - Add a method to display account information.
        public string DisplayAccountInfo()
        {
            return $"Account Number: {AccountNumber}, Balance: {Balance:C}";
            // placeholder - Include AccountHolder and Type in the output.
        }

        // TASK 4: Step 6 - Add a list to track transactions.
        // placeholder - Add a private list to store transactions.

        // TASK 4: Step 7 - Add a method to display all transactions.
        // placeholder - Add a method to iterate through and display transactions.
    }
}