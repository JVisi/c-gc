using System;
using System.Collections.Generic;
using System.Text;

namespace TicketManager.Classes
{
    public class Screening
    {
        int[,] seats;
        Movie movie;
        DateTime date;

        public Screening(Movie m, DateTime date, int[,]? seats) {
            this.movie = m;
            this.date = date;
            this.seats = (seats != null && seats.GetLength(0)<=10 && seats.GetLength(1) <= 10) ? seats : new int[10, 10];
        }
        private void takeSeat(List<Coordinate> coords) {
            foreach (Coordinate coord in coords) {
                seats[coord.column, coord.row] = -1;
            }
        }
        public void freeSeat(List<Coordinate> coords)
        {
            foreach (Coordinate coord in coords)
            {
                seats[coord.column, coord.row] = 0;
            }
        }
        public void showFreeChairs() {
            for (int i = 0; i < this.seats.GetLength(1); i++)
            {

                Console.Write(i + ".sor:");
                Console.Write(i < 10 ? " " : "  ");
                for (int j = 0; j < this.seats.GetLength(0); j++)
                {
                    Console.Write(j+": "+(seats[j, i] == -1 ? "Foglalt" : "Szabad"));
                    Console.Write(j < 10 ? "   " : "  ");
                }
                Console.WriteLine();
            }
        }
        public List<Coordinate> bookTicket() {
            Console.Clear();
            showFreeChairs();

            List<Coordinate> chairs = new List<Coordinate>();
            Console.WriteLine("Mely helyekre szeretne jegyet foglalni? (sorszám székszám)");
            string answer = Console.ReadLine();
            do {
                if (answer.Contains(' '))
                {
                    int chairNumber = Convert.ToInt32(answer.Split(' ')[1]);
                    int rowNumber = Convert.ToInt32(answer.Split(' ')[0]);

                    if (chairNumber > 10 || rowNumber > 10)
                    {
                        Console.WriteLine("Invalid hely");
                    }
                    else if (seats[chairNumber, rowNumber] == -1)
                    {
                        Console.WriteLine("Ez a hely már foglalt");
                    }
                    else
                    {
                        chairs.Add(new Coordinate(chairNumber, rowNumber));
                    }
                }
                else { Console.WriteLine("Figyeljen a helyes adatbevitelre"); }

                answer = Console.ReadLine();
            } while (answer != "");
            Console.WriteLine("A következő helyekre foglaljuk jegyet:");
            showCurrentBook(chairs);
            takeSeat(chairs);
            return chairs;
        }
        private void showCurrentBook(List<Coordinate> chairs) {
            foreach (var item in chairs)
            {
                Console.Write(item.column+".sor "+item.row+". szék  ");
            }
        }
        public DateTime getDate() {
            return this.date;
        }
        public Movie getMovie()
        {
            return this.movie;
        }
    }
}
