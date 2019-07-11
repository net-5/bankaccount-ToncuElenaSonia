using System;
using System.Collections.Generic;
using System.Text;

namespace BankAccount
{
    class Person
    {
        private string firstName;
        private string lastName;
        private long cnp;
        private string address;

        public string FirstName { get; set; }

        public string LastName { get; set; }
        public long Cnp { get; set; }
        public string Address { get; set; }


        public Person(string firstName, string lastName, long cnp, string address)
        {
            FirstName = firstName;
            LastName = lastName;
            Cnp = cnp;
            Address = address;

        }


    }
}

