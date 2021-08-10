using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xunit.Sdk;

namespace BankingApp.Tests
{
    [TestClass]
    public class BankAccountTests
    {
        public double amountToDeposit { get; private set; }

        //  Testing method Deposit()

        // Test for Negative amount

        // Test for valid amount

        //  Test for non- numeric input
        [TestMethod]

        
        public void Desposit_NegativeAmount_BalanceUnchanged()
        {
            // Arrange
           
            double initialBalance = 0;
            BankAccount account = new BankAccount("Demo Account", "000100001", "Savings", initialBalance);
            double amountToDeposit = -5000;
            double expectedResult = 0;


            //Act

            double actualResult = account.Deposit(amountToDeposit);

            //Assert

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void Desposit_ValidAmount_BalanceIncreased() 
        {
            // Arrange

            double initialBalance = 2000;
            BankAccount account = new BankAccount("Demo Account", "000100001", "Savings", initialBalance);
            double amountToDeposit = 5000;
            double expectedResult = 7000;


            //Act

            double actualResult = account.Deposit(amountToDeposit);

            //Assert

            Assert.AreEqual(expectedResult, actualResult);
        }

     
    }
}