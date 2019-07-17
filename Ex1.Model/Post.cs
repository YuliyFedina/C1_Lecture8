using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Ex1.Model.Accounts;

namespace Ex1.Model
{
    public sealed class Post : IFundsTransfer
    {
        public void TransferFunds(BankAccount sender, BankAccount recipient, decimal sum)
        {
            if (sender.Sum >= sum)
            {
                sender.WithdrawFunds(sum);
                SendMessage(recipient, $"Можете снять {sum} рублей в ближайшем отделении");
                Thread.Sleep(1000 * 10);

                recipient.AddFunds(sum);
            }
        }

        public void SendMessage(BankAccount account, string message)
        {

        }
    }
}
