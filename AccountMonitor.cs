using System;
using System.Collections.Generic;
using System.Text;

namespace BankingApp
{
    public class AccountMonitor : IFraudDetector
    {

        private readonly double _transactionLimit = 1000000;

        public virtual bool IsSuspicious(double amount)
        {
            if (amount <= _transactionLimit)
            {
                Console.WriteLine("Amount is within safe limits.");
                return false;
            }
            else
            {
                Console.WriteLine("Amount exceeds the stipulated threshold!");
                return true;
            }
        }


        public virtual void RaiseAlarm(string accountNo, string accountName, double amount)
        {
            Console.WriteLine("Notifying the EFCC of large transaction amount...");
            Console.WriteLine($"Account Name: {accountName} \n Account Number: {accountNo} \n: Amount: {amount} \n Transaction Date: {DateTime.Now}");
        }
    }
}
