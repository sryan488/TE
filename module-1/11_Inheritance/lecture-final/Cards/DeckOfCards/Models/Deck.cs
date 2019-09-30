using System;
using System.Collections.Generic;
using System.Text;

namespace DeckOfCards.Models
{
    public class Deck
    {
        // This private 
        private List<Card> cards = new List<Card>();

        /// <summary>
        /// Creates a standard 52-card deck, un-shuffled. 
        /// </summary>
        public Deck()
        {
            // Create a temporary array just for the purpose of looping through suits
            string[] suits = new string[] { "Hearts", "Diamonds", "Spades", "Clubs" };
            // Outside loop cycles through each card rank.
            for (int rank = 1; rank <= 13; rank++)
            {
                // Inside loop cyles through each suit using the temprary array we setup above
                foreach (string suit in suits)
                {
                    // Create a card of this rank and suit, and add it to our list of caerds
                    Card card = new Card(rank, suit, false);
                    cards.Add(card);
                }
            }
        }

        /// <summary>
        /// If there are any cards left in the deck, returns the top card and remove that card from the deck. 
        /// </summary>
        /// <returns>The top Card off the deck. If the deck is empty, returns null.</returns>
        public Card DealOne()
        {
            // Declare a variable to hold the result that we will return
            Card result = null;

            // if there are cards left, retrun the first, and remove it from the list of cards.
            if (cards.Count > 0)
            {
                result = cards[0];
                cards.RemoveAt(0);
            }
            return result;
        }

        /// <summary>
        /// Randomly shuffle whatever cards are left in the deck
        /// </summary>
        public void Shuffle()
        {
            // First, create a second card list hold hold the cards in a new order.
            List<Card> shuffledCards = new List<Card>();

            // The System.Random class is used for getting random numbers.
            Random random = new Random();

            // We'll be done shuffling when there are no cards left in the original list
            while (cards.Count > 0)
            {
                // Generate a random number from 0 to the largest List index for the current list.
                int randomIndex = random.Next(cards.Count);

                // Locate that random card in the cards list, and add it to the shuffled cards list. Then,
                // remove the card from the original cards list
                shuffledCards.Add(cards[randomIndex]);
                cards.RemoveAt(randomIndex);
            }

            // We have now move all the cards randomly from the original cards list to the new shuffledCards list.
            // We must now re-point the cards private field to the new shuffled list.
            cards = shuffledCards;
        }
    }
}
