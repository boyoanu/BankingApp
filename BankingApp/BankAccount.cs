using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApp
{
    public class BankAccount : IBankAccount
    {

        private double _accountBalance;
        private string _accountName;
        private string _accountNumber;
        private string _accountType;

        public BankAccount(string accountName, string accountNumber, string accountType, double startingBalance = 0)
        {
            _accountName = accountName;
            _accountNumber = accountNumber;
            _accountType = accountType;
            _accountBalance = startingBalance;
        }

        public string AccountName => _accountName;

        public string AccountNumber => _accountNumber;

        public string AccountType => _accountType;

        public double CheckBalance()
        {
            throw new NotImplementedException();
        }

        public double CheckBalance(double accountBalance)
        {
            return accountBalance;
        }

        public double Deposit(double amountToDeposit)
        {
            // Validate the input value to ensure it is positive;

            if (amountToDeposit <= 0)
            {
                Console.WriteLine("Invalid amount! Please enter a positive value.");
            }

            else
            {
                _accountBalance += amountToDeposit;
            }
            return _accountBalance;
        }

        public double Withdrawl(double amountToWithdrawl)
        {
            if (amountToWithdrawl <= 0)
            {
                Console.WriteLine("Invalid amount ! Please enter a positive value");
            }

            else if (amountToWithdrawl > _accountBalance)
            {
                Console.WriteLine("Insufficient funds ! Please enter amount less than your balance.");
            }

            else
            {
                _accountBalance -= amountToWithdrawl;
            }

            return _accountBalance;
        }

       
    }
}