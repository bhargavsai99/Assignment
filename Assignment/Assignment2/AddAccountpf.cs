using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace Assignment2
{
    internal class AddAccountpf
    {
        SqlConnection con = null;
        SqlCommand cmd = null;

        public SqlConnection GetConnection()
        {
            con = new SqlConnection(
                    "Data Source = LAPTOP-5UT6216M; Initial Catalog = dbaccount; Integrated Security = true");
            con.Open();
            return con;
        }
        internal void Addaccount()
        {
            double AccountBalance;
            string AccountPassword;

            Console.WriteLine("Enter the Account Balance");
            AccountBalance = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter the Account Password");
            AccountPassword = Console.ReadLine();
            Console.WriteLine("1.Savings Account \n2.CurrentAccount");
            int Input = Convert.ToInt32(Console.ReadLine());
            try
            {
                con = GetConnection();
                switch (Input)
                {
                    case 1:
                        Console.WriteLine("Enter the MinBalanceAmount");
                        double MinBalanceAmount = Convert.ToDouble(Console.ReadLine());

                        cmd = new SqlCommand("spu_AddSavingsAccount", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@AccBalance", AccountBalance);
                        cmd.Parameters.AddWithValue("@AccPassword", AccountPassword);
                        cmd.Parameters.AddWithValue("@MinBalanceAmount", MinBalanceAmount);
                        int rowsAffected = cmd.ExecuteNonQuery();
                        Console.WriteLine($"Rows Affected:{ rowsAffected}");
                        break;

                    case 2:

                        Console.WriteLine("Enter the OverDraftAmount");
                        double OverdraftLimitAmount = Convert.ToDouble(Console.ReadLine());
                        con = GetConnection();

                        cmd = new SqlCommand("spu_AddCurrentAccount", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@AccBalance", AccountBalance);
                        cmd.Parameters.AddWithValue("@AccPassword", AccountPassword);
                        cmd.Parameters.AddWithValue("@OverdraftLimitAmount", OverdraftLimitAmount);
                        rowsAffected = cmd.ExecuteNonQuery();
                        Console.WriteLine($"Rows Affected:{ rowsAffected}");
                        break;
                    default:
                        Console.WriteLine("Invalid");
                        break;
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                con.Close();
            }
        }

        internal void ViewAllAccounts()
        {
            try
            {
                con = GetConnection();
                cmd = new SqlCommand("spu_ViewAllAccount", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Console.WriteLine(dr[0] + " " + dr[1] + " " + dr[2] + " " + dr[3] + " " + dr[4]);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                con.Close();
            }

        }
        internal void GetAccountDetails()
        {


            Console.WriteLine("Enter the Account Number");
            int AccNumber = Convert.ToInt32(Console.ReadLine());
            try
            {
                con = GetConnection();
                cmd = new SqlCommand("spu_GetAccountDetails", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@AccNumber", AccNumber);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Console.WriteLine(dr[0] + " " + dr[1] + " " + dr[2] + " " + dr[3] + " ");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid Account Number...!!!");
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                con.Close();
            }


        }
        internal void ChangePassword()
        {
            Console.WriteLine("Enter the Account Number");
            int AccNumber = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the OldPassword");
            string OldPass = Console.ReadLine();
            Console.WriteLine("Enter the NewPassword");
            string newpass = Console.ReadLine();
            try
            {
                con = GetConnection();
                cmd = new SqlCommand("spu_ChangePassword", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@AccNumber", AccNumber);
                cmd.Parameters.AddWithValue("@OldPass", OldPass);
                cmd.Parameters.AddWithValue("@NewPass", newpass);
                int rowsAffected = cmd.ExecuteNonQuery();
                Console.WriteLine($"Rows Affected:{ rowsAffected}");

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                con.Close();
            }
        }
        internal void CheckBalance()
        {
            Console.WriteLine("Enter the Account Number");
            int AccNumber = Convert.ToInt32(Console.ReadLine());
            try
            {
                con = GetConnection();
                //Procedure name in sqlServer
                cmd = new SqlCommand("spu_CheckBalance", con);
                cmd.Parameters.AddWithValue("@AccNumber", AccNumber);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr;
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Console.WriteLine(dr[0] + " " + dr[1] + " ");
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                con.Close();
            }
        }
        internal void WithdrawfromSavings()
        {

            Console.WriteLine("Enter the Account Number");
            int AccNumber = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the Withdrawl Amount");
            double WithdrawlAmount = Convert.ToDouble(Console.ReadLine());
            try
            {
                con = GetConnection();
                cmd = new SqlCommand("spu_SavingsWithdrawlUpdate", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@AccNumber", AccNumber);
                SqlDataReader dr = cmd.ExecuteReader();
                decimal AccBalance = 0, MinimumBalance = 0;
                while (dr.Read())
                {
                    AccBalance += (decimal)dr.GetValue(1);
                    MinimumBalance += (decimal)dr.GetValue(3);

                }
                double AccountBalance = Convert.ToDouble(AccBalance);
                double MinimumBalanceAmount = Convert.ToDouble(MinimumBalance);

                if (WithdrawlAmount < 0)
                {
                    throw new InvalidAmountException("Invalid Amount");
                }
                else
                {
                    if (AccountBalance - MinimumBalanceAmount - WithdrawlAmount < 0)
                    {
                        throw new InvalidAmountException("Invalid Amount");
                    }
                    else
                    {
                        AccountBalance -= WithdrawlAmount;
                        Console.WriteLine("Account Balance{0}",AccountBalance);
                    }
                }
                cmd = new SqlCommand("spu_SavingsWithdrawlUpdate", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@AccNumber", AccNumber);
                cmd.Parameters.AddWithValue("@AccBalance", AccountBalance);
                int rowsAffected = cmd.ExecuteNonQuery();
                Console.WriteLine($"Rows Affected:{ rowsAffected}");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                con.Close();
            }
        }
        internal void WithdrawfromCurrent()
        {

            Console.WriteLine("Enter the Account Number");
            int AccNumber = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the Withdrawl Amount");
            double WithdrawlAmount = Convert.ToDouble(Console.ReadLine());
            try
            {
                con = GetConnection();
                cmd = new SqlCommand("spu_CurrentWithdrawlUpdate", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@AccNumber", AccNumber);
                SqlDataReader dr = cmd.ExecuteReader();
                decimal AccBalance = 0, Overdraftlimit = 0;
                while (dr.Read())
                {
                    AccBalance += (decimal)dr.GetValue(1);
                    Overdraftlimit += (decimal)dr.GetValue(3);
                
                }
                double AccountBalance = Convert.ToDouble(AccBalance);
                double OverdraftlimitAmount = Convert.ToDouble(Overdraftlimit);
                

                if (WithdrawlAmount < 0)
                {
                    throw new InvalidAmountException("Invalid Amount");
                }
                else
                {
                    if (AccountBalance - OverdraftlimitAmount - WithdrawlAmount < 0)
                    {
                        throw new InvalidAmountException("Invalid Amount");
                    }
                    else
                    {
                        AccountBalance -= WithdrawlAmount;
                    }
                }
                cmd.Parameters.AddWithValue("@AccBalance", AccountBalance);
                int rowsAffected = cmd.ExecuteNonQuery();
                Console.WriteLine($"Rows Affected:{ rowsAffected}");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                con.Close();
            }
        }


    }




}


