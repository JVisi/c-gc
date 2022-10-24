using System;
using System.Collections.Generic;
using System.Text;

namespace TicketManager.Classes.Users
{
    public class Cashier : AverageUser
    {
        string cashierId;

        public Cashier(string id) {
            this.cashierId = id;
        }

        public override string getId()
        {
            return this.cashierId;
        }

    }
}
