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


                // Display the two hands
                int count = 0;
                for (Card card = deck.DealOne(); card != null; card = deck.DealOne() )
                {
                    Console.WriteLine(card.Title);
                    count++;
                }

                Console.WriteLine($"There were {count} cards in the deck");

                Console.Write("\nType q to Quit.");
                if (Console.ReadLine().ToLower() == "q")
                {
                    break;
                }
            }

        }
    }
}
