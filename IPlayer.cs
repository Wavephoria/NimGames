using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NimGames
{
    internal interface IPlayer
    {
        string Name { get; }
        public int Wins { get; set; }
        public int Losses { get; set; }
    }
}
