using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighLowCardGame
{
    class Player
    {
        private Deck _playerdeck;
        private int _count;
        private int _player;
        private string _name;

        public Deck playerdeck
        {
            get;
            set;
        }

        public int count
        {
            get { return _count; }
            set { _count = value; }
        }

        public int player
        {
            get { return _player; }
            set { _player = value; }
        }

        public string name
        {
            get { return _name; }
            set { _name = value; }
        }

        public void ShowPlayerProperties()
        {
            Console.WriteLine("Player" + player + " has " + playerdeck.Cards.Count + " playing card(s) and " + count + " winning card(s)");
        }

        public Player(int numplayer)
        {
            playerdeck = new Deck();
            player = numplayer;
            count = 0;
            name = "Unknown";
        }
    }
}
