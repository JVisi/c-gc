using System;
using System.Collections.Generic;
using System.Text;

namespace TicketManager.Classes.Users
{
    public class Visitor:AverageUser
    {
        public Visitor()
        {
        }

        public void payOnline() { }

        public override string getId()
        {
            return "Visitor";
        }
    }
}
