using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighLowCardGame
{
    class Card
    {
        private int _suit;
        public int suit
        {
            get { return _suit; }
            set { _suit = value; }
        }

        private int _face;
        public int face
        {
            get { return _face; }
            set { _face = value; }
        }

        protected string[] Suit = { "Clubs", "Diamonds", "Hearts", "Spades" };
        //protected string[] Face = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13" };

        public Card()
        {
            face = 0;
            suit = 0;
        }

        public override string ToString()
        {
            return face + " of " + Suit[suit - 1];
        }
    }
}
