using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Wildcard.Utility;

namespace Wildcard
{
    internal class Player
    {
        public string Name { get; set; }
        public int Points { get; set; }
        public List<Card> Hand { get; set; }

        public Player(string name)
        {
            Name = name;
            Points = 0;
            Hand = new List<Card>();
        }

        public void DrawFromDeck(Deck deck)
        {
            Card card = deck.DrawCard();
            if (card != null)
            {
                Hand.Add(card);
                Console.WriteLine($"{Name} Drew {card.Rank} of {card.Suit}");
            }
        }
        public void removeCardAtIndex(int index)
        {
            Hand.RemoveAt(index);
        }

        public void PrintHand()
        {
            Print($"{Name}'s hand:");
            foreach (var card in Hand)
            {
                Print(card.CardInformation());
            }
        }
        public void AddPoints(int points)
        {
            Points += points;
        }
    }
}
