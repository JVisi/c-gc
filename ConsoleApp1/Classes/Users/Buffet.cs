using System;
using System.Collections.Generic;
using System.Text;

namespace TicketManager.Classes.Users
{
    public class Buffet:AverageUser
    {
        string buffetId;

        public Buffet(string buffetId)
        {
            this.buffetId = buffetId;
        }

        public static bool isTicketOnline( Ticket ticket) {
            return ticket.isOnlineBought();
        }
        public override string getId()
        {
            return this.buffetId;
        }
    }
}
