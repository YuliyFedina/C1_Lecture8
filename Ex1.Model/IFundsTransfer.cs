using Ex1.Model.Accounts;

namespace Ex1.Model
{
    public interface IFundsTransfer
    {
        void TransferFunds(BankAccount sender, BankAccount recipient, decimal sum);
    }
}