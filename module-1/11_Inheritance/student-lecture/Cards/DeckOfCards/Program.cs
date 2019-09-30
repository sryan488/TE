using DeckOfCards.Models;
using System;
using System.Collections.Generic;

namespace DeckOfCards
{
    class Program
    {
        static void Main(string[] args)
        {

            // Default output encoding (character set) is ASCII
            // Set it to Unicode so we can display card sysbols
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            // Let the user keep doing this until the cows come home
            while (true)
            {
                // Clear the screen
                Console.Clear();


                // Take the shrink-wrap off of a new deck of cards
                Deck deck = new Deck();

                // Shuffle the deck
                deck.Shuffle();

                // Deal two hands
                List<Card> player1Cards = new List<Card>();
                List<Card> player2Cards = new List<Card>();

                for(int i = 1; i <= 5; i++)
                {
                    player1Cards.Add(deck.DealOne());
                    player2Cards.Add(deck.DealOne());
                }

                // Display the two hands
                Console.WriteLine("Player 1:");
                DisplayHand(player1Cards);
                Console.WriteLine();
                Console.WriteLine("Player 2:");
                DisplayHand(player2Cards);

                Console.Write("\nType q to Quit.");
                if (Console.ReadLine().ToLower() == "q")
                {
                    break;
                }
            }

        }

        public static void DisplayHand(List<Card> hand)
        {
            ConsoleColor color = Console.ForegroundColor;

            foreach(Card card in hand)
            {
                Console.ForegroundColor = card.Color == "Red" ? ConsoleColor.Red : ConsoleColor.Black;
                Console.WriteLine($"\t{card.Title}");
            }
            Console.ForegroundColor = color;
        }
    }
}
