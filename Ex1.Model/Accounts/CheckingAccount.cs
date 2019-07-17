using System;

namespace Ex1.Model.Accounts
{
    public class CheckingAccount : BankAccount
    {
        public CheckingAccount(long id, decimal sum) : base(id, sum)
        {
        }

        public CheckingAccount(long id) : base(id)
        {
        }

        public CheckingAccount(long id, decimal sum, decimal serviceCharge)
            : base(id, sum)
        {
            ServiceCharge = serviceCharge;
        }

        public decimal ServiceCharge { get; }

        public void WithdrawCheckingAccount()
        {
            ValidationAmount(ServiceCharge);
            EnsureAccountIsActive();
            if (ServiceCharge > Sum) throw new Exception("Сумма списания больше остатка");
            Sum -= ServiceCharge;
        }
    }
}
