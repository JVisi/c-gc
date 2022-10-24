using System;
using System.Collections.Generic;
using System.Text;
using TicketManager.Classes.Users;

namespace TicketManager.Classes
{
    public abstract class TicketHandler
    {
        public static Ticket ticketPayMethod(Ticket ticket, AverageUser currentUser)
        {

            if (ticket != null)
            {
                if (currentUser.GetType() == typeof(Cashier))
                {
                    return ticket;      //Ha kasszás nincs online fizetési opció, nincs kedvezmény
                }

                Console.WriteLine("Hogyan szeretne fizetni? Online/Kassza");
                string answer = Console.ReadLine().ToLower();
                do
                {
                    if (answer == "online")
                    {
                        ticket.setPrice((int)(ticket.getPrice() * 0.85));     //15 os kedvezmény
                        ///Bank osztály -> payOnline;
                        bool payed = Bank.payOnline();
                        do
                        {
                            if (payed)
                            {
                                ticket.setOnlineBought(true);
                                return ticket;

                            }
                        } while (payed != true);
                        return ticket;
                    }
                    else if (answer == "kassza")
                    {
                        return ticket;
                    }
                } while (true);
            }
            else return null;

        }
        public static List<Ticket> deleteTicket(List<Ticket> tickets) {
            Console.WriteLine("Adja meg a jegy azonosítóját");
            string id = Console.ReadLine();
            foreach (Ticket item in tickets)
            {
                if (item.getId() == id) {
                    item.getScreening().freeSeat(item.getBookedSeats());
                    Console.WriteLine("Rendelés törölve");
                    Console.WriteLine("Pénz vissautalva");
                    tickets.Remove(item);
                    return tickets;
                }
            }
            Console.WriteLine("Nincs ilyen rendelés");
            Console.ReadLine();
            return tickets;

        }
        public static Ticket getTicketbyId(List<Ticket> tickets, string id) {

            foreach (Ticket item in tickets)
            {
                if (item.getId() == id)
                {
                    return item;
                }
            }
            return null;
        }
    }
}
