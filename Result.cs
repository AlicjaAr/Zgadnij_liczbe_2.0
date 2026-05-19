using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zgadnij_liczbe
{
    public class Result
    {
        public string PlayerName { get; set; }

        public int Attempts { get; set; }

        public int TimeInSeconds { get; set; }

        public Difficulty Difficulty { get; set; }

        public bool IsNewGamePlus { get; set; }
    }
}
