using System;
using System.Collections.Generic;
using System.Text;

namespace TicketManager.Classes.Users
{
    public class Admin : AverageUser
    {

        private string id;

        public Admin(string id)
        {
            this.id = id;
        }

        public override string getId()
        {
            return this.id;
        }
    }
}
