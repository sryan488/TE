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



                // Take the shrink-wrap off of a new deck of cards


                // Shuffle the deck


                // Deal two hands


                // Display the two hands


                Console.Write("\nType q to Quit.");
                if (Console.ReadLine().ToLower() == "q")
                {
                    break;
                }
            }

        }
    }
}
