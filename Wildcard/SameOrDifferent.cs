using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Wildcard.Utility;

namespace Wildcard
{
    // base class - method to add instuctions !!!!
    // method for next suit percentage chance 
    // add get player name method to player class
    internal class SameOrDifferent : Game
    {
        protected override void setUp()
        {
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.White;
            Clear();
            GameDeck = new Deck(2);

            Name = "Same Or Different";
            Print("What is your name?");
            PlayerOne = new Player(GetInput());
        }
        protected override void displayInstuctions()
        {
            Clear();
            Print("Welcome to Apples or Oranges!");
            Print("You will be shown a card and must guess if the next card will be the same suit or a different suit.");
            Print("If you guess correctly, you earn 1 point.");
            Print("Try to get the highest score before the deck runs out.");
            Pause();
        }
        public override void BeginGame()
        {
            setUp();
            displayInstuctions();
            while (GameDeck.DeckSize >= 2)
            {
                Clear();
                banner();

                playRound();
                Pause();
            }

            endGame();
        }
        private void playRound()
        {
            Card drawnCard = drawAndDisplay();
            bool guess = getPlayerGuess();

            Card nextCard = drawAndDisplay();
            bool compare = compareCardSuit(drawnCard, nextCard);

            evaluateGuess(guess, compare);
        }
        protected void banner()
        {
            PrintBorder();
            Print(Name);
            PrintBorder();
            Print($"Score: {PlayerOne.Points}, Cards Left: {GameDeck.DeckSize}");
            PrintBorder();
        }
        private Card drawAndDisplay()
        {
            Card card = GameDeck.DrawCard();
            printCardInformation(card);
            return card;
        }
        private void printCardInformation(Card card)
        {
            Print($"\nThe card drawn is the {card.CardInformation()}");
            Print(card.Appearance);
        }
        private bool getPlayerGuess()
        {
            List<string> sameDiff = new List<string>
            {
                "Same",
                "Different"
            };

            Print("Will the Suit of next card be the same or different?");
            for (int i = 0; i < sameDiff.Count; i++)
            {
                Print($"[{i + 1}] {sameDiff[i]} ");
            }

            switch (GetInput())
            {
                case "1":
                    return true;
                case "2":
                    return false;
                default:
                    Print("Pick a valid option!!!\n");
                    getPlayerGuess();
                    break;
            }

            return false;
        }
        private bool compareCardSuit(Card card, Card compareCard)
        {
            if (card.Suit.Equals(compareCard.Suit))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private void evaluateGuess(bool guess, bool compare)
        {
            if ((guess && compare) | (!guess && !compare))
            {
                Print("You Guess Correctly!! You get +1 points");
                PlayerOne.AddPoints(1);
            }
            else
            {
                Print("You did not guess correctly.");
            }
        }
        protected override void endGame() => Print($"The game has ended. Your final score is {PlayerOne.Points}!");
    }
}
