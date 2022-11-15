using System;
namespace Gomoku.Core.Domain
{
    public class Board
    {
        public Board()
        {
        }
        public int Column { get; set; }
        public int Row { get; set; }
        public int Player { get; set; }
    }
}

