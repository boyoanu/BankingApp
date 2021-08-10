using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Moq;

namespace BankingApp.Tests
{
    [TestClass]
    public class BankAccountTests
    {

        [TestMethod]
        public void Deposit_NegativeAmount_BalanceUnchanged()
        {
            // Arrange
            Mock<IFraudDetector> monitorMock = new Mock<IFraudDetector>();

            double initialBalance = 0;
            BankAccount account = new BankAccount(monitorMock.Object, "Demo Account", "000010001", "Savings", initialBalance);
            double amountToDeposit = -5000;
            double expectedResult = 0;

            monitorMock.Setup(m => m.IsSuspicious(amountToDeposit)).Returns(false);


            // Act
            double actualResult = account.Deposit(amountToDeposit);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }


        [TestMethod]
        public void Deposit_ValidAmount_BalanceIncreased()
        {
            // Arrange
            Mock<IFraudDetector> monitorMock = new Mock<IFraudDetector>();

            double initialBalance = 2000;
            BankAccount account = new BankAccount(monitorMock.Object, "Demo Account", "000010001", "Savings", initialBalance);
            double amountToDeposit = 5000;
            double expectedResult = 7000;

            monitorMock.Setup(m => m.IsSuspicious(amountToDeposit)).Returns(false);

            // Act
            double actualResult = account.Deposit(amountToDeposit);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
            monitorMock.Verify(m => m.IsSuspicious(amountToDeposit), Times.Once);
            monitorMock.Verify(m => m.RaiseAlarm("000010001", "Demo Account", amountToDeposit), Times.Never);
        }


        [TestMethod]
        public void Deposit_SuspiciousAmount_AlarmRaised()
        {
            // Arrange
            Mock<IFraudDetector> monitorMock = new Mock<IFraudDetector>();

            double initialBalance = 100000;
            BankAccount account = new BankAccount(monitorMock.Object, "Demo Account", "000010001", "Savings", initialBalance);
            double amountToDeposit = 2500000;
            double expectedResult = initialBalance + amountToDeposit;

            monitorMock.Setup(m => m.IsSuspicious(amountToDeposit)).Returns(true);

            // Act
            double actualResult = account.Deposit(amountToDeposit);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
            monitorMock.Verify(m => m.IsSuspicious(amountToDeposit), Times.Once);
            monitorMock.Verify(m => m.RaiseAlarm("000010001", "Demo Account", amountToDeposit), Times.Once);
        }


        //[TestMethod]
        //[DataRow(500, DisplayName = "Tiny amount")]
        //[DataRow(5000, DisplayName = "Small amount")]
        //[DataRow(100000, DisplayName = "Large amount")]
        //public void Deposit_DifferentValidAmounts_BalanceIncreased(double amount)
        //{
        //    // Arrange
        //    double initialBalance = 2000;
        //    BankAccount account = new BankAccount("Demo Account", "000010001", "Savings", initialBalance);
        //    double amountToDeposit = amount;
        //    double expectedResult = initialBalance + amount;

        //    // Act
        //    double actualResult = account.Deposit(amountToDeposit);

        //    // Assert
        //    Assert.AreEqual(expectedResult, actualResult);
        //}


        //[TestMethod]
        //public void GetBalance_WhenNotImplemented_ThrowsException()
        //{
        //    // Arrange
        //    BankAccount account = new BankAccount("Demo Account", "000010001", "Savings");

        //    // Assert
        //    Assert.ThrowsException<NotImplementedException>(() =>
        //    {
        //        try
        //        {
        //            // Act
        //            double actualResult = account.GetBalance();
        //        }
        //        catch (NotImplementedException ex)
        //        {
        //            throw ex;
        //        }
        //    });
        //}


        //[TestMethod]
        //public void Withdraw_NegativeAmount_BalanceUnchanged()
        //{
        //    // Arrange
        //    double initialBalance = 15000;
        //    BankAccount account = new BankAccount("Demo Account", "000010001", "Current", initialBalance);
        //    double amountToWithdraw = -2500;
        //    double expectedResult = initialBalance;

        //    // Act
        //    double actualResult = account.Withdraw(amountToWithdraw);

        //    // Assert
        //    Assert.AreEqual(expectedResult, actualResult);
        //}


        //[TestMethod]
        //[DataRow(16000)]
        //[DataRow(25000)]
        //[DataRow(15000.01)]
        //public void Withdraw_InsufficientFunds_BalanceUnchanged(double amount)
        //{
        //    // Arrange
        //    double initialBalance = 15000;
        //    BankAccount account = new BankAccount("Demo Account", "000010001", "Current", initialBalance);
        //    double amountToWithdraw = amount;
        //    double expectedResult = initialBalance;

        //    // Act
        //    double actualResult = account.Withdraw(amountToWithdraw);

        //    // Assert
        //    Assert.AreEqual(expectedResult, actualResult);
        //}


        //[TestMethod]
        //[DataRow(1500)]
        //[DataRow(5000)]
        //[DataRow(3300.55)]
        //[DataRow(500.33)]
        //public void Withdraw_ValidAmount_BalanceDecreases(double amount)
        //{
        //    // Arrange
        //    double initialBalance = 15000;
        //    BankAccount account = new BankAccount("Demo Account", "000010001", "Current", initialBalance);
        //    double amountToWithdraw = amount;
        //    double expectedResult = initialBalance - amountToWithdraw;

        //    // Act
        //    double actualResult = account.Withdraw(amountToWithdraw);

        //    // Assert
        //    Assert.AreEqual(expectedResult, actualResult);
        //}
    }
}
