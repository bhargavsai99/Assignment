using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment2
{
    class Program
    {
        public static void Main()
        {
            Console.WriteLine("WELCOME");
            Console.WriteLine("1.Admin\n2.Customer");
            int option = Convert.ToInt32(Console.ReadLine());
            AddAccountpf app = new AddAccountpf();
            switch (option)
            {
                case 1:
                    Console.WriteLine("1.Add an Account\n2.View All Accounts \n3.Get Account Details");
                    int AdminChoice = Convert.ToInt32(Console.ReadLine());
                    switch(AdminChoice)
                    {
                        case 1:
                            app.Addaccount();
                            break;
                        case 2:
                            app.ViewAllAccounts();
                            break;
                        case 3:
                            app.GetAccountDetails();
                            break;
                        default:
                            break;

                    }
                    break;
                case 2:
                    Console.WriteLine("1.WithDraw\n2.CheckBalance\n3.ChangePassword\n4.GetAccountDetails");
                    int choice = Convert.ToInt32(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            Console.WriteLine("1.SavingsAccount\n2.Current Account");
                            int op = Convert.ToInt32(Console.ReadLine());
                            switch(op)
                            {
                                case 1:
                                    app.WithdrawfromSavings();
                                    break;

                                case 2:
                                    app.WithdrawfromCurrent();
                                    break;

                            }

                            break;
                        case 2:
                            app.CheckBalance();
                            break;
                        case 3:
                            app.ChangePassword();
                            break;
                        case 4:
                            app.GetAccountDetails(); 
                            break;

                            
                        default:
                            break;

                    }
                    break;


            }
 
        }

       
    }
}
