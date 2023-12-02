using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HWModule14
{
    public class Karta
    {
        public string Suit { get; set; }
        public string Rank { get; set; }

        public Karta(string suit, string rank)
        {
            Suit = suit;
            Rank = rank;
        }
    }
}
