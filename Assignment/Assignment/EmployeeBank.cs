using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment1
{
    class EmployeeBank
    {
        int AccountNo { get; set; }

        float AccountBalance { get; set; }

        string Password { get; set; }

        public string BankName = "SBI";


        EmployeeBank(int AccountNo, float AccountBalance, string Password)
        {
            this.AccountNo = AccountNo;
            this.AccountBalance = AccountBalance;
            this.Password = Password;
        }
        void DisplayMethod()
        {
            Console.WriteLine("BankAccountNo: {0} || AccountBalance: {1} || BankName: {2}", AccountNo, AccountBalance, BankName);
        }
    
            
        class main
        {
            public static void Main(String[] args)
            {
                Console.WriteLine("Please Enter your Account Number");
                int AccountNo;
                AccountNo = int.Parse(Console.ReadLine());
                Console.WriteLine("Acc:{0}", AccountNo);
                Console.WriteLine("Please Enter your Account Balance");
                float AccountBalance;
                AccountBalance = float.Parse(Console.ReadLine());
                Console.WriteLine("Please Enter the Account Passwword");
                string password;
                password = Console.ReadLine();
                EmployeeBank e = new EmployeeBank(AccountNo, AccountBalance, password);
                e.DisplayMethod();



            }

        }
    }
}
