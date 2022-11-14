using System;
namespace Gomoku.Core.Domain
{
    public class Player
    {
        public Player()
        {
        }
        public string Name { get; set; }
        public int Win { get; set; }
        public int Loss { get; set; }
    }
}

