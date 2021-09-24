using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment_2
{
    public partial class Form1 : Form
    {
        int amount = 0;
        int machinecash = 100000;
        int balance = 10000;
        int trans_total = 0;
        Customer currentCustomer = new Customer(1);
        ArrayList accountList = new ArrayList();
        Account selectedAccount;
        double machineCash = 100000;
        String trans_type = "";
        String account_num;


        public Form1()
        {
            InitializeComponent();
            accountList = Account.retrieveAccounts(currentCustomer.getID());
        }

        private void button1_Click(object sender, EventArgs e)
        {//Exit
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {//Withdrawl
            tableLayoutPanel1.Visible = false;
            tableLayoutPanel2.Visible = true;
            tableLayoutPanel3.Visible = false;
            tableLayoutPanel4.Visible = false;
            tableLayoutPanel8.Visible = false;
            tableLayoutPanel9.Visible = false;
            listBox1.Items.Clear();
            listBox1.Items.Clear();
            Account tempAccount;
            Console.WriteLine("number of account: " + accountList.Count);
            for (int i = 0; i < accountList.Count; i++)
            {
                tempAccount = (Account)accountList[i];
                listBox1.Items.Add(tempAccount.getAccountNum());
            }
            trans_type = "W";
        }

        private void label2_Click(object sender, EventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {//Deposit
            tableLayoutPanel1.Visible = false;
            tableLayoutPanel2.Visible = true;
            tableLayoutPanel3.Visible = false;
            tableLayoutPanel4.Visible = false;
            tableLayoutPanel8.Visible = false;
            tableLayoutPanel9.Visible = false;
            label2.Text = "Please select account to deposit";
            listBox1.Items.Clear();
            Account tempAccount;
            Console.WriteLine("number of account: " + accountList.Count);
            for (int i = 0; i < accountList.Count; i++)
            {
                tempAccount = (Account)accountList[i];
                listBox1.Items.Add(tempAccount.getAccountNum());
            }
            trans_type = "D";
            
        }

        private void button3_Click(object sender, EventArgs e)
        {//check balance
            tableLayoutPanel1.Visible = false;
            tableLayoutPanel2.Visible = true;
            tableLayoutPanel3.Visible = false;
            tableLayoutPanel4.Visible = false;
            tableLayoutPanel8.Visible = false;
            tableLayoutPanel9.Visible = false;
            label2.Text = "Please select account to check the balance";
            listBox1.Items.Clear();
            Account tempAccount;
            Console.WriteLine("number of account: " + accountList.Count);
            for (int i = 0; i < accountList.Count; i++)
            {
                tempAccount = (Account)accountList[i];
                listBox1.Items.Add(tempAccount.getAccountNum());
            }
            trans_type = "C";
        }

        private void button5_Click(object sender, EventArgs e)
        {//transfer funds
            tableLayoutPanel1.Visible = false;
            tableLayoutPanel2.Visible = true;
            tableLayoutPanel3.Visible = false;
            tableLayoutPanel4.Visible = false;
            tableLayoutPanel8.Visible = false;
            tableLayoutPanel9.Visible = false;
            label2.Text = "Please select account to transfer to";
            listBox1.Items.Clear();
            Account tempAccount;
            Console.WriteLine("number of account: " + accountList.Count);
            for (int i = 0; i < accountList.Count; i++)
            {
                tempAccount = (Account)accountList[i];
                listBox1.Items.Add(tempAccount.getAccountNum());
            }
            trans_type = "TW";
        }

        private void button6_Click(object sender, EventArgs e)
        {//Return to main
            tableLayoutPanel1.Visible = true;
            tableLayoutPanel2.Visible = false;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {//account is selected
            selectedAccount = (Account)accountList[listBox1.SelectedIndex];
            //listBox1.Items.Clear();
            if (trans_type.Equals("W"))
            {
                if (trans_total > 3000)
                {
                    tableLayoutPanel3.Visible = true;
                    tableLayoutPanel2.Visible = false;

                }
                else
                {
                    tableLayoutPanel4.Visible = true;
                    tableLayoutPanel2.Visible = false;

                }
            }
            if (trans_type.Equals("D"))
            {
                if (trans_total > 3000)
                {
                    tableLayoutPanel3.Visible = true;
                    tableLayoutPanel2.Visible = false;
                }
                else
                {
                    tableLayoutPanel4.Visible = true;
                    tableLayoutPanel2.Visible = false;

                }
            }
            if (trans_type.Equals("TW"))
            {
                if (trans_total > 3000)
                {
                    tableLayoutPanel3.Visible = true;
                    tableLayoutPanel2.Visible = false;
                    
                }
                else
                {
                    tableLayoutPanel4.Visible = true;
                    tableLayoutPanel2.Visible = false;
                }
            }
            if (trans_type.Equals("TD"))
            {
                if (trans_total > 3000)
                {
                    tableLayoutPanel3.Visible = true;
                    tableLayoutPanel2.Visible = false;
                }
                else
                {
                    selectedAccount.depositMoney(amount, machineCash);
                    amount = 0;
                    tableLayoutPanel1.Visible = true;
                    tableLayoutPanel2.Visible = false;
                }
            }
            if (trans_type.Equals("C"))
            {
                account_num = listBox1.Text;
                tableLayoutPanel9.Visible = true;
                tableLayoutPanel2.Visible = false;
                label8.Text = account_num;
                label9.Text = selectedAccount.getBalance().ToString();
            }

        }

        private void button7_Click(object sender, EventArgs e)
        {
            tableLayoutPanel2.Visible = true;
            tableLayoutPanel3.Visible = false;
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click_1(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e) { }
        // add num buttons for calc
        private void button17_Click(object sender, EventArgs e)
        {// Add button 7
            label6.Text = label6.Text + "7";
        }

        private void button10_Click(object sender, EventArgs e)
        {// Add button 0
            label6.Text = label6.Text + "0";
        }

        private void button11_Click(object sender, EventArgs e)
        {// Add button 1
            label6.Text = label6.Text + "1";
        }

        private void button12_Click(object sender, EventArgs e)
        { // Add button 2
            label6.Text = label6.Text + "2";
        }

        private void button13_Click(object sender, EventArgs e)
        {// Add button 3
            label6.Text = label6.Text + "3";
        }

        private void button14_Click(object sender, EventArgs e)
        {// Add button 4
            label6.Text = label6.Text + "4";
        }

        private void button15_Click(object sender, EventArgs e)
        {// Add button 5
            label6.Text = label6.Text + "5";
        }

        private void button16_Click(object sender, EventArgs e)
        { // Add button 6
            label6.Text = label6.Text + "6";
        }

        private void button18_Click(object sender, EventArgs e)
        {// Add button 8
            label6.Text = label6.Text + "8";
        }

        private void button19_Click(object sender, EventArgs e)
        {// Add button 9
            label6.Text = label6.Text + "9";
        }
        //delete and clear buttons
        private void button8_Click(object sender, EventArgs e)
        {//delete
            if (label6.Text.Length > 0)
            {
                label6.Text = label6.Text.Substring(0, label6.Text.Length - 1);
            }
        }

        private void button21_Click(object sender, EventArgs e)
        {//clear
            label6.Text = "";
        }

        private void button9_Click(object sender, EventArgs e)
        {//Enter
            amount = amount + int.Parse(label6.Text);
            if (amount > 3000)
            {
                tableLayoutPanel4.Visible = false;
                tableLayoutPanel8.Visible = true;
                label7.Text = "Error: This account would exceed the maximum transaction total for today with this withdrawl";
            }
            
            if (trans_type.Equals("W"))
            {
                if (amount > machinecash)
                {
                    tableLayoutPanel4.Visible = false;
                    tableLayoutPanel8.Visible = true;
                    label7.Text = "Error: The amount selected to withdrawl is greater than the amount left in your account";
                }
                if (amount > balance)
                {
                    tableLayoutPanel4.Visible = false;
                    tableLayoutPanel8.Visible = true;
                    label7.Text = "Error: The amount selected to withdrawl is greater than the amount of money in the machine";
                }
                selectedAccount.withdrawMoney(amount, machineCash);
                trans_total = trans_total + amount;
                amount = 0;
                label6.Text = "";
                tableLayoutPanel4.Visible = false;
                tableLayoutPanel1.Visible = true;
            }
            if (trans_type.Equals("D"))
            {
                selectedAccount.depositMoney(amount, machineCash);
                trans_total = trans_total + amount;
                amount = 0;
                label6.Text = "";
                tableLayoutPanel4.Visible = false;
                tableLayoutPanel1.Visible = true;
            }

            if (trans_type.Equals("TW"))
            {
                if (amount > machinecash)
                {
                    tableLayoutPanel4.Visible = false;
                    tableLayoutPanel8.Visible = true;
                    label7.Text = "Error: The amount selected to withdrawl is greater than the amount left in your account";
                }
                if (amount > balance)
                {
                    tableLayoutPanel4.Visible = false;
                    tableLayoutPanel8.Visible = true;
                    label7.Text = "Error: The amount selected to withdrawl is greater than the amount of money in the machine";
                }
                selectedAccount.withdrawMoney(amount, machineCash);
                trans_total = trans_total + amount;
                label6.Text = "";
                trans_type = "TD";
                label2.Text = "Please select account to transfer from";
                tableLayoutPanel4.Visible = false;
                tableLayoutPanel2.Visible = true;

            }
        }

        private void button20_Click(object sender, EventArgs e)
        {
            tableLayoutPanel4.Visible = false;
            tableLayoutPanel1.Visible = true;
        }

        private void tableLayoutPanel9_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button23_Click(object sender, EventArgs e)
        {//Return to selected Account
            tableLayoutPanel9.Visible = false;
            tableLayoutPanel2.Visible = true;
        }

        private void button24_Click(object sender, EventArgs e)
        {//return to main
            tableLayoutPanel9.Visible = false;
            tableLayoutPanel1.Visible = true;
        }

        private void button22_Click(object sender, EventArgs e)
        {
            tableLayoutPanel8.Visible = false;
            tableLayoutPanel1.Visible = true;
        }

        private void button22_Click_1(object sender, EventArgs e)
        {
            tableLayoutPanel8.Visible = false;
            tableLayoutPanel1.Visible = true;
        }
    }
}
