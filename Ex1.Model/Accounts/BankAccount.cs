using System;

namespace Ex1.Model.Accounts
{
    public abstract class BankAccount
    {
        public BankAccount(long id, decimal sum, long owner)
        {
            Id = id;
            Sum = sum;
            Owner = owner;
            IsActive = true;
        }

        public BankAccount(long id, decimal sum) : this(id, sum, 0)
        {
        }

        public BankAccount(long id) : this(id, 0, 0)
        {
        }

        public BankAccount()
        {
        }

        internal long Id { get; }
        private long Owner { get; }
        public decimal Sum { get; protected set; }
        private bool IsActive { get; set; }

        public long GetId()
        {
            return Id;
        }

        public long GetOwner()
        {
            return Owner;
        }


        public void Close()
        {
            if (Sum != 0) throw new Exception("Счет не может быть закрыт при положителыном балансе");

            IsActive = false;
        }

        public bool GetStatus()
        {
            return IsActive;
        }

        public static void ValidationAmount(decimal amount)
        {
            if (amount <= 0)
                throw new ArgumentOutOfRangeException($"Сумма операции ={amount}, а должна быть больше нуля");
        }

        private protected void EnsureAccountIsActive()
        {
            if (!IsActive)
                throw new Exception("Операция невозможна для закрытого счета Id={Id}");
        }

        //Добавить обработку параметров в методах пополнения и списания денег со счета.
        //Выбрасывать соответствующие исключения.
        //Добавить обработку исключений при использовании этих методов.

        public virtual void AddFunds(decimal amount)
        {
            ValidationAmount(amount);
            EnsureAccountIsActive();
            Sum += amount;
        }

        public virtual void WithdrawFunds(decimal amount)
        {
            ValidationAmount(amount);
            EnsureAccountIsActive();
            if (amount > Sum)
                throw new Exception("Сумма списания больше остатка");
            Sum -= amount;
        }
    }
}
