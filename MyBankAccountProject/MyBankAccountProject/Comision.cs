using System;
using System.Collections.Generic;
using System.Text;

namespace MyBankAccountProject
{
    public class Comision : Transaction
    {
        private decimal percIn = 5.0M;
        private decimal percOut = 3.0M;
        public decimal Value { get; private set; }
        public Comision(decimal amountTransaction, TypeTransaction typeTransaction, string detailTransaction) : base(amountTransaction, typeTransaction, detailTransaction)
        {
            if (typeTransaction == TypeTransaction.Deposit)
            {
                Value = (percIn * amountTransaction) / 100;
            }
            else
            {
                Value = (percOut * amountTransaction) / 100;
            }
        }

    }
}
