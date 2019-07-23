using System;

namespace Ex1.Model.Accounts
{
    public class AccumulationAccount : BankAccount
    {
        public AccumulationAccount(long id, decimal sum) : base(id, sum)
        {
        }

        public AccumulationAccount(long id) : base(id)
        {
        }

        public AccumulationAccount()
        {
        }

        public AccumulationAccount(long id, decimal sum, decimal initialInstalment, decimal rate) : base(id, sum)
        {
            InitialInstalment = initialInstalment;
            Rate = rate;
        }

        public decimal InitialInstalment { get; set; }
        public decimal Rate { get; set; }

        public override void WithdrawFunds(decimal amount)
        {
            if (Sum - InitialInstalment < amount)
                throw new Exception(
                    $"Нельзя снять с накопительного счета сумму ={amount}, большую первоначального взноса ={InitialInstalment}");
            base.WithdrawFunds(amount);
        }

        public void Capitalization()
        {
            EnsureAccountIsActive();
            Sum += Sum * Rate / 12;
        }
    }
}
