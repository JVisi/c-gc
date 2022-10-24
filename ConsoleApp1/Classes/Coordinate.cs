using System;
using System.Collections.Generic;
using System.Text;

namespace TicketManager.Classes
{
    public class Coordinate
    {
        public int column;
        public int row;
        public Coordinate(int x, int y) {
            this.column = x;
            this.row = y;
        }
    }
}
