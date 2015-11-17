using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighLowCardGame
{
    class Game
    {
        static Deck base_deck;

        public static void DeckCards()
        {
            base_deck = new Deck(13, 4);
            base_deck.shuffle();
        }

        public static void NewPlayers(Player player1, Player player2)
        {
            player1.player = 1;
            player2.player = 2;
        }

        public static void GivePlayerADeck(Player player1, Player player2)
        {
            for (int i = 0; i < 26; i++)
            {
                player1.playerdeck.Cards.Add(base_deck.Cards[i]);
            }

            for (int i = 0; i < 26; i++)
            {
                player2.playerdeck.Cards.Add(base_deck.Cards[i + 26]);
            }
        }

        public static void win(Player player, int NumberofCards = 1)
        {
            player.count += (NumberofCards) * 2;
            Console.WriteLine("Player" + player.player + " " + player.name + " win! get 2 cards");
        }

        public static void removecards(Player player1, Player player2, int range)
        {
            int LastCard = player1.playerdeck.Cards.Count - 1;
            player1.playerdeck.Cards.RemoveRange(LastCard - range + 1, range);
            player2.playerdeck.Cards.RemoveRange(LastCard - range + 1, range);
         }

        public static void tie(Player player1, Player player2)
        {
            Console.WriteLine("Tie! Shuffle the cards deck!!");
            player1.playerdeck.shuffle();
            player2.playerdeck.shuffle();
        }


        public static int CompareCardDeck(Player player1, Player player2)
        {
            if (player1.playerdeck.Cards.Count == 0)
            {
                Console.WriteLine("No more card left in the both players card deck");
                return -1;
            }

            int LastCard = player1.playerdeck.Cards.Count - 1;
            int player1_last = player1.playerdeck.Cards[LastCard].face;
            int player2_last = player2.playerdeck.Cards[LastCard].face;

            Console.WriteLine("Player" + player1.player + " " + player1.name + " has " + player1.playerdeck.Cards[LastCard]);
            Console.WriteLine("Player" + player2.player + " " + player2.name + " has " + player2.playerdeck.Cards[LastCard]);

            if (player1.playerdeck.Cards.Count == 1 && player1.playerdeck.Cards[LastCard].face == player2.playerdeck.Cards[LastCard].face)
            {
                Console.WriteLine("Tie! The last card of both players is the same.");
                return -1;
            }

            if (player1_last == player2_last)
            {
                bool Continue_Game = true;
                for (int i = 0; i <= LastCard; i++)
                {
                    for (int j = 0; j <= LastCard; j++)
                    {
                        if (player1.playerdeck.Cards[i].face > player2.playerdeck.Cards[j].face)
                        {
                            Continue_Game = false;
                        }
                        else
                        {
                            Continue_Game = true;
                        }
                    }
                }

                if (!Continue_Game)
                {
                    return -1;
                }
                

                int NumberFromLastCard = player1_last;

                if (NumberFromLastCard > LastCard)
                {
                    tie(player1, player2);
                     return 0;
                }

                Console.WriteLine("Player" + player1.player + " has " + player1.playerdeck.Cards[NumberFromLastCard]);
                Console.WriteLine("Player" + player2.player + " has " + player2.playerdeck.Cards[NumberFromLastCard]);

                int player1_fromlast = player1.playerdeck.Cards[NumberFromLastCard].face;
                int player2_fromlast = player2.playerdeck.Cards[NumberFromLastCard].face;
                if (player1_fromlast < player2_fromlast)
                {
                    win(player1, NumberFromLastCard);
                    removecards(player1, player2, NumberFromLastCard);
                    return 1;
                }

                else if (player1_fromlast > player2_fromlast)
                {
                    win(player2, NumberFromLastCard);
                    removecards(player1, player2, NumberFromLastCard);
                    return 2;
                }

                else
                {
                    tie(player1, player2);
                    return 0;
                }
            }

            //Player1 WIN
            else if (player1_last < player2_last)
            {
                win(player1);
                removecards(player1, player2, 1);
                return 1;
            }

            //Player2 WIN
            else if (player1_last > player2_last)
            {
                win(player2);
                removecards(player1, player2, 1);
                return 2;
            }
            return -1;
        }

        public static void endgame(Player player1, Player player2)
        {
            Console.WriteLine( "Player" + (player1.count > player2.count ? player1.player : player2.player) + " WIN!!!");
        }
    }
}
