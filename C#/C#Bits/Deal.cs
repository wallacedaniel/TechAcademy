using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace War
{
    public class Deal
    {
        public List<Card> playerCards1 { get; set; }
        public List<Card> playerCards2 { get; set; }

        public Deal()
        {
            this.playerCards1 = new List<Card>();
            this.playerCards2 = new List<Card>();
        }

        public void dealCards()
        {
            Deck deck = new Deck();
            deck.createDeck();
            List<Card> cards = deck.cards;
            Random random = new Random();
            Card card = new Card();

            while (cards.Count() > 0)
            {
                int index = random.Next(0, cards.Count() - 1);
                card = cards.ElementAt(index);
                cards.Remove(card);
                playerCards1.Add(card);

                index = random.Next(0, cards.Count() - 1);
                card = cards.ElementAt(index);
                cards.Remove(card);
                playerCards2.Add(card);
            }
        }
    }
}