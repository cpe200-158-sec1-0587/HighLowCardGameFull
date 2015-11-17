using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighLowCardGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Player player1 = new Player(1);
            Player player2 = new Player(2);
            Game.DeckCards();
            Game.NewPlayers(player1, player2);
            Game.GivePlayerADeck(player1, player2);
            Console.Write("Player1's name : ");
            player1.name = Console.ReadLine();
            Console.Write("Player2's name : ");
            player2.name = Console.ReadLine();
            Console.WriteLine("");
            Console.WriteLine("START!!");
            Console.WriteLine("");

            int result = 0;
            int turn = 1;
            do
            {
                Console.WriteLine("Turn " + turn );
                result = Game.CompareCardDeck(player1, player2);
                player1.ShowPlayerProperties();
                player2.ShowPlayerProperties();
                if (player1.playerdeck.Cards.Count == 0)
                {
                    Console.WriteLine("[Summary] No more card left in the both players card deck");
                    break;
                }
                Console.WriteLine("");
                ++turn;

            } while (result != -1);
            Game.endgame(player1, player2);
            Console.ReadKey();
        }
    }
}
