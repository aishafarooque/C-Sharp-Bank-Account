using System;
using System.Collections.Generic;

namespace classes
{
    public class BankAccount
    {
        private static int accountNumberSeed = 1234567890;
        private List<Transaction> allTransactions = new List<Transaction>();

        public string Number { get; }
        public string Owner { get; set; }
        public decimal Balance { 
            get {
                decimal balance = 0;
                foreach (var item in allTransactions) {
                    balance += item.Amount;
                }
                return balance;
            }

            set {
                Balance = value;
            }
        }

        public BankAccount (string owner, decimal balance) {
            this.Owner = owner;
            this.Number = accountNumberSeed++.ToString();

            Console.WriteLine($"Creating bank account #{this.Number} for {this.Owner}.\n\n");

            MakeDeposit(balance, DateTime.Now, "Initial Deposit");
        }

        public void MakeDeposit(decimal amount, DateTime date, string note) {
            if (amount <= 0) {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount deposited must be positive.");
            }

            Console.WriteLine($"Making a deposit of {amount} to account number {this.Number}.\n\n");
            var new_deposit = new Transaction(amount, date, note);
            allTransactions.Add(new_deposit);
        }

        public void MakeWithdrawal(decimal amount, DateTime date, string note) {
            if (amount <= 0) {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount withdrawn should be positive.");                
            }

            if (Balance - amount <= 0) {
                throw new ArgumentOutOfRangeException(nameof(amount), "Insufficient balance.");
            }

            var new_withdraw = new Transaction(amount, date, note);
            allTransactions.Add(new_withdraw);
        }

        public string GetAccountHistory() {
            var report = new System.Text.StringBuilder();

            decimal balance = 0;
            report.AppendLine("Date\t\tAmount\tBalance\tNote");
            foreach (var item in allTransactions) {
                balance += item.Amount;
                report.AppendLine($"{item.Date.ToShortDateString()}\t{item.Amount}\t{balance}\t{item.Notes}");
            }

            return report.ToString();
        }

    }
}