using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment2
{
    
    class InterfaceATM
    {
        interface ATM
        {
            
        }
        class SBIAtm : ATM
        {
            internal void Withdraw(Account account)
            {
                Console.WriteLine($"Enter the Account Number ");
                int AccNo = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine($"Enter Withdraw Amount");
                double Amt = Convert.ToDouble(Console.ReadLine());
            }
            internal void changePassword(int accountNumber, String oldPassword, String newPassword)
            {

            }
            internal void checkBalance()
            {

            }
        }
        class ICICIAtm : ATM
        {
            internal void Withdraw(Account account)
            {
                Console.WriteLine($"Enter the Account Number ");
                int AccNo = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine($"Enter Withdraw Amount");
                double Amt = Convert.ToDouble(Console.ReadLine());
            }
            internal void changePassword(int accountNumber, String oldPassword, String newPassword)
            {

            }
            internal void checkBalance()
            {

            }
        }
    }
    
}
