using DeckOfCards.Models;
using System;
using System.Collections.Generic;

namespace DeckOfCards
{
    class Program
    {
        static void Main(string[] args)
        {

            //Card card = new Card(1,"Hearts",
            //card.IsFaceUp = true;
            //card.Rank = 2;
            //card.Suit = "HEARTS";

            //Console.WriteLine($"Card: {card.Rank} of {card.Suit}, face { (card.IsFaceUp ? "up" : "down") }");
            //Console.ReadLine();
            //return;

            // Let's store all of our cards in a list
            // CODE GOES HERE

            List<Card> cards = new List<Card>();

            while (true)
            {
                Console.WriteLine("What do you want to do? ");
                Console.WriteLine("1. Create a new card.");
                Console.WriteLine("2. Display all of the cards.");
                Console.WriteLine("3. Flip all of the cards.");
                Console.WriteLine("Q. Quit");

                string input = Console.ReadLine();

                if (input == "1")
                {
                    // Get the card value
                    int value = 0;
                    while (value == 0)
                    {
                        // Get the value for the new card
                        Console.Write("What is the value of the card (1-13): ");
                        input = Console.ReadLine();
                        if (int.TryParse(input, out value))
                        {
                            if (value < 1 || value > 13)
                            {
                                value = 0;
                            }
                        }

                    }

                    // Get the suit for the new card
                    string suit = "";
                    while (suit == "")
                    {
                        Console.Write("What suit does the card have: (H)earts, (D)iamonds, (C)lubs, (S)pades? ");
                        input = Console.ReadLine();
                        if (input.Length > 0)
                        {
                            input = input.Substring(0, 1).ToUpper();
                        }
                        if (input == "H")
                        {
                            suit = "Hearts";
                        }
                        else if (input == "D")
                        {
                            suit = "Diamonds";
                        }
                        else if (input == "C")
                        {
                            suit = "Clubs";
                        }
                        else if (input == "S")
                        {
                            suit = "Spades";
                        }
                    }

                    // Is the card face up or face down
                    Console.Write("Is the card face up (Y/N): ");
                    input = Console.ReadLine();
                    bool isFaceUp = false;
                    if (input.Length > 0 && input.ToLower().StartsWith("y"))
                    {
                        isFaceUp = true;
                    }

                    //Console.WriteLine($"Your card is the {value} of {suit} (face {(isFaceUp ? "up" : "down")})");

                    // Create the card and add to the list
                    Card card = new Card(value, suit, isFaceUp);
                    cards.Add(card);

                }
                else if (input == "2")
                {
                    Console.WriteLine("Displaying all of the cards.");

                    // Loop through each of the cards
                    foreach( Card card in cards)
                    {
                        Console.WriteLine($"{card.Title}, face {(card.IsFaceUp ? "up" : "down")}");
                    }

                }
                else if (input == "3")
                {
                    Console.WriteLine($"Flipping the cards.");

                    // Loop through each of the cards and flip them

                }
                else if (input.ToLower().StartsWith("q"))
                {
                    break;
                }

                // Wait for user to press enter and clear screen.
                Console.ReadLine();
                Console.Clear();
            }
        }
    }
}
