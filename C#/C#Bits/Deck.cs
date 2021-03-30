using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace War
{
    public class Deck
    {
        public List<Card> cards { get; set; }

        public Deck()
        {
            this.cards = new List<Card>();
        }

        //construct the deck
        public void createDeck()
        {
            string[] suit = new string[4] { "Diamonds", "Clubs", "Hearts", "Spades" };
            for (int i = 0; i < suit.Length; i++)
            {
                for (int j = 2; j < 15; j++)
                {
                    Card card = new Card();
                    card.Suit = suit[i];
                    card.CardValue = j;
                    card.Name = card.CardValue + " of " + card.Suit;
                    if (card.CardValue == 11) card.Name = "Jack of " + card.Suit;
                    if (card.CardValue == 12) card.Name = "Queen of " + card.Suit;
                    if (card.CardValue == 13) card.Name = "King of " + card.Suit;
                    if (card.CardValue == 14) card.Name = "Ace of " + card.Suit;
                    cards.Add(card);
                }
            } 
        }
    }
}