using System;
using System.Collections.Generic;
using System.Text;

namespace TicketManager.Classes
{
    public class Movie
    {
        private string title;
        private string length;
        private string genre;

        public Movie(string title, string length, string genre) {
            this.title = title;
            this.length = length;
            this.genre = genre;
        }
        public string getTitle() { return this.title; }
        public string getLength() { return this.length; }
        public string getGenre() { return this.genre; }
    }
}
