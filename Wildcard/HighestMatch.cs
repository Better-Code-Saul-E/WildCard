using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Wildcard.Utility;

namespace Wildcard
{
    internal class HighestMatch : Game
    {
        // move banner method to game class ???
        // mabey a players list ??? add npc to it
        // add method so the player can choose to skip rounds if confident
        // add levels to the npc  
        // individual round method 

        private NPC ai { get; set; }
        private int rounds = 10;

        protected override void setUp()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.BackgroundColor = ConsoleColor.Black;
            Clear();
            GameDeck = new Deck(4);

            Name = "Highest Match";
            Print("What is your name?");
            PlayerOne = new Player(GetInput());
            ai = new NPC("Marsh");

            // make method for this ??? initial hand as a parameter??? Part of player class!
            for (int i = 0; i < 4; i++)
            {
                PlayerOne.DrawFromDeck(GameDeck);
                ai.DrawFromDeck(GameDeck);
            }

            Pause();
        }
        protected override void displayInstuctions()
        {
            Clear();
            Print("Welcome to Highest Match!");
            Print("You will be playing against an NPC dealer.");
            Print("Your goal is to collect the highest-value set of cards in a single suit.");
            Print("Each round, you can discard one card and draw a new one.");
            Print("After 10 rounds, your highest suit total will be compared to the dealer's.");
            Print("The highest suit total wins!");
            Pause();
        }
        public override void BeginGame()
        {
            setUp();
            displayInstuctions();
            
            while (rounds > 0)
            {
                Clear();
                banner();

                PlayerOne.PrintHand();
                PrintLine();

                PlayerTurn();

                rounds--;
                Print($"You have {rounds} rounds left\n");
                Pause();
            }

            int playerScore = calculateHighestSuitScore(PlayerOne.Hand);
            int aiScore = calculateHighestSuitScore(ai.Hand);
            PlayerOne.Points += playerScore;
            ai.Points += aiScore;

            endGame();
            compareScores(playerScore, aiScore);

            Pause();
        }
        private void banner()
        {
            PrintBorder();
            Print(Name);
            PrintBorder();
            Print($"Cards Left: {GameDeck.DeckSize}");
            PrintBorder();
        }

        // make method for discarding information 
        // make method for return player hand 
        private void PlayerTurn()
        {
            List<string> options = new List<string>
            {
                $"Discard {PlayerOne.Hand[0].CardInformation()}",
                $"Discard {PlayerOne.Hand[1].CardInformation()}",
                $"Discard {PlayerOne.Hand[2].CardInformation()}",
                $"Discard {PlayerOne.Hand[3].CardInformation()}",
                "Next round"
            };

            for (int i = 0; i < options.Count; i++)
            {
                Print($"[{i + 1}] {options[i]} ");
            }

            switch (GetInput())
            {
                case "1":
                    PlayerOne.removeCardAtIndex(0);
                    PlayerOne.DrawFromDeck(GameDeck);
                    break;
                case "2":
                    PlayerOne.removeCardAtIndex(1);
                    PlayerOne.DrawFromDeck(GameDeck);
                    break;
                case "3":
                    PlayerOne.removeCardAtIndex(2);
                    PlayerOne.DrawFromDeck(GameDeck);
                    break;
                case "4":
                    PlayerOne.removeCardAtIndex(3);
                    PlayerOne.DrawFromDeck(GameDeck);
                    break;
                case "5":
                    Print("You decided to move on to the next round");
                    break;
                default:
                    Print("Pick a valid option!!!");
                    PlayerTurn();
                    break;
            }
        }
        private int calculateHighestSuitScore(List<Card> hand)
        {
            Dictionary<string, int> suitScores = new Dictionary<string, int>();

            foreach (Card card in hand)
            {
                if (!suitScores.ContainsKey(card.Suit))
                {
                    suitScores.Add(card.Suit, card.Value);
                }
                else
                {
                    suitScores[card.Suit] += card.Value;
                }
            }

            return suitScores.Values.Max();
        }
        private void compareScores(int playerScore, int aiScore)
        {
            if (playerScore > aiScore)
            {
                Print("You Won!");
            }
            else
            {
                Print("You Lost.");
            }
        }
        protected override void endGame()
        {
            Print("The Game has ended");
            Print($"{PlayerOne.Name}'s final score is {PlayerOne.Points}!");
            Print($"{ai.Name}'s final score is {ai.Points}!");
        }

    }
}
