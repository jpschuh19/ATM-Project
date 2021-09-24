﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Assignment_2
{
    class Account
    {
        int accountNum;
        int customerID;
        double balance;
        double dailyDepositAmount;
        double dailyTransactionTotal;
        double dailyTransactionLimit = 3000.0;
        string dailyTransactionDate;
        Transaction newTransaction;

        public Transaction getNewTransaction()
        {
            return newTransaction;
        }


        public void withdrawMoney(double amount, double machineCash)
        {
            updateBalanceWithdrawal(amount);
            updateDailyTransactionTotal(amount);
            updateAccountData();
            newTransaction = new Transaction(accountNum, "Withdraw", amount, -1, -1);
            newTransaction.saveTransaction();
        }

        public void depositMoney(double amount, double machineCash)
        {
            updateBalanceDeposit(amount);
            updateDailyTransactionTotal(amount);
            updateAccountData();
            newTransaction = new Transaction(accountNum, "Deposit", amount, -1, -1);
            newTransaction.saveTransaction();
        }

        private void updateAccountData()
        {
            string connStr = "server=157.89.28.130;user=ChangK;database=csc340;port=3306;password=Wallace#409;";
            MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();
                //string sql = "INSERT INTO changstudent (id, name) VALUES (@uid, @uname)";
                string sql = "UPDATE changAccount SET dailyTransDate=@date, dailyTransTotal=@total, balance=@newBalance WHERE accountNum=@accNum;";
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@date", dailyTransactionDate);
                cmd.Parameters.AddWithValue("@total", dailyTransactionTotal);
                cmd.Parameters.AddWithValue("@newBalance", balance);
                cmd.Parameters.AddWithValue("@accNum", accountNum);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            conn.Close();
            Console.WriteLine("Done.");

        }
        private void updateDailyTransactionTotal(double amount)
        {
            dailyTransactionTotal = dailyTransactionTotal + amount;
        }

        private void updateBalanceWithdrawal(double amount)
        {
            balance = balance - amount;
        }
        
        private void updateBalanceDeposit(double amount)
        {
            balance = balance - amount;
        }

        private bool checkMachineCash(double amount, double machineCash)
        {
            if (amount > machineCash)
                return false;
            return true;
        }
        private bool verifyAccountBalance(double amount)
        {
            if (amount > balance)
                return false;
            return true;
        }
        private bool verifyDailyTransaction(double amount)
        {
            if ((dailyTransactionTotal + amount) > 3000.0)
                return false;
            else
                return true;
        }
        public bool checkDailyTransaction()
        {
            if (dailyTransactionTotal >= 3000.0)
                return false;
            return true;
        }
        private void updateDailyTransaction()
        {
            string todayDate = DateTime.Now.ToString("yyyy-MM-dd");
            Console.WriteLine("old date: " + dailyTransactionDate);
            Console.WriteLine("new date: " + todayDate);
            if (!dailyTransactionDate.Equals(todayDate))
            {
                dailyTransactionDate = todayDate;
                dailyTransactionTotal = 0.0;
                dailyDepositAmount = 0.0;
                Console.WriteLine("Date being changed.");
            }
        }
        public int getAccountNum()
        {
            return accountNum;
        }

        public double getBalance()
        {
            return balance;
        }
        public static ArrayList retrieveAccounts(int id)
        {
            ArrayList accountList = new ArrayList();
            //ArrayList eventList = new ArrayList();  //a list to save the events
            //prepare an SQL query to retrieve all the events on the same, specified date
            DataTable myTable = new DataTable();
            string connStr = "server=157.89.28.130;user=ChangK;database=csc340;port=3306;password=Wallace#409;";
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();
                string sql = "SELECT * FROM changAccount WHERE customerID=@myID ORDER BY accountNum ASC";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@myID", id);
                MySqlDataAdapter myAdapter = new MySqlDataAdapter(cmd);
                myAdapter.Fill(myTable);
                Console.WriteLine("Table is ready.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            conn.Close();
            //convert the retrieved data to events and save them to the list
            foreach (DataRow row in myTable.Rows)
            {
                Account newAccount = new Account();

                newAccount.accountNum = Int32.Parse(row["accountNum"].ToString());
                newAccount.customerID = Int32.Parse(row["customerID"].ToString());
                newAccount.balance = Double.Parse(row["balance"].ToString());
                newAccount.dailyTransactionTotal = Double.Parse(row["dailyTransTotal"].ToString());
                newAccount.dailyTransactionDate = row["dailyTransDate"].ToString();
                newAccount.dailyDepositAmount = Double.Parse(row["dailyDepositAmount"].ToString());
                /*
                newEvent.eventDate = row["date"].ToString();
                newEvent.eventStartTime = Int32.Parse(row["startTime"].ToString());
                newEvent.eventEndTime = Int32.Parse(row["endTime"].ToString());
                newEvent.eventContent = row["content"].ToString();
                */
                accountList.Add(newAccount);
            }
            Console.WriteLine("*********" + accountList.Count);
            return accountList;  //return the event list
        }
    }
}
