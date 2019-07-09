using System;
using System.Collections.Generic;
using System.Text;

namespace MyBankAccountProject
{
    public class CompleteTransaction
    {
        public Transaction Transaction { get; set; }
        public Comision Comision { get; set; }

        public CompleteTransaction(Transaction tranzactie, Comision comision)
        {
            Transaction = tranzactie;
            Comision = comision;
        }
    }
}
