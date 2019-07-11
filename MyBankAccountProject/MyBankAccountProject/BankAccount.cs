using System;
using System.Collections.Generic;
using System.Text;

namespace BankAccount
{
    public enum AccountState { Opened, Closed }
    class BankAccount
    {
        private decimal balance = 0;
        private Person client;
        public List<CompleteTransaction> ListOfTransactions { get; set; } = new List<CompleteTransaction>();
        public BankAccount(Person client)
        {
            this.client = client;
        }
        public AccountState AccountState { get; set; }
        public void InfoAboutPerson()
        {
            Console.WriteLine("Added information for creating a bank account:");
            Console.WriteLine($"Firstname:{client.FirstName}");
            Console.WriteLine($"Lastname:{client.LastName}");
            Console.WriteLine($"Cnp:{client.Cnp}");
            Console.WriteLine($"Address:{client.Address}");
        }
        public void OpenAccount()
        {
            if (AccountState == AccountState.Closed)
            {
                AccountState = AccountState.Opened;
                Console.WriteLine($"The account is {AccountState}!");
            }
        }
        public void CloseAccount()
        {
            if (AccountState == AccountState.Opened)
            {
                AccountState = AccountState.Closed;
                Console.WriteLine($"At client's request, this account will be {AccountState}!");
            }
        }
        public void AddDeposit(decimal amount, string detailTransaction)
        {
            Transaction t = new Transaction(amount, TypeTransaction.Deposit, detailTransaction);
            Comision c = new Comision(amount, TypeTransaction.Deposit, detailTransaction);
            if (amount > 0)
            {
                balance += amount - c.Value;
                Console.WriteLine(amount - c.Value + "->has been added to your account");
                Console.WriteLine(c.Value + "->bank comision");
                ListOfTransactions.Add(new CompleteTransaction(t, c));
                ShowNewBalance();
            }
            else
            {
                Console.WriteLine("You must introduce a valid amount!");
            }
        }
        public void Withdraw(decimal amount, string detailTransaction)
        {
            if (balance > 0)
            {
                Transaction t = new Transaction(amount, TypeTransaction.Withdrawal, detailTransaction);
                Comision c = new Comision(amount, TypeTransaction.Withdrawal, detailTransaction);
                if (balance >= amount + c.Value)
                {
                    balance -= amount + c.Value;
                    ListOfTransactions.Add(new CompleteTransaction(t, c));
                    Console.WriteLine(amount - c.Value + "->has been withdrawn from your account");
                    Console.WriteLine(c.Value + "->bank comision");
                    ShowNewBalance();
                }
            }
            else
            {
                Console.WriteLine("Insufficient fonds for making withdrawls!");
            }
        }
        public void InfoComissions()
        {
            Console.WriteLine("\nInformation about this bank account:\n");
            InfoAboutPerson();
            Console.WriteLine("\nList of transactions with comission for this bank account:\n");
            foreach (var completeTransaction in ListOfTransactions)
            {
                Console.WriteLine($"\nComision: {completeTransaction.Comision.Value} paid for:\nTransaction of type:{completeTransaction.Transaction.TypeTransaction}\nAmount:{completeTransaction.Transaction.AmountTransaction}\nDate:{completeTransaction.Transaction.DateTransaction}\nDetails:{completeTransaction.Transaction.DetailTransaction}\n");
            }
        }
        public void ShowNewBalance()
        { Console.WriteLine("New account balance :" + balance); }
    }
}
