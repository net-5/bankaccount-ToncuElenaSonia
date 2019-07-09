using System;

namespace MyBankAccountProject
{
    class Program
    {
        static void Main(string[] args)
        {
            BankAccountProject newAccount2 = new BankAccountProject(new Person("Toncu", "Sonia", 2980113328509, "localitatea Valea Adanca, com.Miroslava, jud.Iasi"));

            newAccount2.InfoAboutPerson();
            newAccount2.OpenAccount();
            Console.WriteLine();
            newAccount2.AddDeposit(1200, "'pay course0'");
            newAccount2.AddDeposit(1201, "'pay course1'");
            Console.WriteLine();
            newAccount2.Withdrawal(100, "'need cash'");
            newAccount2.Withdrawal(200, "'need cash'");
            Console.WriteLine();
            newAccount2.InfoComissions();
            Console.WriteLine();
            newAccount2.CloseAccount();
        }
    }
}
