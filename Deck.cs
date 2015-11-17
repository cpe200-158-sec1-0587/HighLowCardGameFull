using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighLowCardGame
{
    class Deck
    {
        public List<Card> Cards;

        public Deck()
        {
            Cards = new List<Card>();
        }

        public Deck (int numface = 13 , int numsuit = 4) : this()
        {
            for (int i = 0; i < numface; i++)
            {
                for (int j = 0; j < numsuit ; j++ )
                {
                    Cards.Add(new Card { face = i + 1, suit = j + 1 });
                }
            }
        }

        public void shuffle()
        {
            Random random = new Random();
            for (int i = 0; i < Cards.Count; i++)
            {
                var j = random.Next(i, Cards.Count);
                var temp = Cards[i];
                Cards[i] = Cards[j];
                Cards[j] = temp;
            }
        }

    }
}
