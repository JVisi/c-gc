using TicketManager.Classes;
using TicketManager.Classes.Users;
using System;
using System.Collections.Generic;

namespace TicketManager
{
    class CinemaManager
    {
        static AverageUser currentUser;
        static Cinema cinema;
        static List<Ticket> tickets;
        static void Main(string[] args)
        {
            initialize();
            while (true)
            {
                Console.Clear();
                if (currentUser.GetType() == typeof(Buffet)) {
                    while (true) {
                        Console.WriteLine("Mi a jegy ID-ja?");
                        string Id = Console.ReadLine();
                        Ticket t=TicketHandler.getTicketbyId(tickets,Id);
                        if (t == null) { Console.WriteLine("Nem jogosult");Console.ReadLine(); break; ; }
                        bool isOnline = t.isOnlineBought();
                        if (isOnline)
                        {
                            Console.WriteLine("Kedvezményre jogosult");
                        }
                        else {
                            Console.WriteLine("Nem jogosult");
                        }
                        Console.ReadLine();
                    }
                }
                else {
                    Console.Clear();
                    Console.WriteLine("Válasszon egy opciót: ");
                    showOptions();

                    switch (Console.ReadLine()) {
                        case "1": { login(); } break;
                        case "2": { Console.Clear(); cinema.listScreenings(); Console.ReadLine(); } break;
                        case "3": { Console.Clear(); Ticket t = TicketHandler.ticketPayMethod(cinema.bookTicket(), currentUser); if (t != null) { Ticket.showMyTicket(t); tickets.Add(t); Console.ReadLine(); }; } break;
                        case "4": { if (currentUser.GetType() != typeof(Visitor)) { tickets = TicketHandler.deleteTicket(tickets); } else { Console.WriteLine("Nincs ilyen opció"); Console.ReadLine(); } } break;
                        case "5": {
                                if (currentUser.GetType() == typeof(Cashier)) { listTickets(); }
                                else if (currentUser.GetType() == typeof(Admin)) { cinema.addMovie(); Console.ReadLine(); }
                                else { Console.WriteLine("Nincs ilyen opció"); Console.ReadLine(); }
                            } break;
                        case "6": {
                                if (currentUser.GetType() == typeof(Cashier)) { currentUser = new Visitor(); } else if (currentUser.GetType() != typeof(Admin)) { Console.WriteLine("Nincs ilyen opció"); } else { cinema.deleteMovie(); } } break;
                        case "7": { if (currentUser.GetType() != typeof(Admin)) { Console.WriteLine("Nincs ilyen opció"); } else { cinema.updateMovie(); } } break;
                        case "8": { if (currentUser.GetType() != typeof(Admin)) { Console.WriteLine("Nincs ilyen opció"); } else { listTickets(); } } break;
                        case "9": { if (currentUser.GetType() != typeof(Admin)) { Console.WriteLine("Nincs ilyen opció"); } else { currentUser = new Visitor(); } } break;

                        default: { Console.WriteLine("Nincs ilyen opció"); Console.ReadLine(); }; break;
                    }
                }
            }
            Console.ReadLine();
        }
        
        private static void login() {
            Console.WriteLine("Ha ön rendszergazda, adja meg a felhasználónevét");
            Console.WriteLine("Ha pénztáros, adja meg az azonosítóját");
            Console.WriteLine("Ha egyik sem nyomjon enter");
            string answer = Console.ReadLine();
            if (answer == "admin-id")
            {
                Console.WriteLine("Adja meg a jelszavát");
                if (Console.ReadLine() == "admin-psw")
                {
                    currentUser = new Admin("admin-id");
                }
            }
            else if (answer == "cash-id") {
                Console.WriteLine("Adja meg a jelszavát");
                if (Console.ReadLine() == "cash-psw")
                {
                    currentUser = new Cashier("cash_id");
                }
            }
        }
        private static void listTickets() {
            Console.Clear();
            foreach (Ticket item in tickets)
            {
                Ticket.showMyTicket(item); Console.WriteLine("\n");
            }
            Console.ReadLine();
        }
        private static void initialize() {

            //burnt in data, which we would get from a database
            currentUser = new Visitor();
            List<Screening> screenings = new List<Screening>();
            Screening s = new Screening(new Movie("A végrehajtó", "1:23:13", "Szatíra"), DateTime.Now, null);
            Screening s1= new Screening(new Movie("A bosszú_ülők", "1:23:13", "Dráma"), DateTime.Now.AddDays(3), null);
            Screening s2 = new Screening(new Movie("Hoolk, a gumiember", "1:23:13", "Vígjáték"), DateTime.Now.AddDays(2), null);
            Screening s3 = new Screening(new Movie("Wtar Sars", "1:23:13", "akció /Sci-fi"), DateTime.Now, null);
            Screening s4 = new Screening(new Movie("Regényponyva", "1:23:13", "Életrajzi dráma"), DateTime.Now.AddDays(12), null);
            Screening s5 = new Screening(new Movie("Gyűrűk Ura és a lufihajtogató bohóc", "1:23:13", "Dokumentumfilm"), DateTime.Now, null);
            Screening s6 = new Screening(new Movie("Kis Hableány vs Titanic", "1:23:13", "Történelmi"), DateTime.Now.AddDays(8), null);
            Screening s7 = new Screening(new Movie("test", "1:23:13", "Történelmi"), DateTime.Now.AddDays(8), null);
            screenings.Add(s);
            screenings.Add(s1);
            screenings.Add(s2);
            screenings.Add(s3);
            screenings.Add(s4);
            screenings.Add(s5);
            screenings.Add(s6);
            screenings.Add(s7);
            cinema = new Cinema(screenings);
            tickets = new List<Ticket>();
            //Load and config data to operate with
        }
        private static void showOptions() {
            Console.WriteLine("1: Admin/Pénztáros azonosítás");
            Console.WriteLine("2: Filmek listázása");
            Console.WriteLine("3: Jegyvásárlás");
            if (currentUser.GetType()==typeof(Cashier)) {
                Console.WriteLine("4: Jegy törlése");
                Console.WriteLine("5: Jegyek listázása");
                Console.WriteLine("6: Kijelentkezés");
            }
            else if (currentUser.GetType()==typeof(Admin)) {
                Console.WriteLine("4: Jegy törlése");
                Console.WriteLine("5: Film hozzáadása");
                Console.WriteLine("6: Film törlése");
                Console.WriteLine("7: Film módosítása");
                Console.WriteLine("8: Jegyek listázása");
                Console.WriteLine("9: Kijelentkezés");
            }
            Console.WriteLine("0: Kilépés");
        }
    }
}
