using NUnit.Framework;
using System;

namespace TestApp.Tests;

[TestFixture]
public class BankAccountTests
{
    [Test]
    public void Test_Constructor_InitialBalanceIsSet()
    {   
        // Arrange
        double initialBalance = 100.00;

        // Act
        BankAccount account = new BankAccount(initialBalance);

        // Assert
        Assert.AreEqual(initialBalance, account.Balance);
    }

    [Test]
    public void Test_Deposit_PositiveAmount_IncreasesBalance()
    {
        // Arrange
        double initialBalance = 100.00;
        double depositAmount = 50.00;
        BankAccount account = new BankAccount(initialBalance);

        // Act
        account.Deposit(depositAmount);

        // Assert
        Assert.AreEqual(initialBalance + depositAmount, account.Balance);
    }

    [Test]
    public void Test_Deposit_NegativeAmount_ThrowsArgumentException()
    {
        // Arrange
        double initialBalance = 100.0;
        double invalidDepositAmount = -50.0;
        BankAccount account = new BankAccount(initialBalance);

        // Act & Assert
        Assert.Throws<ArgumentException>(() => account.Deposit(invalidDepositAmount));
    }

    [Test]
    public void Test_Withdraw_ValidAmount_DecreasesBalance()
    {
        // Arrange
        double initialBalance = 100.0;
        double withdrawalAmount = 30.0;
        BankAccount account = new BankAccount(initialBalance);

        // Act
        account.Withdraw(withdrawalAmount);

        // Assert
        Assert.AreEqual(initialBalance - withdrawalAmount, account.Balance);
    }

    [Test]
    public void Test_Withdraw_NegativeAmount_ThrowsArgumentException()
    {
        // Arrange
        double initialBalance = 100.0;
        double invalidWithdrawalAmount = -30.0;
        BankAccount account = new BankAccount(initialBalance);

        // Act & Assert
        Assert.Throws<ArgumentException>(() => account.Withdraw(invalidWithdrawalAmount));
    }

    [Test]
    public void Test_Withdraw_AmountGreaterThanBalance_ThrowsArgumentException()
    {
        // Arrange
        double initialBalance = 100.0;
        double invalidWithdrawalAmount = 150.0;
        BankAccount account = new BankAccount(initialBalance);

        // Act & Assert
        Assert.Throws<ArgumentException>(() => account.Withdraw(invalidWithdrawalAmount));
    }
}
