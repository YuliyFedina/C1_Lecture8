using System;

namespace Ex1.Model.Accounts
{
    public class BullionAccount : BankAccount
    {
        public enum Metal
        {
            Gold,
            Silver
        }

        public BullionAccount(long id, decimal sum) : base(id, sum)
        {
        }

        public BullionAccount(long id) : base(id)
        {
        }

        public BullionAccount()
        {
        }

        public BullionAccount(long id, decimal sum, decimal cource, Metal metalOfAccount) : base(id, sum)
        {
            MetalOfAccount = metalOfAccount;
            Cource = cource;
        }

        public decimal Cource { get; set; }
        public Metal MetalOfAccount { get; }

        public override void AddFunds(decimal amount)
        {
            if (Cource == 0) throw new InvalidOperationException("Курс не может быть равен 0");

            base.AddFunds(amount / Cource);
        }

        public override void WithdrawFunds(decimal amount)
        {
            if (Cource == 0) throw new InvalidOperationException("Курс не может быть равен 0");

            base.WithdrawFunds(amount / Cource);
        }
    }
}
