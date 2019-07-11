using System;
using System.Collections.Generic;
using System.Text;

namespace BankAccount
{
    public enum TypeTransaction { Deposit, Withdrawal }
    public class Transaction
    {
        public decimal AmountTransaction { get; }
        public DateTime DateTransaction { get; }
        public string DetailTransaction { get; }
        public TypeTransaction TypeTransaction { get; }
        public Transaction(decimal amountTransaction, TypeTransaction typeTransaction, string detailTransaction)
        {
            AmountTransaction = amountTransaction;
            DateTransaction = new DateTime(2019, 7, 9);
            DetailTransaction = detailTransaction;
            TypeTransaction = typeTransaction;
        }
    }
}

