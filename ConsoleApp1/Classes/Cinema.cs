using System;
using System.Collections.Generic;
using System.Text;

namespace TicketManager.Classes
{
    public class Cinema
    {   
        List<Screening> screenings;
        public Cinema(List<Screening> screenings) {

            this.screenings = screenings;
        }
        public void addMovie()
        {
            Console.WriteLine("A film neve?");
            string title = Console.ReadLine();
            Console.WriteLine("A film hossza?");
            string length = Console.ReadLine();
            Console.WriteLine("A film műfaja");
            string genre = Console.ReadLine();
            Console.WriteLine("A film időpontja?");
            DateTime date = DateTime.Parse(Console.ReadLine());
            screenings.Add(new Screening(new Movie(title,length,genre), date, null));
            Console.WriteLine("Film hozzáadva");
        }
        public void listScreenings() {

            foreach (Screening scr in screenings)
            {
                showData(scr);
            }
        }
        public Ticket bookTicket() {

            Console.WriteLine("Melyik filmre szeretne menni? (név kis-nagybetű nem téma)");
            string name = Console.ReadLine();
            Screening current = checkIfExist(name);
            if (current != null)
            {
                List<Coordinate> chairs=current.bookTicket();
                if (chairs.Count != 0)
                {
                    Ticket ticket = createTicket(current, chairs);
                    return ticket;
                }
                else return null;
            }
            else {
                Console.WriteLine("Nincs ilyen film.");
                return null;
            }
        }
        public void deleteMovie() {
            Console.WriteLine("Melyik filmet szeretnéd törölni?");
            Screening temp = checkIfExist(Console.ReadLine());
            if (temp != null) {
                screenings.Remove(temp);
                Console.WriteLine("Törölve");
                Console.ReadLine();
            }
            else Console.WriteLine("Nincs ilyen film");
        }
        public void updateMovie() {
            Console.WriteLine("Melyik filmet szeretné módosítani? (név)");
            Screening temp = checkIfExist(Console.ReadLine());
            if (temp != null)
            {
                addMovie();
                screenings.Remove(temp);
            }
            else {
                Console.WriteLine("Nincs ilyen film");
            }

        }
        private Ticket createTicket(Screening scr, List<Coordinate> chairs) {
            //Jegy alapesetben 5000, majd a menu eldönti hogy milyen a user és hol akar vásárolni, és úgy levonja a kedvezményt
            Console.Clear();
            Console.WriteLine("Milyen névre szeretne foglalni?");
            string name = Console.ReadLine();
            return new Ticket(name,chairs,scr,1100*chairs.Count,false);
            
        }
        private Screening checkIfExist(string name) {
            foreach (var item in screenings)
            {
                if (item.getMovie().getTitle() == name) {
                    return item;
                }
            }
            return null;
        }
        private void showData(Screening s) {
            Movie m = s.getMovie();
            Console.WriteLine(m.getTitle() + " "+m.getLength() + " "+m.getGenre());
            Console.WriteLine(s.getDate());
            Console.WriteLine();
        }
    }
}
