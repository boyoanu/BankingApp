using System;
using System.Collections.Generic;
using System.Text;

namespace BankingApp
{
    public interface IFraudDetector
    {
        public bool IsSuspicious(double amount);


        public void RaiseAlarm(string accountNo, string accountName, double amount);
    }
}
