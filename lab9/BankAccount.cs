using System;
using static lab9.Program;

namespace lab9
{
    internal class BankAccount
    {
        static private ulong number = CreateAccountNumber();
        private double balance;
        private AccountTypes type;
        private bool flag;
        static private ulong CreateAccountNumber()
        {
            Random n = new Random(0);
            bool flag = false;
            do
            {
                flag = ulong.TryParse(Convert.ToString(n.Next()), out number);
            } while (!flag);
            return (number);
        }
        public BankAccount(AccountTypes type)
        {
            this.type = type;
            CreateNewAccountNumber();
        }
        public BankAccount(double balance)
        {
            this.balance = balance;
            CreateNewAccountNumber();
        }
        public BankAccount(double balance, AccountTypes type)
        {
            this.balance = balance;
            this.type = type;
            CreateNewAccountNumber();
        }
        public void CreateNewAccountNumber()
        {
            BankAccount.number += 1;
        }
        public void WithdrawMoney(double sum)
        {
            if (sum > balance)
            {
                throw new ArgumentOutOfRangeException("У вас нет таких денег.");
            }
            else
            {
                balance -= sum;
            }

        }
        public void PutMoney(double sum, BankTransaction operation)
        {
            balance += sum;
            operation.Time();
        }
        public void TransferMoney(ref BankAccount account_taker, double sum)
        {
            BankTransaction transaction = new BankTransaction();
            byte k = 0;
            if (balance >= sum)
            {
                k++;
            }
            WithdrawMoney(sum);
            if (k == 1)
            {
                account_taker.PutMoney(sum, transaction);
            }

        }
        public void Print()
        {
            Console.WriteLine($"Номер счёта: {number}\nБаланс: {balance}\nТип счёта: {type}");
        }
    }
}