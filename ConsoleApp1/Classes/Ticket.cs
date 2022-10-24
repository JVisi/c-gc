using System;
using System.Collections.Generic;
using System.Text;

namespace TicketManager.Classes
{
    public class Ticket
    {
        string boughtBy;
        List<Coordinate> bookedSeats;
        string ticketId;
        Screening screening;
        int price;
        bool onlineBought;
        public Ticket(string boughtBy, List<Coordinate> bookedSeats, Screening scr, int price, bool onlineBought) {
            this.ticketId = generateId();
            this.boughtBy = boughtBy;
            this.bookedSeats = bookedSeats;
            this.screening = scr;
            this.price = price;
            this.onlineBought = onlineBought;
        }
        public bool isOnlineBought() { return this.onlineBought; }
        public void setOnlineBought(bool x) { this.onlineBought = x; }
        private static string generateId() {
            string key = "";
            for (int i = 0; i < 5; i++)
            {
                Random r = new Random();
                key += (char)r.Next(48, 57);
                key += (char)r.Next(65, 90);
            }
            return key;
        }
        public static void showMyTicket(Ticket t) {
            Console.WriteLine(t.boughtBy+"  "+t.screening.getMovie().getTitle()+"  "+t.price+"Ft.");
            Console.WriteLine("Jegy azonosító: "+t.ticketId);
            Console.WriteLine("Foglalt székek: ");
            foreach (Coordinate item in t.bookedSeats)
            {
                Console.Write(item.row+".sor " +item.column+".szék ");
            }
        }
        public int getPrice() { return this.price; }
        public Screening getScreening() { return this.screening; }
        public string getId() { return this.ticketId; }
        public List<Coordinate> getBookedSeats() { return this.bookedSeats; }
        public void setPrice(int price) {
            this.price = price;
        }
    }
}
