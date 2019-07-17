using System;
using Ex1.Model.Accounts;

namespace Ex1.Model
{
    public sealed class Bank : IFundsTransfer
    {
        public static void Transaction(BankAccount from, BankAccount to, decimal sum)
        {
            from.WithdrawFunds(sum);
            try
            {
                to.AddFunds(sum);
            }
            catch
            {
                from.AddFunds(sum);
                throw new Exception("Операция перевода средств между счетами не может быть выполнена");
            }
        }

        public void TransferFunds(BankAccount sender, BankAccount recipient, decimal sum)
        {
            if (sender.Sum >= sum)
            {
                sender.WithdrawFunds(sum);
                recipient.AddFunds(sum);
            }
        }
    }
}
