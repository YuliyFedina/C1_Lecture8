namespace Ex1.Model.Accounts
{
    public class SavingAccount : BankAccount
    {
        public SavingAccount(long id, decimal sum, bool isActive) : base(id, sum, isActive)
        {
        }

        public SavingAccount(long id, decimal sum) : base(id, sum)
        {
        }

        public SavingAccount(long id) : base(id)
        {
        }

        
    }
}
