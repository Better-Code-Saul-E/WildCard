using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Wildcard.Utility;

namespace Wildcard
{
    public enum Suit
    {
        Hearts,
        Diamonds,
        Clubs,
        Spades
    }

    public enum Rank
    {
        Ace,
        Two = 2,
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine,
        Ten,
        Jack,
        Queen,
        King
    }

    internal class Deck
    {
        // method to restart the game ?
        public List<Card> Cards { get; set; }
        public int DeckSize { 
            get { return Cards.Count;}
            }

        public Deck(int deckSize )
        {
            Cards = new List<Card>();
            CreateDeck(deckSize);
            Shuffle();

        }

        public void CreateDeck(int suitCount)
        {
            for (int i = 0; i < suitCount; i++)
            {
                string suit = Enum.GetName(typeof(Suit), i);

                foreach (Rank rank in Enum.GetValues(typeof(Rank)))
                {
                    Cards.Add(new Card(suit, rank.ToString(), (int)rank));
                }
            }
        }

        public void Shuffle()
        {
            Random rand = new Random();
            Cards = Cards.OrderBy(card => rand.Next()).ToList();
        }

        // add option for player to play again 
        public void ResetDeck() { Shuffle(); }

        public Card DrawCard()
        {
            try
            {
                Card cardDrawn = Cards[Cards.Count - 1];
                Cards.RemoveAt(Cards.Count - 1);
                return cardDrawn;
            }
            catch (Exception)
            {
                Console.WriteLine("The deck has run out of cards!");
            }
            
            return null;
        }
    }
}
