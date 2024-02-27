using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem
{
    public class BankAccountFactory
    {
        private Hashtable accounts = new Hashtable();

        public int CreateAccount()
        {
            BankAccount11 account = new BankAccount11();
            accounts[account.Number] = account;
            return account.Number;
        }

        public int CreateAccount(double balance)
        {
            BankAccount11 account = new BankAccount11(balance);
            accounts[account.Number] = account;
            return account.Number;
        }

        public int CreateAccount(TypeSchet11 type)
        {
            BankAccount11 account = new BankAccount11(type);
            accounts[account.Number] = account;
            return account.Number;
        }

        public int CreateAccount(TypeSchet11 type, double balance)
        {
            BankAccount11 account = new BankAccount11(type, balance);
            accounts[account.Number] = account; ;
            return account.Number;
        }

        public void CloseAccount(int accountNumber)
        {
            if (accounts.ContainsKey(accountNumber))
            {
                accounts.Remove(accountNumber);
                Console.WriteLine($"Account {accountNumber} closed successfully.");
            }
            else
            {
                Console.WriteLine($"Account {accountNumber} not found.");
            }
        }

        public BankAccount11 GetAccount(int accountNumber)
        {
            if (accounts.ContainsKey(accountNumber))
            {
                return accounts[accountNumber] as BankAccount11;
            }
            return null;

        }
    }
}
