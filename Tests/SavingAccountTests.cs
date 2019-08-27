using System;
using Ex1;
using Ex1.Model.Accounts;
using NUnit.Framework;

namespace Tests
{
    public class SavingAccountTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void AddFunds()
        {
            //Arrange
            var account = new SavingAccount(1, 0);
            var sumOfFunds = 100;

            //Act
            account.AddFunds(sumOfFunds);

            //Assert
            Assert.That(account.Sum, Is.EqualTo(sumOfFunds));
        }

        [Test]
        public void WithdrawFunds()
        {
            //Arrange
            var sumOfFunds = 50;
            var account = new SavingAccount(1, sumOfFunds);
            
            //Act
            account.WithdrawFunds(sumOfFunds);

            //Assert
            Assert.That(account.Sum, Is.EqualTo(0));
        }

        [Test]
        public void CloseActiveAccount()
        {
            //Arrange
            var account = new SavingAccount(1, 0);

            //Act
            account.Close();

            //Assert
            Assert.That(account.GetStatus, Is.EqualTo(false));
        }

        [Test]
        public void AddZeroFunds_NotAllowed()
        {
            //Arrange
            var account = new SavingAccount(1, 0);
            var sumOfFunds = 0;
            
            //Act
            //Assert
            try
            {
                account.AddFunds(sumOfFunds);
                Assert.Fail();
            }
            catch (ArgumentOutOfRangeException)
            {

            }
        }

        [Test]
        public void AddFundsForInactiveAccount_NotAllowed()
        {
            //Arrange
            var account = new SavingAccount(1, 0, false);
            var sumOfFunds = 100;

            //Act
            //Assert
            try
            {
                account.AddFunds(sumOfFunds);
                Assert.Fail();
            }
            catch (Exception)
            {
            }
        }

        [Test]
        public void WithdrawZeroFunds_NotAllowed()
        {
            //Arrange
            var account = new SavingAccount(1, 100);
            var sumOfFunds = 0;

            //Act
            //Assert
            try
            {
                account.WithdrawFunds(sumOfFunds);
                Assert.Fail();
            }
            catch (ArgumentOutOfRangeException)
            {
            }
        }

        [Test]
        public void WithdrawFundsForInactiveAccount_NotAllowed()
        {
            //Arrange
            var account = new SavingAccount(1, 0, false);
            var sumOfFunds = 100;

            //Act
            //Assert
            try
            {
                account.WithdrawFunds(sumOfFunds);
                Assert.Fail();
            }
            catch (Exception)
            {
            }
        }

        [Test]
        public void CloseAccountWithPositiveBalance_NotAllowed()
        {
            //Arrange
            var account = new SavingAccount(1, 100);

            //Act
            //Assert
            try
            {
                account.Close();
                Assert.Fail();
            }
            catch (Exception)
            {
            }
        }

        [Test]
        public void CloseInactiveAccount_NotAllowed()
        {
            //Arrange
            var account = new SavingAccount(1, 0, false);
            account.Close();
            //Act
            //Assert
            try
            {
                account.Close();
                Assert.Fail();
            }
            catch (Exception)
            {
            }
        }
    }
}