using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApp
{
    interface IBankAccount
    {
     public string AccountName { get; }

     public string AccountNumber { get; }

     public string AccountType { get; }

     public double CheckBalance();

     public double Withdrawl(double amountToWithdrawl);

     public double Deposit(double amountToDeposit);
        double CheckBalance(double accountBalance);
    }
}
