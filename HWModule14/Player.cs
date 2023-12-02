using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HWModule14
{
    public class Player
    {
        public string Name { get; set; }
        public List<Karta> Cards { get; set; } = new List<Karta>();

        public void DisplayCards()
        {
            Console.WriteLine($"{Name}'s cards:");
            foreach (var card in Cards)
            {
                Console.WriteLine($"{card.Rank} of {card.Suit}");
            }
            Console.WriteLine();
        }
    }
}
