using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Wildcard.Utility;

namespace Wildcard
{
    // add method to set up player???
    abstract class Game
    {
        protected string Name { get; set; }
        protected Deck GameDeck { get; set; }
        protected Player PlayerOne { get; set; }

        protected abstract void setUp();
        protected abstract void displayInstuctions();
        public abstract void BeginGame();
        protected abstract void endGame();
    }
}
