using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Wildcard.Utility;

namespace Wildcard
{
    internal class HigherOrLower : Game
    {
        protected override void setUp()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.BackgroundColor = ConsoleColor.Blue;
            Clear();
            Name = "Higher or Lower";
            GameDeck = new Deck(4);

            Print("What is your name?");
            PlayerOne = new Player(GetInput());
        }
        protected override void displayInstuctions()
        {
            Clear();
            Print("Welcome to Higher or Lower!");
            Print("You will be shown a card and must guess if the next card will be of higher or lower value.");
            Print("If the value is the same but a different suit, you earn no points.");
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
            int guess = getPlayerGuess();

            Card nextCard = drawAndDisplay();
            int compare = compareCardValue(drawnCard, nextCard);

            evaluateGuess(guess, compare);
        }
        private Card drawAndDisplay()
        {
            Card card = GameDeck.DrawCard();
            printCardInformation(card);
            return card;
        }
        private void banner()
        {
            PrintBorder();
            Print(Name);
            PrintBorder();
            Print($"Score: {PlayerOne.Points}, Cards Left: {GameDeck.DeckSize}");
            PrintBorder();
        }
        private int getPlayerGuess()
        {
            List<string> higherLower = new List<string>
            {
                "Higher",
                "Lower",
                "Same"
            };

            Print("Will the value of the next card be higher, lower or the same?");
            for (int i = 0; i < higherLower.Count; i++)
            {
                Print($"[{i + 1}] {higherLower[i]} ");
            }

            switch (GetInput())
            {
                case "1":
                    return 1;
                case "2":
                    return -1;
                case "3":
                    return 0;
                default:
                    Print("Pick a valid option!!!");
                    getPlayerGuess();
                    break;
            }

            return 0;
        }
        private void printCardInformation(Card card)
        {
            Print($"\nThe card drawn is the {card.CardInformation()}");
            Print(card.Appearance);
        }
        private int compareCardValue(Card card, Card compareCard)
        {
            if (card.Value < compareCard.Value)
            {
                return 1;
            }
            else if (card.Value > compareCard.Value)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }
        private void evaluateGuess(int guess, int compare)
        {
            if (guess == compare)
            {
                if (guess == 0 || compare == 0)
                {
                    Print("You beat the odds and guessed correctly!!! You get +2 points");
                    PlayerOne.AddPoints(2);
                }
                else
                {
                    Print("You guessed correctly! You get +1 points");
                    PlayerOne.AddPoints(1);
                }
            }
            else
            {
                Print("You did not guess correctly.");
            }
        }
        protected override void endGame() => Print($"The game has ended. Your final score is {PlayerOne.Points}!");
    }
}
