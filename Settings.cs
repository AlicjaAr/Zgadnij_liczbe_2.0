using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zgadnij_liczbe
{
    public class Settings
    {
        public Language Language { get; set; }

        public bool AskForBetMode { get; set; }

        public Settings()
        {
            Language = Language.PL;
            AskForBetMode = true;
        }
    }
}
