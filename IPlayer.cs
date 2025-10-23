using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace NimGames
{
    internal interface IPlayer
    {
        // This is being used to be able to have Player and AI use the same logic in main program
        string Name { get; }
        public int Wins { get; set; }
        public int Losses { get; set; }

    }
}
