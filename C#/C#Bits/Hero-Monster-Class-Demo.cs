using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HeroMonsterClasses
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Character hero = new Character();
            hero.name = "hero";
            hero.health = 100;
            hero.damageMaximum = 10;
            hero.attackBonus = false;

            Character monster = new Character();
            monster.name = "monster";
            monster.health = 100;
            monster.damageMaximum = 10;
            monster.attackBonus = true;

            Dice dice = new Dice();

            if (monster.attackBonus)
                hero.defend(monster.attack(dice));

            if (hero.attackBonus)
                monster.defend(hero.attack(dice));

            while (monster.health > 0 && hero.health > 0)
            {
                hero.defend(monster.attack(dice));
                monster.defend(hero.attack(dice));
            }

            displayResults(hero, monster);

        }

        private void displayResults(Character opponent1, Character opponent2)
        {
            if (opponent1.health <= 0 && opponent2.health <= 0)
                resultLabel1.Text += String.Format("<p>Both{0} and {1} died.", opponent1.name, opponent2.name);
            else if (opponent1.health <= 0)
                resultLabel1.Text += String.Format("<p>{0} defeats {1}.", opponent2.name, opponent1.name);
            else
                resultLabel1.Text += String.Format("<p>{0} defeats {1}.", opponent1.name, opponent2.name);
        }
    }

    public class Character
    {
        public string name { get; set; }
        public int health { get; set; }
        public int damageMaximum { get; set; }
        public bool attackBonus { get; set; }

        public int attack(Dice dice)
        {
            dice.sides = this.damageMaximum;
            return dice.roll();
        }

        public void defend(int attackDamage)
        {
            this.health -= attackDamage;
        }
    }

    public class Dice
    {
        public int sides { get; set; }

        Random random = new Random();
        public int roll()
        { 
            return random.Next(this.sides);
        }
    }
}