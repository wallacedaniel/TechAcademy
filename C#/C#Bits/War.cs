using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace War
{
    public class War
    {
        public List<Card> callWar(List<Card> playerCards1, List<Card> playerCards2, int index1, int index2, int warCount, out string warWinner)
        {
            var bountyCards = new List<Card>();

            Card battleCard1 = playerCards1.ElementAt(index1 - 4);
            Card battleCard2 = playerCards2.ElementAt(index2 - 4);

            if (battleCard1.CardValue > battleCard2.CardValue)
            {
                List<Card> tempCards = playerCards1.GetRange(index1 - 4, 4 * warCount + 1);
                foreach (var card in tempCards) bountyCards.Add(card);
                playerCards1.InsertRange(0, tempCards);
                tempCards = playerCards2.GetRange(index2 - 4, 4 * warCount + 1);
                foreach (var card in tempCards) bountyCards.Add(card);
                playerCards1.InsertRange(0, tempCards);
                playerCards1.RemoveRange((index1 - 4) + (2 * (4 * warCount + 1)), 4 * warCount + 1);
                playerCards2.RemoveRange(index2 - 4, 4 * warCount + 1);
                warWinner = "Player 1 Wins!";
            }

            else if (battleCard2.CardValue > battleCard1.CardValue)
            {
                List<Card> tempCards = playerCards2.GetRange(index2 - 4, 4 * warCount + 1);

                foreach (var card in tempCards) bountyCards.Add(card);

                playerCards2.InsertRange(0, tempCards);
                tempCards = playerCards1.GetRange(index1 - 4, 4 * warCount + 1);
                foreach (var card in tempCards) bountyCards.Add(card);
                playerCards2.InsertRange(0, tempCards);
                playerCards2.RemoveRange((index2 - 4) + (2 * (4 * warCount + 1)), 4 * warCount + 1);
                playerCards1.RemoveRange(index1 - 4, 4 * warCount + 1);
                warWinner = "Player 2 Wins!";
            }

            else
            {
                warWinner = "";
                warCount += 1;
                callWar(playerCards1, playerCards2, index1 - 4, index2 - 4, warCount, out warWinner);
            }
            return bountyCards;
        }
    }
}