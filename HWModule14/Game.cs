using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HWModule14
{
    public class Game
    {
        private List<Player> players = new List<Player>();
        private List<Karta> deck = new List<Karta>();

        public Game(params string[] playerNames)
        {
            foreach (var playerName in playerNames)
            {
                players.Add(new Player { Name = playerName });
            }

            InitializeDeck();
            ShuffleDeck();
            DealCards();
        }

        private void InitializeDeck()
        {
            string[] suits = { "Hearts", "Diamonds", "Clubs", "Spades" };
            string[] ranks = { "6", "7", "8", "9", "10", "Jack", "Queen", "King", "Ace" };

            foreach (var suit in suits)
            {
                foreach (var rank in ranks)
                {
                    deck.Add(new Karta(suit, rank));
                }
            }
        }

        private void ShuffleDeck()
        {
            var random = new Random();
            deck = deck.OrderBy(c => random.Next()).ToList();
        }

        private void DealCards()
        {
            int playerIndex = 0;
            foreach (var card in deck)
            {
                players[playerIndex].Cards.Add(card);
                playerIndex = (playerIndex + 1) % players.Count;
            }
        }

        public void Play()
        {
            while (players.All(p => p.Cards.Any()))
            {
                var cardsInPlay = players.Select(p => p.Cards.First()).ToList();
                var winningCard = cardsInPlay.OrderByDescending(c => GetCardValue(c)).First();

                var winningPlayer = players.First(p => p.Cards.First() == winningCard);
                players.ForEach(p => p.Cards.RemoveAt(0));
                winningPlayer.Cards.AddRange(cardsInPlay);

                DisplayRoundResults(winningPlayer);
            }

            var winner = players.OrderByDescending(p => p.Cards.Count).First();
            Console.WriteLine($"{winner.Name} wins the game!");
        }

        private int GetCardValue(Karta card)
        {
            switch (card.Rank)
            {
                case "6":
                    return 6;
                case "7":
                    return 7;
                case "8":
                    return 8;
                case "9":
                    return 9;
                case "10":
                case "Jack":
                case "Queen":
                case "King":
                    return 10;
                case "Ace":
                    return 11;
                default:
                    return 0;
            }
        }

        private void DisplayRoundResults(Player winningPlayer)
        {
            Console.WriteLine($"{winningPlayer.Name} wins the round!");
            foreach (var player in players)
            {
                player.DisplayCards();
            }
        }
    }
}
