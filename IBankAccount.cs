using System;
using System.Collections.Generic;
using System.Text;

namespace BankingApp
{
    interface IBankAccount
    {
        public string AccountName { get; }

        public string AccountNumber { get; }

        public string AccountType { get; }

        public double GetBalance();

        public double Withdraw(double amountToWithdraw);

        public double Deposit(double amountToDeposit);
    }
}
