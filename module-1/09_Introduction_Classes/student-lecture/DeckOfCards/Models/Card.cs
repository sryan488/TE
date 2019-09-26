using System;
using System.Collections.Generic;
using System.Text;

namespace DeckOfCards.Models
{
    public class Cards
    {
        /// <summary>
        /// Value of a card from Ace (1) to King (13) (will show up in intellisense)
        /// </summary>
        public int Rank { get; set; }

        private string suit;
        /// <summary>
        /// "Hearts", "Diamonds", "Spades", or "Clubs"
        /// </summary>

        public string Suit
        {
            get
            {
                return suit;
            }
            set
            {
                if (value.ToLower() == "hearts")
                {
                    suit = "Hearts";
                }
                else if (value.ToLower() == "diamonds")
                {
                    suit = "Diamonds";
                }
                else if (value.ToLower() == "clubs")
                {
                    suit = "Clubs";
                }
                else if (value.ToLower() == "spades")
                {
                    suit = "Spades";
                }
                else
                {
                    //We did not get a valid value
                    throw new ArgumentException("Invalid suit value");
                }
            }
        }


        /// <summary>
        /// The color (derived from suit)
        /// </summary>

        public string Color
        {
            get
            {
                if (Suit.ToLower() == "hearts" || Suit.ToLower() == "diamonds")
                {
                    return "Red";
                }
                return "Black";
            }
        }

        /// <summary>
        /// True if the face of the card is showing
        /// </summary>

        public bool IsFaceUp { get; set; }
    }
}
