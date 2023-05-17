using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Model
{
    public class Move
    {
        public Guid GameId { get; set; }
        public Player Player { get; set; }
        public int Position { get; set; }

    }
}
