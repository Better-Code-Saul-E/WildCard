using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Wildcard.Utility;

namespace Wildcard
{
    internal class Card
    {
        // add enums to show unicode card characters 
        // method to print cards 


        public string Suit { get; set; }
        public int Value { get; set; }
        public string Rank { get; set; }
        public string Appearance { get; set; }

        public Card(string suit, string rank, int value)
        {
            Suit = suit;
            Rank = rank;
            Value = value;

            SetAppearance();
        }
        // rename it to tostring ??? makes more sense 
        public string CardInformation() => $"{Rank} of {Suit}";

        public void SetAppearance()
        {
            string suit;

            if (Suit == "Hearts")
            {
                suit = "\u2665";
            }
            else if (Suit == "Diamonds")
            {
                suit = "\u2666";
            }
            else if (Suit == "Clubs")
            {
                suit = "\u2663";
            }
            else
            {
                suit = "\u2660";
            }
            if (Value >= 10)
            {
                Appearance = @$"
┌─────────┐
│ {Value}      │
│         │
│    {suit}    │
│         │
│      {Value} │
└─────────┘
";
            }
            else 
            {
                Appearance = @$"
┌─────────┐
│ {Value}       │
│         │
│    {suit}    │
│         │
│       {Value} │
└─────────┘
";
            }
        }
    }
}
