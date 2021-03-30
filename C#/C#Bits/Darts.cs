// Darts 
// devu.com C# Fundamentals via ASP.NET Web Applications
// Lesson 10 Challenge Assembilies Name Spaces and Class Members
// This code is located at Default.aspx.cs in project solution.


using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DartThrow;

namespace Darts
{
    public partial class Default : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            Game game = new Game();
            game.Play();
            if (game.Player1Score > game.Player2Score)
                resultLabel.Text = String.Format("Player 1 wins. The score is Player 1: {0} to Player 2: {1} ", game.Player1Score.ToString(), game.Player2Score.ToString());
            else
                resultLabel.Text = String.Format("Player 1 wins. The score is Player 2: {0} to Player 1: {1} ", game.Player2Score.ToString(), game.Player1Score.ToString());
        }
    }

    public class Game
    {
        public int Player1Score { get; set; }
        public int Player2Score { get; set; }

        public void Play()
        {
            Random random = new Random();
            while (this.Player1Score < 300 && this.Player2Score < 300)
            {
                this.Player1Score += throwRound(random);
                this.Player2Score += throwRound(random);
            }
        }

        private int throwRound(Random random)
        {
            Dart DartThrow = new Dart();
            int roundTotal = 0;
            for (int i = 0; i < 3; i++)
            {
                DartThrow.Throw(random); 
                roundTotal += Score.calculateScore(DartThrow);
            }
            return roundTotal;
        }
    }

    public class Score
    {
        public static int calculateScore(Dart dartThrow)
        {
            if (dartThrow.DoubleRing) return dartThrow.Score = dartThrow.Score * 2;
            else if (dartThrow.TripleRing) return dartThrow.Score = dartThrow.Score * 3;
            else if (dartThrow.OuterBullsEye) return dartThrow.Score = 25;
            else if (dartThrow.InnerBullsEye) return dartThrow.Score = 50;
            return dartThrow.Score;
        }


    }
}