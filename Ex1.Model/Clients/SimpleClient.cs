using System;
using System.Collections.Generic;
using System.Text;

namespace Ex1.Model.Clients
{
    public class SimpleClient : BankClient
    {
        public SimpleClient(long id, string name) : base(id, name)
        {
        }

        public override int MaxAccounts => 3;
    }
}
