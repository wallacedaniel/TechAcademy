//Mega Casino 
//devu.com C# Fundamentals via ASP.NET Web Applications
//Lesson 7 Challenge Methods
//This code is located at Default.aspx.cs in project solution.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CasinoChallenge
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //sets players initial money value
                double playerTotal = 100;
                ViewState.Add("Totals", playerTotal);
                moneyLabel.Text = playerTotal.ToString();

                //presets random images
                string[] resultImages = new string[3];
                resultImages = randomImages();    
                setImages(resultImages);
            }
        }
		
		//WILL NOT CATCH EMPTY OR NON INTEGER INPUT OF BET VALUES   
        protected void leverButton_Click(object sender, EventArgs e)
        {
            double playerTotal = (double)ViewState["Totals"];
            int bet = int.Parse(betTextBox.Text);
            //makes sure you have money to play and your bet is not larger than your money
            if (playerTotal == 0 || bet > playerTotal)
            {
                resultLabel.Text = "Sorry, you either are out of money or your bet is more than you have available.";
                return;
            }

            //handles random images...and supplies values for bet result
            string[] resultImages = new string[3];
            resultImages = randomImages();
            setImages(resultImages);

           //checks for losing conditions
            if (barCheck(resultImages) == true || cherryCount(resultImages) == 0)
                lose(playerTotal, bet);
            //calls winning conditions
            else
                win(playerTotal, bet, resultImages);
        }

        //method to choose random images
        private string[] randomImages()
        {
            string[] images = new string[12]{ "Bar.png", "Bell.png", "Cherry.png", "Clover.png", "Diamond.png",
                     "HorseShoe.png", "Lemon.png", "Orange.png", "Plum.png", "Seven.png", "Strawberry.png", "Watermelon.png" };
            string[] resultImages = new string[3]; 

            Random randomImage = new Random();
            for (int i = 0; i < 3; i++)
            {
                int imageIndex = randomImage.Next(0, 12);
                resultImages[i] = images[imageIndex];
            }
            return resultImages;
        }

        //method to set image paths
        private void setImages(string[] resultImages)
        {
            Image1.ImageUrl = resultImages[0];
            Image2.ImageUrl = resultImages[1];
            Image3.ImageUrl = resultImages[2];
        }

        //method to check for "bars" in the result
        private bool barCheck(string[] resultImages)
        {
            for (int i = 0; i < 3; i++)
                if(resultImages[i] == "Bar.png")
                    return true;
            
            return false;
        }

        //method to count cherries
        private int cherryCount(string[] resultImages)
        {
            int cherryCount = 0; 
            for (int result = 0; result < 3; result++)
                if (resultImages[result] == "Cherry.png")
                    cherryCount += 1;

            return cherryCount;
        }

        //method to count sevens
        private int sevenCount(string[] resultImages)
        {
            int sevenCount = 0; //this is what I want from here
            for (int result = 0; result < 3; result++)
                if (resultImages[result] == "Seven.png")
                    sevenCount += 1;

            return sevenCount;
        }

        //method to lose
        private void lose(double playerTotal, int bet)
        {
            playerTotal -= bet;
            ViewState.Add("Totals", playerTotal);
            moneyLabel.Text = playerTotal.ToString();
            resultLabel.Text = String.Format("You bet {0:C} and lost {0:C}!", bet, bet);
        }

        //method to win
        private void win(double playerTotal, int bet, string[] resultImages)
        {
            double winTotal = winResult(bet, resultImages);
            playerTotal += winTotal;
            ViewState.Add("Totals", playerTotal);
            moneyLabel.Text = playerTotal.ToString();
            resultLabel.Text = String.Format("You bet {0:C} and won {1:C}!", bet, winTotal); //last wrong?
        }

        //method to determine win total
        private double winResult(int bet, string[] resultImages)
        {
            double winTotal = 0;
            if (cherryCount(resultImages) == 1)
                winTotal = bet * 2;
            else if (cherryCount(resultImages) == 2)
                winTotal = bet * 3;
            else if (cherryCount(resultImages) == 3)
                winTotal = bet * 4;
            else if (sevenCount(resultImages) == 3)
                winTotal = bet * 100;
            return winTotal;
        }

    }
}


