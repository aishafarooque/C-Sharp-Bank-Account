using System;

namespace classes
{
    class Program
    {
        static void Main(string[] args)
        {
        	var Account = new BankAccount("Aisha", 100000);
        	Console.WriteLine($"Account {Account.Number} was created for {Account.Owner} with balance of {Account.Balance}");
        	Account.MakeDeposit(120, DateTime.Now, "Paycheck #1");
        	Console.WriteLine($"The balance in {Account.Number} is {Account.Balance}");
        }
    }
}