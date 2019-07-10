using System;
using System.Collections.Generic;
using System.Text;

namespace MyBankAccountProject
{
    public enum AccountState { Opened, Closed }
    class BankAccountProject
    {
        private decimal balance = 0;
        private Person client;
        public List<CompleteTransaction> ListOfTransactions { get; set; } = new List<CompleteTransaction>();
        public BankAccountProject(Person client)
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
            if (balance > 0)
            {
                Console.WriteLine("Operation to close the account fails!!");
            }
            else
            {
                if (balance == 0)
                {
                    AccountState = AccountState.Closed;
                    Console.WriteLine($"At client's request, this account will be {AccountState}!");
                }
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
        public void Withdrawal(decimal amount, string detailTransaction)
        {
            Transaction t = new Transaction(amount, TypeTransaction.Withdrawal, detailTransaction);
            Comision c = new Comision(amount, TypeTransaction.Withdrawal, detailTransaction);
            if (balance > 0 && balance >= amount + c.Value)
            {
                balance -= amount + c.Value;
                ListOfTransactions.Add(new CompleteTransaction(t, c));
                Console.WriteLine(amount - c.Value + "->has been withdrawn from your account");
                Console.WriteLine(c.Value + "->bank comision");
                ShowNewBalance();
            }
            else
            {
                Console.WriteLine("Insufficient fonds for making withdrawls!");
            }
        }
        public void InfoComissions()
        {
            Console.WriteLine("\nList of transactions with comission:\n");
            foreach (var completeTransaction in ListOfTransactions)
            {
                Console.WriteLine($"Comision: {completeTransaction.Comision.Value} paid for:\nTransaction of type:{completeTransaction.Transaction.TypeTransaction}\nAmount:{completeTransaction.Transaction.AmountTransaction}\nDate:{completeTransaction.Transaction.DateTransaction}\nDetails:{completeTransaction.Transaction.DetailTransaction}");
            }
        }
        public void ShowNewBalance()
        { Console.WriteLine("New account balance :" + balance); }
    }
}
