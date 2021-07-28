using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment2
{
    class InvalidAmountException : ApplicationException
    {
        internal InvalidAmountException(string msg) : base(msg) { }
    }
    abstract class Account
    {
        internal int AccountNo { get; set; }

        internal double AccountBalance { get; set; }

        string Password { get; set; }

        public string BankName = "SBI";

        internal abstract void Withdraw(double amount);
        internal Account(int AccountNo, double AccountBalance, string Password)
        {
            this.AccountNo = AccountNo;
            this.AccountBalance = AccountBalance;
            this.Password = Password;
        }
        internal void DisplayMethod()
        {
            Console.WriteLine("BankAccountNo: {0} || AccountBalance: {1} || BankName: {2}", AccountNo, AccountBalance, BankName);
        }

    }
    internal class SavingsAccount : Account
    {
        float MinimumBalance { set; get; }
        float balance { set; get; }

        internal SavingsAccount(int AccountNo, float AccountBalance, string Password, float MinimumBalance, float balance) : base(AccountNo, AccountBalance, Password)

        {
            this.MinimumBalance = MinimumBalance;
            this.balance = balance;
        }

        internal override void Withdraw(double amount)
        {
            try
            {
                if(amount<0)
                {
                    throw new InvalidAmountException("Invalid Amount");
                }
                else
                {
                    if(AccountBalance-MinimumBalance-amount<0)
                    {
                        throw new InvalidAmountException("Invalid Amount");
                    }
                    else
                    {
                        AccountBalance -= amount;
                    }
                }
            }
            catch(ApplicationException e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine($"Remaining  Balance:{AccountBalance}");
        }
        new internal void DisplayMethod()
        {
            Console.WriteLine("BankAccountNo: {0} || AccountBalance: {1} || BankName: {2} || Minimum Balance:{3}|| BalanceafterWithdrawn:{4}", AccountNo, AccountBalance, BankName, MinimumBalance);
        }
    } 
    internal class CurrentAccount : Account
    {
        int OverDraftLimitAccount { set; get; }
        

        internal CurrentAccount(int AccountNo, float AccountBalance, string Password, int OverDraftLimitAccount) : base(AccountNo, AccountBalance, Password)

        {
            this.OverDraftLimitAccount = OverDraftLimitAccount;
           

        }
        internal override void Withdraw(double amount)
        {
            try
            {
                if (amount < 0)
                {
                    throw new InvalidAmountException("Invalid Amount");
                }
                else
                {
                    if (AccountBalance - OverDraftLimitAccount - amount < 0)
                    {
                        throw new InvalidAmountException("Invalid Amount");
                    }
                    else
                    {
                        AccountBalance -= amount;
                    }
                }
            }
            catch (ApplicationException e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine($"Remaining  Balance:{AccountBalance}");
        }
        new internal void DisplayMethod()
        {
            Console.WriteLine("BankAccountNo: {0} || AccountBalance: {1} || BankName: {2} || OverDeaftLimit:{3} }", AccountNo, AccountBalance, BankName, OverDraftLimitAccount);
        }
    }

    

}

        
    

