using System;
using System.Collections.Generic;
using System.Text;

namespace Ex1.Model.Clients
{
    public class VipClient : BankClient
    {
        public VipClient(long id, string name) : base(id, name)
        {
        }

        public override int MaxAccounts => 10;
    }
}
