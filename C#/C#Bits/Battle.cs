using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace War
{
    public class Battle
    {
        public List<string> Winner { get; set; }
        public List<string> WarWinner { get; set; }
        public List<Card> BattleCards { get; set; }
        public List<Card> BountyCards { get; set; }

        public Battle()
        {
            this.Winner = new List<string>();
            this.WarWinner = new List<string>();
            this.BattleCards = new List<Card>();
            this.BountyCards = new List<Card>();
        }

        public void startBattle(List<Card> playerCards1, List<Card> playerCards2)
        {
            
            int index1 = playerCards1.Count() - 1;
            int index2 = playerCards2.Count() - 1;
            BattleCards.Add(playerCards1.ElementAt(index1));
            BattleCards.Add(playerCards2.ElementAt(index2));

            if (playerCards1[index1].CardValue > playerCards2[index2].CardValue)
            {
                BountyCards.Add(playerCards1.ElementAt(index1));
                BountyCards.Add(playerCards2.ElementAt(index2));
                playerCards1.Insert(0, playerCards1[index1]);
                playerCards1.Insert(0, playerCards2[index2]);
                playerCards1.RemoveAt(index1 + 2);
                playerCards2.RemoveAt(index2);

                Winner.Add("Player 1 Wins!");
            }
            else if (playerCards2[index2].CardValue > playerCards1[index1].CardValue)
            {
               
                BountyCards.Add(playerCards1.ElementAt(index1));
                BountyCards.Add(playerCards2.ElementAt(index2));
                playerCards2.Insert(0, playerCards2[index2]);
                playerCards2.Insert(0, playerCards1[index1]);
                playerCards1.RemoveAt(index1);
                playerCards2.RemoveAt(index2 + 2);

                Winner.Add("Player 2 Wins!");
            }
            else
            {
                //Can throw an out of range index if mutiple wars happen at lowest bounds
                if (index1 > 4 && index2 > 4)
                {
                    War war = new War();
                    int warCount = 1;
                    string winner = "";
                    try
                    {
                        BountyCards = war.callWar(playerCards1, playerCards2, index1, index2, warCount, out winner);
                    }
                    catch (Exception ex)
                    {

                        throw ex;
                    }

                }
                else
                {
                    WarWinner.Add("Overwehlming force has inspired surender");
                    if (playerCards1.Count() > playerCards2.Count()){
                        WarWinner.Add("Player 1 has vanquished Player2");
                    }
                    else WarWinner.Add("Player 2 has vanquished Player1");
                    playerCards1.Clear();
                    playerCards2.Clear();
                }

                Winner.Add("********WAR!!!********");
            }
        }
    }
}